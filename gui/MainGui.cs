using System;
using RaidHelper;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RaidHelper.gui
{
    public partial class MainGui : Form
    {
        private object ThisForm;
        private AttachHandle GuiAttach = new AttachHandle();
        private Dictionary<int, HeroClass> HeroDict;
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
            HeroDict = await Task.Run(() => GuiAttach.HeroesScan(this.HeroesScan, this.HeroListView));
        }
        private async void StartArtifactScan()
        {
            await Task.Run(() => GuiAttach.ArtifactsScan(this.ArtifactsScan, this.ArtifactListView));
        }
        private void OnClickArtifact(object sender, System.EventArgs e)
        {

            Console.WriteLine("Artifact "+sender);
        }
        private void OnClickHero(object sender, System.EventArgs e)
        {
            ListView Clicked = (ListView)sender;
            int id = Int32.Parse(Clicked.FocusedItem.SubItems[1].Text);
            Form heroform = new HeroWindow(HeroDict[id]);
            heroform.Show();

        }
    }
}
