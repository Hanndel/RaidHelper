using System;
using System.Linq;
using System.Text;
using RaidHelper.Config;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidHelper
{
    public class AutoLogin
    {
        public AutoLogin()
        {

        }
        public static async void AutoLog()
        {
            Settings settings = new Settings();
            if (settings.AutoLog)
            {
                await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
                {
                    await Task.Delay(5000);
                    if (settings.AutoLog && !Globals.Logged)
                    {
                        NetHandler netHandler = new NetHandler();
                        string hwid;
                        hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
                        var resultSender = netHandler.SenderAsync(settings.User, settings.Password, hwid);
                        var result = await resultSender;
                        Program main = new Program();
                        main.OpenPastLogin(result);
                    }
                });
            }
            
        }
    }
}
