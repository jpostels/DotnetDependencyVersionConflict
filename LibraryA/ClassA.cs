using System;

namespace LibraryA
{
    public static class ClassA
    {
        public static string GetJsonAssemblyInfos() => typeof(Newtonsoft.Json.JsonConverter).Assembly.FullName;

        public static Version GetJsonAssemblyVersion() => typeof(Newtonsoft.Json.JsonConverter).Assembly.GetName().Version;
    }
}
