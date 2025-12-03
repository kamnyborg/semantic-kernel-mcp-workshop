using ModelContextProtocol.Client;

var projectRoot = Directory.GetParent(AppContext.BaseDirectory)    // netX.Y
                             ?.Parent                                 // Debug
                             ?.Parent                                 // bin
                             ?.Parent
                             ?.Parent
                             ?.FullName;

// Step 1: Create the MCP client with stdio transport.

// Retrieve and display the list of available MCP tools.
// Step 2: retieve and output MCP tools