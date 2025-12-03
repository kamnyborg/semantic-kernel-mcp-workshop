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
// Steg 2: legg til plugin her!

var prompt = "What time is it in Norway right now? My current timezone {{dateTimePlugin.timeZone}} and current date and time is {{dateTimePlugin.dateWithTime}}";

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    MaxTokens = 250
};

Console.WriteLine($"PROMPT: 《{prompt}》\n");

var results = await chatCompletionService.GetChatMessageContentsAsync(prompt, openAIPromptExecutionSettings);

Console.WriteLine();

foreach (var res in results)
{
    Console.WriteLine(res);
}

Console.ReadKey();
