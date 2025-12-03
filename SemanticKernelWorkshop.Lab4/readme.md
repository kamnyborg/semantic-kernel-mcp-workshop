# Semantic Kernel Workshop - Lab 4

## Goals: 
- Create an MCP client in .NET

## Instructions:
THIS STEP REQUIRES THAT YOU HAVE COMPLETED LAB 3!

1. Go to Program.cs and add this code for step 1:
```csharp
var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Command = "dotnet run",
        Arguments = ["--project", projectRoot + "\\SemanticKernelWorkshop.Lab3"],
        Name = "MCP",
    }));
```

2. Go to Program.cs and add this code for step 2:
```csharp
var tools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

Console.WriteLine("AVAILABLE MCP TOOLS:");
foreach (var tool in tools)
{
    Console.WriteLine($"{tool.Name}: {tool.Description}");
}
```