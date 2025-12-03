using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SemanticKernelWorkshop.Lab2.Plugins;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var builder = Host.CreateApplicationBuilder(args);

var modelDeploymentName = "gpt-4.1";
var azureOpenAIEndpoint = config.GetValue<string>("AZUREOPENAI_ENDPOINT");
var azureOpenAIApiKey = config.GetValue<string>("AZUREOPENAI_APIKEY");

builder.Services
    .AddKernel()
    .AddAzureOpenAIChatCompletion(
        modelDeploymentName,
        azureOpenAIEndpoint,
        azureOpenAIApiKey);

var pluginOptions = new PluginOptions();
builder.Configuration.GetSection(PluginOptions.PluginConfig).Bind(pluginOptions);

var app = builder.Build();

var chatCompletionService = app.Services.GetRequiredService<IChatCompletionService>();

var kernel = app.Services.GetRequiredService<Kernel>();
// Step 3: add the plugin

var prompt = "What time is it?";

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

Console.WriteLine($"PROMPT: 《{prompt}》\n");

var result = await chatCompletionService.GetChatMessageContentAsync(
   prompt,
   executionSettings: openAIPromptExecutionSettings,
   kernel: kernel);

Console.WriteLine();

Console.WriteLine(result);

Console.ReadKey();
