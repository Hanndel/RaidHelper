using System;
using System.Windows.Forms;
using RaidHelper;

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
        private void button2_Click(object sender, EventArgs e)
        {
            NetHandler ak = new NetHandler();
            string hwid;
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            Program main = new Program();
            main.OpenPastLogin(ak.Sender(textBox1.Text, textBox2.Text, hwid));


        }

        //Remember
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Auto log-in
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }



    }
}
