using ModelContextProtocol.Client;

var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Command = "dotnet run",
        Arguments = ["--project", "C:\\Users\\kgregertsen\\Repos\\semantic-kernel-workshop\\SemanticKernelWorkshop\\SemanticKernelWorkshop.Lab3"],
        Name = "MCP",
    }));

// Retrieve and display the list of available MCP tools.
var tools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

Console.WriteLine("AVAILABLE MCP TOOLS:");
foreach (var tool in tools)
{
    Console.WriteLine($"{tool.Name}: {tool.Description}");
}

Console.ReadKey();