using System;
using System.Windows.Forms;
using RaidHelper;
using RaidHelper.Config;
using System.Threading;
using System.Threading.Tasks;

namespace Raid.gui
{
    public partial class Auth : Form
    {
        private Form ThisForm;
        private string LoginResult;

        public Auth()
        {
            InitializeComponent();
            ThisForm = this;
            Settings settings = new Settings();
            if (settings.AutoLog)
            {
                AutoLogWrapper();
            }
        }
        //User
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Password
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //Log-in
        private async void button2_Click(object sender, EventArgs e)
        {
            LoginResult = await LogRequest();
            OpenPastLogin();
        }

        //Remember
        private void CheckBoxRemember(object sender, EventArgs e)
        {

        }
        //Auto log-in
        private void CheckBoxAutoLog(object sender, EventArgs e)
        {
            SettingsHandler _nothing = new SettingsHandler("AutoLog", new string[0], true);
        }
        private void OpenPastLogin()
        {
            if (LoginResult.Equals("AllGood"))
            {
                Globals.Logged = true;
                ThisForm.Visible = false;
                Form maintab = new MainGui();
                maintab.Show();
            }
            else
            {
                MessageBox.Show("Wrong info");
            }
        }
        private async void AutoLogWrapper()
        {
            await Task.Run(() => AutoLog());
        }
        private async void AutoLog()
        {
            Thread.Sleep(5000);
            if (Globals.Logged == false)
            {
                LoginResult = await LogRequest();
                ThisForm.Invoke(OpenPastLogin);
            }
        }

        private async Task<string> LogRequest()
        {
            NetHandler netHandler = new NetHandler();
            string hwid;
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            var resultSender = netHandler.SenderAsync(textBox1.Text, new LocalEncrypt(textBox2.Text).Encrypt(), hwid);
            var result = await resultSender;
            SettingsHandler settings = this.checkBox1.Checked ? new SettingsHandler("Remember", new string[] {textBox1.Text, textBox2.Text}, true) : new SettingsHandler("Forget", new string[0], false);
            return result;
        }
    }
}
