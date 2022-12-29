using System.Reflection;

namespace PluginMain
{
    public static class Plugin
    {
        public static void OnPostInit()
        {

            _ = Assembly.Load("Microsoft.CodeAnalysis.CSharp");
            LLCSXLoader.Manager.LoadAllScript();
        }
    }
}