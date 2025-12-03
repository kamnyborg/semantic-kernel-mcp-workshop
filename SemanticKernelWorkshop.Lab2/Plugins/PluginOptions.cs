using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelWorkshop.Lab2.Plugins
{
    public class PluginOptions
    {
        public const string PluginConfig = "PluginConfig";

        public string BingApiKey { get; set; } = string.Empty;
    }
}
