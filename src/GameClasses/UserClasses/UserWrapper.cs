using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
      public class UserWrapper 
      {
        IntPtr Handle;
        IntPtr ClassPtr;
          public UserWrapper()
          {
                Handle = Globals.Handle;
                ClassPtr = new AppModel()._userWrapper();
          }
            public IntPtr User() 
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x10);
            }

            public IntPtr Social()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x18);
            }
  
 
 

            public IntPtr Account()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x20);
            }
  
 
 

            public IntPtr Heroes()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x28);
            }
  
 
 

            public IntPtr TrainingCamp()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x30);
            }
  
 
 


            public IntPtr Artifacts()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x38);
            }
  
 
 
            public IntPtr BlackMarket()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x40);
            }
            public IntPtr Stages()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x48);
            }
            public IntPtr Village()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x50);
            }
            public IntPtr Forge()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x58);
            }
  
 
 

            public IntPtr MagicShop()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x60);
            }  
 
 

            public IntPtr Normalization()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x68);
            }  
 
 

            public IntPtr Shards()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x70);
            }  
 
 

            public IntPtr Inbox()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x78);
            }  
 
 

            public IntPtr Chat()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x80);
            }  
 
 

             public IntPtr Payment()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x88);
            } 
 
 

             public IntPtr Subscriptions()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x90);
            } 
 
 

             public IntPtr Quests()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x98);
            } 
 
 

             public IntPtr PeriodicQuests()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xA0);
            } 
 
 

             public IntPtr UserGameSettings()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xA8);
            } 
 
 

             public IntPtr Arena()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xB0);
            } 
 
 

             public IntPtr UserEffect()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xB8);
            } 
 
 

             public IntPtr Loyalty()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xC0);
            } 
 
 

             public IntPtr Capitol()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xC8);
            } 
 
 

             public IntPtr Messages()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xD0);
            } 
 
 

             public IntPtr LocalNotification()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xD8);
            } 
 
 

             public IntPtr AbTest()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xE0);
            } 
 
 

             public IntPtr HourlyGiftsWrapper()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xE8);
            } 
 
 

             public IntPtr CommonDataWrapper()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xF0);
            } 
 
 

             public IntPtr Alliance()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0xF8);
            } 
 
 

            public IntPtr StatsDataWrapper()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x100);
            } 
 
 

            public IntPtr MonthlyLoyaltyProgram()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x108);
            } 
 
 

            public IntPtr RateGame()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x110);
            } 
 
 

            public IntPtr HeroRatingWrapper()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x118);
            } 
 
 

            public IntPtr RecommendedQuests()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x120);
            } 
 
 

            public IntPtr GlobalEvents()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x128);
            } 
 
 

            public IntPtr SoloEvents()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x130);
            } 
 
 

            public IntPtr Tournaments()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x138);
            } 
 
 

            public IntPtr ReferralProgram()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x140);
            } 
 
 

            public IntPtr PromoCodes()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x148);
            } 
 
 

            public IntPtr Battle()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x150);
            } 
 
 

            public IntPtr AutoBattle()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x158);
            } 
 
 

            public IntPtr Fractions()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x160);
            } 
 
 

            public IntPtr DailyUpdates()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x168);
            } 
 
 

            public IntPtr Performance()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x170);
            } 
 
 

            public IntPtr ServerEvents()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x178);
            } 
 
 

            public IntPtr BattlePass()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x180);
            } 
 
 

            public IntPtr AutoOpen()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x188);
            } 
 
 

            public IntPtr Amazon()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x190);
            } 
 
 

            public IntPtr Arena3x3()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x198);
            } 
 
 

            public IntPtr Gifts()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1A0);
            } 
 
 

            public IntPtr ServerLogs()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1A8);
            } 
 
 

            public IntPtr DoomTower()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1B0);
            } 
 
 

            public IntPtr GiftLink()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1B8);
            } 
 
 

            public IntPtr CvcTournament()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1C0);
            } 
 
 

            public IntPtr CommunityRewards()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1C8);
            } 
 
 

            public IntPtr ReactivationProgram()
            {
                return ProcessApi.GetPointer(this.ClassPtr, 0x1D0);
            }
    }
}
