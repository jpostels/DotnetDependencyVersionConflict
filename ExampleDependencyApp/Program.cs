using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using LibraryA;
using LibraryB;

namespace ExampleDependencyApp
{
    public static class Program
    {
        public static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Console.WriteLine("JSON A: " + ClassA.GetJsonAssemblyInfos());

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("JSON B: " + ClassB.GetJsonAssemblyInfos());

            Debug.Assert(ClassA.GetJsonAssemblyVersion().Major != ClassB.GetJsonAssemblyVersion().Major,
                "Expected: A " + ClassA.GetJsonAssemblyVersion() + " !=  B " + ClassB.GetJsonAssemblyVersion());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Equals("Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"))
            {
                return Assembly.LoadFile(
                    Path.Combine(
                        AppContext.BaseDirectory,
                        "json11\\newtonsoft.json.dll"));
            }

            if (args.Name.Equals("Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"))
            {
                return Assembly.LoadFile(
                    Path.Combine(
                        AppContext.BaseDirectory,
                        "json12\\newtonsoft.json.dll"));
            }

            return default;
        }
    }
}
