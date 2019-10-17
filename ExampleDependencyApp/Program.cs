using System;
using System.Diagnostics;
using LibraryA;
using LibraryB;

namespace ExampleDependencyApp
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("JSON A: " + ClassA.GetJsonAssemblyInfos());

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("JSON B: " + ClassB.GetJsonAssemblyInfos());

            Debug.Assert(ClassA.GetJsonAssemblyVersion().Major != ClassB.GetJsonAssemblyVersion().Major,
                "Expected: A " + ClassA.GetJsonAssemblyVersion() + " !=  B " + ClassB.GetJsonAssemblyVersion());
        }
    }
}
