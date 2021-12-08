using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.IO.Compression;
using System.Reflection;
using Mono.Cecil;
using SharpMonoInjector;

namespace RaidHelper
{
    class Injection
    {
        public static void Main()
        {
            var monoInjector = new Injector("Raid");

            var dll = AssemblyDefinition.ReadAssembly(@"D:\vs-WorkSpace\Raid 2\bin\Debug\net6.0-windows10.0.22000.0\C1CHelperDll\C1CHelperDll.dll");
            var rand = Guid.NewGuid().ToString().Replace("-", "");
            dll.Name.Name += rand;
            dll.MainModule.Name += rand;
            dll.MainModule.Types.ToList().ForEach(t => t.Namespace += rand);
            var dllBytes = new Byte[0];
            using (var newDll = new MemoryStream())
            {
                dll.Write(newDll);
                dllBytes = newDll.ToArray();
            }
            monoInjector.Inject(dllBytes, dll.Name.Name, "Init", "Setup");
        }
    }
}
