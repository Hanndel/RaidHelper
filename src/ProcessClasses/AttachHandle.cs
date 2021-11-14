using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Lunar;

namespace RaidHelper
{
    class AttachHandle
    {
        [STAThread]
        public void Main()
        {

            Process RaidProc = Process.GetProcessesByName("Raid")[0];
            if (RaidProc != null)
            {

                Globals.Handle = ProcessApi.OpenProcess(ProcessApi.ProcessAccessFlags.All, false, RaidProc.Id);
                Globals.Base = ProcessApi.GetModuleBaseAddress(RaidProc.Id, "GameAssembly.dll");
                AppModel AppModel = new AppModel();
                ArtifactListClass ArtifactListClass = new ArtifactListClass();
                List<HeroClass> Heroes = new UserHeroData().Heroes();

                List<ArtifactClass> Artefactos = ArtifactListClass.Artifacts();
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}