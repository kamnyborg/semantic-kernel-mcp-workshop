using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

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

var app = builder.Build();
var chatCompletionService = app.Services.GetRequiredService<IChatCompletionService>();

var prompt = "In a single run-on sentence, introduce a famous programmer.";

OpenAIPromptExecutionSettings settings = new()
{
    MaxTokens = 128
};

Console.WriteLine($"PROMPT: 《{prompt}》\n");

var results = await chatCompletionService.GetChatMessageContentsAsync(prompt, settings);

Console.WriteLine();

foreach (var res in results)
{
    Console.WriteLine(res);
}

Console.ReadKey();
