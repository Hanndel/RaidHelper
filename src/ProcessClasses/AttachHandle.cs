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
                catch (System.IndexOutOfRangeException e)
                {
                    IsAttached = false;
                }
            }
        }

        public async Task HeroesScan(TextBox formToHandle, ListView viewToHandle)
        {
            HeroesBox = formToHandle;
            HeroesBox.Invoke(ChangeHeroesStatus);
            UserHeroData Heroes = new UserHeroData(formToHandle, viewToHandle);
            await Heroes.HeroesAsync();
            viewToHandle.Invoke(() => viewToHandle.Items.Add(viewToHandle.Text));
            ArtifactsBox.Invoke(ChangeHeroesStatus);
        }
        public async Task ArtifactsScan(TextBox formToHandle, ListView viewToHandle)
        {
            ArtifactsBox = formToHandle;
            ArtifactsBox.Invoke(ChangeArtifactsStatus);
            ArtifactListClass ArtifactListClass = new ArtifactListClass(formToHandle, viewToHandle);
            await ArtifactListClass.ArtifactsAsync();
            viewToHandle.Invoke(() => viewToHandle.Items.Add(viewToHandle.Text));
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
        private async Task UpdateArtifacts()
        {

        }
        private async Task UpdateHeroes()
        {

        }
    }
}