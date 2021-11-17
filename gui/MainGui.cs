using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using RaidHelper;

namespace Raid.gui
{
    public partial class MainGui : Form
    {
        private object ThisForm;
        private AttachHandle GuiAttach = new AttachHandle();
        public MainGui()
        {
            InitializeComponent();
            ThisForm = this;
            AttachToRaid();
        }

        private void MainGui_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ArtifactClickButton(object sender, System.EventArgs e)
        {
            this.ArtifactListView.Visible = true;
            this.HeroListView.Visible = false;
        }
        private void HeroesClickButton(object sender, System.EventArgs e)
        {
            this.HeroListView.Visible = true;
            this.ArtifactListView.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void MainGui_Load(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, System.EventArgs e)
        {

        }
        private async void AttachToRaid()
        {

            await Task.Run(() => GuiAttach.AttachToRaid(this.RaidInjectionStatus));
            StartHeroesScan();
            StartArtifactScan();
        }
        private  async void StartHeroesScan()
        {
            await Task.Run(() => GuiAttach.HeroesScan(this.HeroesScan, this.HeroListView));
        }
        private async void StartArtifactScan()
        {
            await Task.Run(() => GuiAttach.ArtifactsScan(this.ArtifactsScan, this.ArtifactListView));
        }
    }
}
