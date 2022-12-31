using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCSXLoader
{
    internal static class Manager
    {
        private static string pluginDir = Path.Combine(Environment.CurrentDirectory, "plugins");
        internal static string[] FindAllScripts()
        {
            if (!Directory.Exists(pluginDir)) { Directory.CreateDirectory(pluginDir); }
            return Directory.GetFiles(pluginDir, "*.csx", SearchOption.TopDirectoryOnly)
                .Concat(from dir in Directory.GetDirectories(pluginDir)
                        let scriptFile = Path.Combine(dir, "main.csx")
                        where File.Exists(scriptFile)
                        select scriptFile
                                ).ToArray();
        }
        internal static void LoadAllScript()
        {
            foreach (var script in FindAllScripts())
            {
                Console.WriteLine("加载脚本：" + script[pluginDir.Length..]);
                ScriptLoader.RunScript(script).Wait();
            }
        }
    }
}