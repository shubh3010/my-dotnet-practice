# Plan: Build a C# MCP Server for BlogPractice API

**TL;DR** — Create a new .NET console app (`BlogMcpServer`) that acts as an MCP server, exposing read-only tools to query your Blog API via HTTP. Both Claude Desktop and VS Code Copilot connect to it via stdio transport, letting you ask things like *"show me all posts by author 1"* or *"list all tags"* in natural language.

## Architecture

```
Claude Desktop / VS Code Copilot
        ↓  (stdio / JSON-RPC)
   BlogMcpServer  (new Console App)
        ↓  (HTTP calls)
   BlogPractice API  (your existing ASP.NET Core app)
        ↓  (EF Core)
     SQL Server
```

---

## Phase 1: Project Setup (steps 1-3)

1. **Create new console project** `BlogMcpServer` alongside your existing app and add it to the solution
   - `dotnet new console -n BlogMcpServer -o BlogMcpServer`
   - `dotnet sln BlogPractice.sln add BlogMcpServer/BlogMcpServer.csproj`

2. **Install NuGet packages**: `ModelContextProtocol`, `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.Http`

3. **Wire up `Program.cs`**: Use `Host.CreateApplicationBuilder` → `.AddMcpServer().WithStdioServerTransport().WithToolsFromAssembly()` → Register `HttpClient` pointing at your Blog API's URL (from `Properties/launchSettings.json`)

## Phase 2: Build MCP Tools (steps 4-7)

4. **`PostTools.cs`** — `[McpServerToolType]` class with:
   - `list_posts` tool — calls `GET /api/posts` with optional filters (`page`, `pageSize`, `authorId`, `tag`, `from`, `to`)
   - `get_post` tool — calls `GET /api/posts/{id}`, returns post with comments

5. **`AuthorTools.cs`** — `[McpServerToolType]` class with:
   - `list_authors` tool — calls `GET /api/author` with pagination

6. **`TagTools.cs`** — `[McpServerToolType]` class with:
   - `list_tags` tool — calls `GET /api/tags`
   - `get_tag` tool — calls `GET /api/tags/{id}`

7. **`BlogApiClient.cs`** — a thin typed HTTP client wrapping all API calls, registered in DI. Handles errors gracefully so Claude gets useful feedback instead of stack traces.

## Phase 3: Expose API Schema as MCP Resource (step 8)

8. **`ApiSchemaResource.cs`** — `[McpServerResourceType]` exposing `blog://api/schema` — a static description of all endpoints and models so Claude has context without needing tool calls first.

## Phase 4: Configure MCP Clients (steps 9-10)

9. **Claude Desktop** — Add to `%APPDATA%\Claude\claude_desktop_config.json`:
   ```json
   {
     "mcpServers": {
       "blog-api": {
         "command": "dotnet",
         "args": ["run", "--project", "c:\\study\\BlogPractice\\BlogMcpServer\\BlogMcpServer.csproj"]
       }
     }
   }
   ```

10. **VS Code** — Create `.vscode/mcp.json`:
    ```json
    {
      "servers": {
        "blog-api": {
          "command": "dotnet",
          "args": ["run", "--project", "c:\\study\\BlogPractice\\BlogMcpServer\\BlogMcpServer.csproj"]
        }
      }
    }
    ```

## Phase 5: Test & Verify (steps 11-14)

11. Start your Blog API (`dotnet run`)
12. Run MCP server standalone to verify it starts clean
13. **Claude Desktop**: Restart → look for the hammer icon → try *"List all blog posts"*
14. **VS Code**: Reload window → Agent mode → try *"Use blog-api tools to list recent posts"*

---

## Relevant Files

### Existing (reference for endpoint shapes)
- `Controllers/PostController.cs` — GET endpoints to call
- `Controllers/AuthorController.cs`, `Controllers/TagController.cs`
- `Dtos/` — response/request shapes
- `Properties/launchSettings.json` — API port

### New files to create
- `BlogMcpServer/BlogMcpServer.csproj` — new console project
- `BlogMcpServer/Program.cs` — MCP entry point
- `BlogMcpServer/BlogApiClient.cs` — typed HTTP client
- `BlogMcpServer/Tools/PostTools.cs`, `AuthorTools.cs`, `TagTools.cs` — MCP tools
- `BlogMcpServer/Resources/ApiSchemaResource.cs` — API schema resource
- `.vscode/mcp.json` — VS Code client config

## Decisions
- **Stdio transport** — works with both Claude Desktop and VS Code
- **Separate project, no shared code** — MCP server talks to Blog API over HTTP only (clean, realistic)
- **Read-only scope** — no create/update/delete tools for now (can add later)
- **C# with official `ModelContextProtocol` NuGet SDK**
