# Semantic Kernel Workshop - Lab 1

## Goals:
- Understand the setup of Semantic Kernel
- Understand how to use Semantic Kernel to communicate with Azure OpenAI LLM
- Use prompts and receive responses

## Instructions:
1. Add appsettings
2. Go to Program.cs and add the following code to Step 2:

```csharp
builder.Services
    .AddKernel()
    .AddAzureOpenAIChatCompletion(
        modelDeploymentName,
        azureOpenAIEndpoint,
        azureOpenAIApiKey);
```

3. Go to Program.cs and add the following code to Step 3:

```csharp
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

4. (Optional) Test with different prompts or agents
5. (Optional) Add handling for history
```



