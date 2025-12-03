using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Configure logging to output all logs to stderr.
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Register the MCP server with stdio transport and load tools from the current assembly.
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();

// MCP Tool implementation: returns the current UTC time
[McpServerToolType]
public static class UtcTimeTool
{
    [McpServerTool, Description("Gets the current UTC time.")]
    public static string GetCurrentTime() => DateTimeOffset.UtcNow.ToString();
}
