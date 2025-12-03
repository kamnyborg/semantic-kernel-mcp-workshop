# Semantic Kernel Workshop - Lab 5

## Goals: 
- Let's put everything together! Create an MCP client, and use an MCP tool as a plugin in the agent.

## Instructions:
1. Launch the project as-is, and see what happens
2. Go to Program.cs and add the following code on line x:
```csharp
kernel.Plugins.AddFromFunctions("UtcTimeTool", tools.Select(aiFunction => aiFunction.AsKernelFunction()));
```
Notice how the agent now can fetch the current date and time to answer such questions

3. Challenge: create a new MCP tool that fetches weather data from a public API, and integrate it into the agent
