using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var modelDeploymentName = "gpt-4.1";
var azureOpenAIEndpoint = config.GetValue<string>("AZUREOPENAI_ENDPOINT");
var azureOpenAIApiKey = config.GetValue<string>("AZUREOPENAI_APIKEY");

var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(
        modelDeploymentName,
        azureOpenAIEndpoint,
        azureOpenAIApiKey)
    .Build();

var projectRoot = Directory.GetParent(AppContext.BaseDirectory)    // netX.Y
                             ?.Parent                                 // Debug
                             ?.Parent                                 // bin
                             ?.Parent
                             ?.Parent// <project root>
                             ?.FullName;


var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Command = "dotnet run",
        Arguments = ["--project", projectRoot + "\\SemanticKernelWorkshop.Lab3"],
        Name = "MCP",
    }));

// Retrieve the list of available MCP tools.
var tools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

// Add the MCP tools as plugins in Semantic Kernel.
kernel.Plugins.AddFromFunctions("UtcTimeTool", tools.Select(aiFunction => aiFunction.AsKernelFunction()));

string prompt = "I would like to know what date is it and 5 significant things that happened in the past on this day.";

OpenAIPromptExecutionSettings promptExecutionSettings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

var result = await kernel.InvokePromptAsync(
    prompt,
    new(promptExecutionSettings));

Console.WriteLine($"PROMPT: 《{prompt}》\n");
Console.WriteLine(result);
Console.ReadKey();