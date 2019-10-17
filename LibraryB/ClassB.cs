using System;

namespace LibraryB
{
    public static class ClassB
    {
        public static string GetJsonAssemblyInfos() => typeof(Newtonsoft.Json.JsonConverter).Assembly.FullName;

        public static Version GetJsonAssemblyVersion() => typeof(Newtonsoft.Json.JsonConverter).Assembly.GetName().Version;
    }
}
