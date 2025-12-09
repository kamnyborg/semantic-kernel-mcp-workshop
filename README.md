# Semantic Kernel and MCP workshop

Small workshop solution demonstrating using Microsoft Semantic Kernel together with the Model Context Protocol (MCP) to call external tools (another local .NET project) as plugins.

## Project structure (high level)
- `SemanticKernelWorkshop.Lab1` — how to set up Semantic Kernel with .NET
- `SemanticKernelWorkshop.Lab2` — Semantic Kernel plugin example with a plugin that returns the current date and time
- `SemanticKernelWorkshop.Lab3` — Set up a MCP server with a MCP tool that returns the current date and time
- `SemanticKernelWorkshop.Lab4` — Set up a MCP client that connects to the MCP server in the previous example
- `SemanticKernelWorkshop.Lab5` — Kernel + MCP integrated demo

## Prerequisites
- .NET 9 SDK installed and `dotnet` available on PATH.
- Visual Studio 2022 (or later) if you prefer the IDE.
- An Azure OpenAI deployment that matches the configured model name (default `gpt-4.1`).
- npx: `npm install -g npx`

## Configuration
- The app reads Azure values from environment variables or `appsettings.json`. Provide:
  - `AZUREOPENAI_ENDPOINT` — your Azure OpenAI endpoint (e.g., `https://your-resource.openai.azure.com/`)
  - `AZUREOPENAI_APIKEY` — API key for the Azure OpenAI resource
