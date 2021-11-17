using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{ 
	public class UserHeroData
	{
		public IntPtr ClassPtr = IntPtr.Zero;
		public IntPtr Handle = IntPtr.Zero;
		public UserHeroData()
		{
			Handle = Globals.Handle;
			ClassPtr = new UserWrapper().Heroes();
		}
		public IntPtr HeroById()
		{
			int[] HeroEntriesPtr = new int[] {0x58, 0x18};
			IntPtr HeroEntriePtr = ProcessApi.FindMultiLevelPointer(Handle, ClassPtr, HeroEntriesPtr);
			return HeroEntriePtr;
		}
		public async Task<List<HeroClass>> HeroesAsync()
        {
			List<Task<HeroClass>> HeroList = new List<Task<HeroClass>>();
			IntPtr HeroEntryPtr= HeroById();
			IntPtr HeroListBasePtr = ProcessApi.GetPointer(HeroEntryPtr, 0x18)+0x30;
			int HeroCount = (int)(long)ProcessApi.ReturnRead(HeroEntryPtr+0x20);
			for(int i = 0; i < HeroCount;)
            {
				IntPtr GetHero = HeroListBasePtr + (0x18 * i);
				int a = (int)(long)ProcessApi.GetPointer(ProcessApi.ReturnRead(GetHero),0x18);
				if (a > 0)
                {
					HeroList.Add(Task.Run(() => new HeroClass(ProcessApi.GetPointer(GetHero, 0x0))));
					i++;
                }
            }
			HeroClass[] result = await Task.WhenAll(HeroList);
			return result.ToList<HeroClass>();

		}
	}
}
