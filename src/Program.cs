using System;
using Raid.gui;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace RaidHelper
{
    public class Program
    {

        static void Main(string[] args)
        {
            AttachHandle attach = new AttachHandle();
            attach.Main();
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoLogin.AutoLog();
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
            if (result.Equals("AllGood"))
            {
                Globals.Logged = true;
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
