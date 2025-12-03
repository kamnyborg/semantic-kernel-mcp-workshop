# Semantic Kernel Workshop - Lab 4

## Goals: 
- Create an MCP client in .NET

1. Go to Program.cs and add this code on line 3:
```csharp
var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Command = "dotnet run",
        Arguments = ["--project", "C:\\Users\\kgregertsen\\Repos\\semantic-kernel-workshop\\SemanticKernelWorkshop\\SemanticKernelWorkshop.Lab3"],
        Name = "MCP",
    }));
```

2. Fetch the tools from the MCP server on line 6:
```csharp
var tools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

Console.WriteLine("AVAILABLE MCP TOOLS:");
foreach (var tool in tools)
{
    Console.WriteLine($"{tool.Name}: {tool.Description}");
}
```