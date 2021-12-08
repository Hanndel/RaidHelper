using RaidHelper.gui;
using System.Windows.Forms;

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
