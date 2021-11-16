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

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
