using System.Reflection;

namespace PluginMain
{
    public static class Plugin
    {
        public static void OnPostInit()
        {
            LiteCSXLoader.Manager.LoadAllScript();
        }
    }
}