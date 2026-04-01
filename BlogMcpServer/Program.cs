using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BlogMcpServer;

var builder = Host.CreateApplicationBuilder(args);

// MCP uses stdout for JSON-RPC — all logs must go to stderr
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Typed HTTP client pointing at the BlogPractice API
builder.Services.AddHttpClient<BlogApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5299");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly()
    .WithResourcesFromAssembly();

await builder.Build().RunAsync();
