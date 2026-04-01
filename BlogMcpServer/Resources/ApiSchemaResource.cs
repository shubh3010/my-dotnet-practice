using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BlogMcpServer.Resources;

[McpServerResourceType]
public static class ApiSchemaResource
{
    [McpServerResource(UriTemplate = "blog://api/schema", Name = "Blog API Schema", MimeType = "text/plain")]
    [Description("Static description of all BlogPractice API endpoints and data models. Read this first to understand what tools are available and what data they return.")]
    public static string GetSchema() => """
        # BlogPractice API Schema
        
        Base URL: http://localhost:5299
        
        ---
        
        ## Models
        
        ### PostSummary
        | Field       | Type     | Description                  |
        |-------------|----------|------------------------------|
        | id          | int      | Unique post identifier        |
        | authorId    | int      | ID of the author              |
        | title       | string   | Post title                    |
        | publishedAt | datetime | Publication date (UTC)        |
        
        ### PostDetail
        | Field       | Type     | Description                  |
        |-------------|----------|------------------------------|
        | id          | int      | Unique post identifier        |
        | authorId    | int      | ID of the author              |
        | title       | string   | Post title                    |
        | content     | string   | Full post body                |
        | publishedAt | datetime | Publication date (UTC)        |
        
        ### Author
        | Field    | Type          | Description                          |
        |----------|---------------|--------------------------------------|
        | id       | int           | Unique author identifier              |
        | userName | string        | Author's username                     |
        | email    | string        | Author's email address                |
        | posts    | PostSummary[] | List of posts written by this author  |
        
        ### Tag
        | Field | Type   | Description            |
        |-------|--------|------------------------|
        | id    | int    | Unique tag identifier  |
        | name  | string | Tag label              |
        
        ---
        
        ## Endpoints
        
        ### Posts
        
        GET /api/post
          List posts with optional filters.
          Query params:
            - page       (int, default 1)
            - pageSize   (int, default 10)
            - authorId   (int?, filter by author)
            - tag        (string?, filter by tag name)
            - from       (datetime?, published after)
            - to         (datetime?, published before)
          Returns: PostSummary[]
        
        GET /api/post/{id}
          Get a single post by ID.
          Returns: PostDetail  |  404 if not found
        
        GET /api/post/getComplex/{postId}
          Get a post with additional related data.
          Returns: PostDetail (with extra fields)
        
        POST /api/post
          Create a new post.
          Body: { title: string, content: string, authorId: int, publishedAt?: datetime }
          Returns: 201 Created with PostDetail
        
        PUT /api/post/{id}
          Update an existing post.
          Body: { id: int, title: string, content: string, publishedAt: datetime }
          Returns: 204 No Content  |  400 if id mismatch  |  404 if not found
        
        DELETE /api/post/{id}
          Delete a post.
          Returns: 204 No Content  |  404 if not found
        
        ---
        
        ### Authors
        
        GET /api/author
          List authors with pagination.
          Query params:
            - page     (int, default 1)
            - pageSize (int, default 10)
          Returns: Author[]
        
        ---
        
        ### Tags
        
        GET /api/tags
          List all tags.
          Returns: Tag[]
        
        GET /api/tags/{id}
          Get a single tag by ID.
          Returns: Tag  |  404 if not found
        
        POST /api/tags
          Create a new tag.
          Body: { name: string }
          Returns: Tag
        
        PUT /api/tags/{id}
          Update a tag name.
          Body: { name: string }
          Returns: 204 No Content
        
        DELETE /api/tags/{id}
          Delete a tag.
          Returns: 204 No Content
        
        ---
        
        ## Available MCP Tools
        
        | Tool          | Description                                          |
        |---------------|------------------------------------------------------|
        | list_posts    | List posts with optional filters                     |
        | get_post      | Get full detail of a post by ID                      |
        | list_authors  | List authors with pagination                         |
        | list_tags     | List all tags                                        |
        | get_tag       | Get a tag by ID                                      |
        """;
}
