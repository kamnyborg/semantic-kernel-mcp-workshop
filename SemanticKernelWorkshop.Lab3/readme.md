# Semantic Kernel Workshop - Lab 3

## Goals: 
- Create a MCP server in .NET

## Instructions:
1. Go to Program.cs and add this code for step 1:
```csharp
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
```

2. Add the implementation of Tools/DateTimeTool.cs:
```csharp
[McpServerTool, Description("Get the current date and time")]
public static string GetCurrentTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");     
```

3. Navigate to the project folder in a terminal and run the command to test the MCP server:
npx @modelcontextprotocol/inspector dotnet run
