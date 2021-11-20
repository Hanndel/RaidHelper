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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Auth());

        }

    }
}
