﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaidHelper.Config;
using Raid.gui;

namespace RaidHelper
{
    public class SettingsHandler
    {
        Settings settings = new Settings();
        public SettingsHandler(string mode, string[] data, bool isIt)
        {
            data = data.Length > 0 ? data : new string[] { };
            isIt = isIt ? true : false;
           switch (mode)
            {
                case "Remember":
                    settings.User = data[0];
                    settings.Password = new LocalEncrypt(data[1]).Encrypt();
                    settings.Remember = isIt;
                    settings.Save();
                    break;
                case "Forget":
                    settings.User = data[0];
                    settings.Password = data[1];
                    settings.Remember = isIt;
                    settings.Save();
                    break;
                case "AutoLog":
                    settings.AutoLog = isIt;
                    settings.Save();
                    break;
                default:
                    break;
                    

            }
        }

    }
}