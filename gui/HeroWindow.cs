using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidHelper.gui
{
    public partial class HeroWindow : Form
    {
        HeroClass HeroSelected;
        public HeroWindow(HeroClass Hero)
        {
            InitializeComponent();
            HeroSelected = Hero;
        }

        private void ToHellHades(object sender, System.EventArgs e)
        {
            string uri = "https://hellhades.com/champions/"+HeroSelected._Type.name.ToLower().Replace(" ", "-")+"/";
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
