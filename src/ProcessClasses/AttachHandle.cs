using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Lunar;

namespace RaidHelper
{
    class AttachHandle
    {
        private bool IsAttached = false;
        private bool GameAssembly = false;
        private TextBox AttachBox;
        private TextBox HeroesBox;
        private TextBox ArtifactsBox;
        private Process RaidProc;
        private Dictionary<int, HeroClass> HeroDict;
        private Dictionary<int, ArtifactClass> ArtifactDict;


        public void AttachToRaid(TextBox formToHandle)
        {
            AttachBox = formToHandle;
            while (!IsAttached)
            {
                Thread.Sleep(1000);
                try
                {
                    RaidProc = Process.GetProcessesByName("Raid")[0];
                    AttachBox.Invoke(ChangeRaidStatus);
                    IsAttached = true;
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
            }
            while (!GameAssembly)
            {
                Thread.Sleep(1000);
                try
                {
                    Globals.Handle = ProcessApi.OpenProcess(ProcessApi.ProcessAccessFlags.All, false, RaidProc.Id);
                    Globals.Base = ProcessApi.GetModuleBaseAddress(RaidProc.Id, "GameAssembly.dll");
                    if (Globals.Base != IntPtr.Zero) { GameAssembly = true; }

                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (System.IndexOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    IsAttached = false;
                }
            }
        }

        public async Task<Dictionary<int, HeroClass>> HeroesScan(TextBox formToHandle, ListView viewToHandle)
        {
            HeroesBox = formToHandle;
            HeroesBox.Invoke(ChangeHeroesStatus);
            UserHeroData Heroes = new UserHeroData(formToHandle, viewToHandle);
            HeroDict = await Heroes.HeroesAsync();
            ArtifactsBox.Invoke(ChangeHeroesStatus);
            return HeroDict;

        }

        public async Task ArtifactsScan(TextBox formToHandle, ListView viewToHandle)
        {
            ArtifactsBox = formToHandle;
            ArtifactsBox.Invoke(ChangeArtifactsStatus);
            ArtifactListClass ArtifactListClass = new ArtifactListClass(formToHandle, viewToHandle);
            await ArtifactListClass.ArtifactsAsync();
            ArtifactsBox.Invoke(ChangeArtifactsStatus);
        }

        private void ChangeRaidStatus()
        {
            AttachBox.Text = "Raid process found!";
        }

        private void ChangeHeroesStatus()
        {
            HeroesBox.Text = "Scanning Heroes" == HeroesBox.Text ? "Heroes finished scanning!": "Scanning Heroes";
        }

        private void ChangeArtifactsStatus()
        {
            ArtifactsBox.Text = "Scanning Artifacts" == ArtifactsBox.Text ? "Artifacts finished scanning!" : "Scanning Artifacts";
        }
    }
}