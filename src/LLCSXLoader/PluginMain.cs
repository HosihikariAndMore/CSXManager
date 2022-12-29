using System.Reflection;

namespace PluginMain
{
    public static class Plugin
    {
        public static void OnPostInit()
        {
            LLCSXLoader.Manager.LoadAllScript();
        }
    }
}