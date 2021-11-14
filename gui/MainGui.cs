using System.Windows.Forms;

namespace Raid.gui
{
    public partial class MainGui : Form
    {
        public MainGui()
        {
            InitializeComponent();
        }

        private void MainGui_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
