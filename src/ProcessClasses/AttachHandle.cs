using Lunar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace RaidHelper
{
    class AttachHandle
    {
        private bool IsAttached = false;
        private TextBox AttachBox;
        private TextBox HeroesBox;
        private TextBox ArtifactsBox;
        private Process RaidProc;
        public int time { get; set; }
        private Dictionary<int, HeroClass> HeroDict;
        private string path;
        //private Dictionary<int, ArtifactClass> ArtifactDict;


        public void AttachToRaid(TextBox formToHandle)
        {
            //LoadRaid();

            AttachBox = formToHandle;

            AttachToProcess();

            FindGameAssembly();

            FindLastDLL();

            Process thisProcess = Process.GetCurrentProcess();
            string path = thisProcess.MainModule.FileName.Substring(0, thisProcess.MainModule.FileName.IndexOf("C1CHelper"));

            InjectMono();

            InjectMscorlib();

            string host = @"D:\vs-WorkSpace\Raid 2\x64\Debug\HostingDll.dll";
            InjectDLL(host, RaidProc);
            //Injection.Main();
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
            HeroesBox.Text = "Scanning Heroes" == HeroesBox.Text ? "Heroes finished scanning!" : "Scanning Heroes";
        }

        private void ChangeArtifactsStatus()
        {
            ArtifactsBox.Text = "Scanning Artifacts" == ArtifactsBox.Text ? "Artifacts finished scanning!" : "Scanning Artifacts";
        }
        public static bool InjectDLL(string dllpath, Process process)
        {

            Process proc = process;

            if (proc.Handle != IntPtr.Zero)
            {

                IntPtr loc = ProcessApi.VirtualAllocEx(proc.Handle, IntPtr.Zero, 260, ProcessApi.AllocationType.Commit | ProcessApi.AllocationType.Reserve,
                    ProcessApi.MemoryProtection.ReadWrite);

                if (loc.Equals(0))
                {
                    return false;
                }

                IntPtr bytesRead = IntPtr.Zero;

                bool result = ProcessApi.WriteProcessMemory(proc.Handle, loc, dllpath.ToCharArray(), dllpath.Length, out bytesRead);

                if (!result || bytesRead.Equals(0))
                {
                    return false;
                }

                IntPtr loadlibAddy = ProcessApi.GetProcAddress(ProcessApi.GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                loadlibAddy = ProcessApi.GetProcAddress(ProcessApi.GetModuleBaseAddress(proc.Id, "KERNEL32.DLL"), "LoadLibraryA");

                IntPtr hThread = ProcessApi.CreateRemoteThread(proc.Handle, IntPtr.Zero, 0, loadlibAddy, loc, 0, out _);


                if (!hThread.Equals(0))

                    ProcessApi.CloseHandle(hThread);
                else return false;
            }
            else return false;

            return true;
        }

        private void LoadRaid()
        {
            try
            {
                RaidProc = Process.GetProcessesByName("Raid")[0];
                RaidProc.Kill();
                Thread.Sleep(2000);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.IndexOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
            }
        }

        private void AttachToProcess()
        {

            bool executed = false;
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
                    if (!executed)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = false;
                        startInfo.UseShellExecute = false;
                        startInfo.FileName = @"cmd.exe";
                        startInfo.Arguments = @"/c D:\Raid\Plarium\PlariumPlay\PlariumPlay.exe --args -gameid=101 -tray-start";
                        Process.Start(startInfo);
                        executed = true;
                    }
                }
            }
        }
        private void FindGameAssembly()
        {
            bool GameAssembly = false;
            while (!GameAssembly)
            { 
                Thread.Sleep(1000);
                try
                {
                    Globals.Base = ProcessApi.GetModuleBaseAddress(RaidProc.Id, "GameAssembly.dll");

                    if (Globals.Base != IntPtr.Zero)
                    {
                        Globals.Handle = ProcessApi.OpenProcess(ProcessApi.ProcessAccessFlags.All, false, RaidProc.Id);
                        GameAssembly = true;
                    }

                }
            #pragma warning disable CS0168 // Variable is declared but never used
                catch (System.IndexOutOfRangeException e)
            #pragma warning restore CS0168 // Variable is declared but never used
                {
                    IsAttached = false;
                }
            }
        }

        //ZFProxyWeb.dll
        private void FindLastDLL()
        {
            bool LastDll = false;
            while (!LastDll)
            {
                Thread.Sleep(1000);
                try
                {
                    IntPtr LastDllInt = ProcessApi.GetModuleBaseAddress(RaidProc.Id, "ZFProxyWeb.dll");

                    if (LastDllInt != IntPtr.Zero)
                    {
                        LastDll = true;
                    }

                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (System.IndexOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    IsAttached = false;
                }
            }
        }

        private void InjectMono()
        {
            var dllFilePathMono = path + @"Dll\mono-2.0-bdwgc.dll";
            InjectDLL(dllFilePathMono, RaidProc);
        }

        private void InjectMscorlib()
        {
            var dllFilePathMscorlib = path + @"Managed\mscorlib.dll";
            InjectDLL(dllFilePathMscorlib, RaidProc);
        }
        private void TestingExports()
        {
            //Il2Cpp.InitAssemblies();
        }
    }
}