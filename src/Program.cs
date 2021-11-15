using Raid.gui;
using RaidHelper;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Lunar;
using System.Security.Cryptography;

namespace Raid
{
    public class Program
    {

        static void Main(string[] args)
        {
            AttachHandle attach = new AttachHandle();
            attach.Main();
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Auth());
            //Debugging();
            //AttachToRaid();
        }

        static void AttachToRaid()
        {
            Console.WriteLine("b");
            Process[] Processes = Process.GetProcesses();
            Console.WriteLine(Processes);
            if (false && true)
            {
            };
        }

        public void OpenPastLogin(string result)
        {
            if (result == "AllGood")
            {
                Auth currentForm = (Auth)Auth.ActiveForm;
                currentForm.Visible = false;
                Form maintab = new MainGui();
                maintab.Show();

            }
            else
            {
                MessageBox.Show("Wrong info");
            }
        }
        public static void Debugging()
        {
            if (Debugger.IsAttached) {
                Application.Exit();
            }
        }
    }
}
