# Semantic Kernel Workshop - Lab 2

## Goals:
- Add a plugin for Semantic Kernel
- Use plugins to provide more information to an LLM

## Instructions:
1. Add appsettings
2. Run the project and notice that the agent does not know what the current date and time is
3. Add the implementation for `Plugins/DateTimePlugin.cs`:

    [KernelFunction, Description("Get the current date and time")]
    public static string GetCurrentTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");      

4. Go to `Program.cs` for step 4:

    kernel.ImportPluginFromType<DateTimePlugin>("dateTimePlugin");

5. Run the project again and notice that the agent now knows the date and time