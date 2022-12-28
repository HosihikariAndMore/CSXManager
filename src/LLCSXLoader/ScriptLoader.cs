using Dotnet.Script.Core;
using Dotnet.Script.Core.Commands;
using Dotnet.Script.DependencyModel.Logging;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace LLCSXLoader
{
    internal static class ScriptLoader
    {
        internal static async Task RunScript(string path)
        {
            var scriptFile = new ScriptFile(path);
            var optimizationLevel = OptimizationLevel.Release;
            var scriptArguments = Environment.GetCommandLineArgs();//app.RemainingArguments.Concat(argsAfterDoubleHyphen).ToArray();
                                                                   //if (infoOption.HasValue())
                                                                   //{
                                                                   //    var environmentReporter = new EnvironmentReporter(logFactory);
                                                                   //    await environmentReporter.ReportInfo();
                                                                   //    return 0;
                                                                   //}

            var logFactory = CreateLogFactory();
            if (scriptFile.HasValue)
            {
                var fileCommandOptions = new ExecuteScriptCommandOptions
                (
                    scriptFile,
                    scriptArguments,
                    optimizationLevel,
                    Array.Empty<string>()/*packageSources.Values?.ToArray()*/,
                    false,
                    false
                )
                {
                    AssemblyLoadContext = new ScriptAssemblyLoadContext("ScriptAssemblyLoadContext" + path.GetHashCode(), true)
                };
                var fileCommand = new ExecuteScriptCommand(ScriptConsole.Default, logFactory);
                await fileCommand.Run<int, CommandLineScriptGlobals>(fileCommandOptions);
            }
        }
        private static LogFactory CreateLogFactory()
        {
            return type =>
            {
                return (level, message, exception) =>
                {
                    Console.WriteLine(message);
                };
            };
        }
    }
}