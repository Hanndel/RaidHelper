using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidHelper
{
    public class UserHeroData
    {
        public IntPtr ClassPtr = IntPtr.Zero;
        public IntPtr Handle = IntPtr.Zero;
        private TextBox TextBox;
        private ListView ListView;

        public UserHeroData(TextBox textBox, ListView viewToHandle)
        {
            TextBox = textBox;
            ListView = viewToHandle;
            Handle = Globals.Handle;
            ClassPtr = new UserWrapper().Heroes();
        }
        public IntPtr HeroById()
        {
            IntPtr jumpOne = ProcessApi.GetPointer(ClassPtr, 0x58);
            IntPtr jumpTwo = ProcessApi.GetPointer(jumpOne, 0x18);
            return jumpTwo;
        }

        public async Task<Dictionary<int, HeroClass>> HeroesAsync()
        {
            IntPtr HeroEntryPtr = HeroById();
            IntPtr HeroListBasePtr = ProcessApi.GetPointer(HeroEntryPtr, 0x18) + 0x30;
            int HeroCount = (int)(long)ProcessApi.ReturnRead(HeroEntryPtr + 0x20);
            List<Task<HeroClass>> HeroList = new List<Task<HeroClass>>();
            for (int i = 0; i < HeroCount;)
            {
                IntPtr GetHero = HeroListBasePtr + (0x18 * i);
                int a = (int)(long)ProcessApi.GetPointer(ProcessApi.ReturnRead(GetHero), 0x18);
                if (a > 0)
                {
                    HeroList.Add(Task.Run(() => new HeroClass(ProcessApi.GetPointer(GetHero, 0x0))));
                    i++;
                }
            }
            HeroClass[] result = await Task.WhenAll(HeroList);
            List<HeroClass> HeroAsList = result.ToList();
            List<Task<ListViewItem>> AddTask = new List<Task<ListViewItem>>();
            Dictionary<int, HeroClass> HeroDict = new Dictionary<int, HeroClass>();
            foreach (HeroClass resultAs in HeroAsList)
            {
                ListViewItem row = new ListViewItem(resultAs._Type.name);
                row.SubItems.Add(resultAs.Id.ToString());
                AddTask.Add(Task.Run(() =>
                    ListView.Invoke(() =>
                        ListView.Items.Add(row)
                    )
                ));
                HeroDict.Add(resultAs.Id, resultAs);
            }
            await Task.WhenAll(AddTask);
            ListView.Invoke(() => ListView.Visible = true);
            ListView.Invoke(() => ListView.View = View.Details);
            return HeroDict;
        }
    }
}
