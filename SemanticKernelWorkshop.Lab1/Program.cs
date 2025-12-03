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

// Step 2: Register Semantic Kernel services

var app = builder.Build();
var chatCompletionService = app.Services.GetRequiredService<IChatCompletionService>();

var prompt = "In a single run-on sentence, introduce a famous programmer.";

// Step 3: Add prompt execution
