using System;
using System.Windows.Forms;
using RaidHelper;
using System.Threading.Tasks;

namespace Raid.gui
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
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
            NetHandler netHandler = new NetHandler();
            string hwid;
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            Program main = new Program();
            var resultSender = netHandler.SenderAsync(textBox1.Text, new LocalEncrypt(textBox2.Text).Encrypt(), hwid);
            var result = await resultSender;
            SettingsHandler ak = checkBox1.Checked ? new SettingsHandler("Remember", new string[] { textBox1.Text, textBox2.Text}, true) : new SettingsHandler("Forget", new string[] { "","" }, false); 
            main.OpenPastLogin(result);
            

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
    }
}
