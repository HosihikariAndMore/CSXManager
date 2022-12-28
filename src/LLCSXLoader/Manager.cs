using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLCSXLoader
{
    internal static class Manager
    {
        private static string pluginDir = Path.Combine(Environment.CurrentDirectory, "plugins");
        internal static string[] FindAllScripts()
        {
            if (!Directory.Exists(pluginDir)) { Directory.CreateDirectory(pluginDir); }
            var files = Directory.GetFiles(pluginDir, "*.csx", SearchOption.AllDirectories);
            return files;
        }
        internal static void LoadAllScript()
        {
            foreach (var script in FindAllScripts())
            {
                ScriptLoader.RunScript(script).Wait();
            }
        }
    }
}