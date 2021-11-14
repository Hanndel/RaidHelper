using System;
using System.Diagnostics;

namespace RaidHelper
{
	public class AppModel
	{

		public IntPtr Base = IntPtr.Zero;
		public IntPtr Handle = IntPtr.Zero;
		public AppModel()
        {
			int[] AppDataPointers = new int[] { 0x260, 0x20, 0x28, 0x70, 0xb8, 0x8, 0x0 };
			Base = ProcessApi.FindDMAAddy(Globals.Handle, (IntPtr)(Globals.Base + 0x032E8EA8), AppDataPointers);
			Handle = Globals.Handle;
		}


		public IntPtr Settings() {
			return ProcessApi.GetPointer(this.Base, 0x20);
		}

		public IntPtr ServiceMessages()
		{
			return ProcessApi.GetPointer(this.Base, 0x28);
		}

			
		public IntPtr Arena3X3Manager()
		{
			return ProcessApi.GetPointer(this.Base, 0x30);
		}

			
		public IntPtr    AnalyticsConfiguration()
		{
			return ProcessApi.GetPointer(this.Base, 0x38);
		}

			
		public IntPtr    PaymentsAutoRefresh()
		{
			return ProcessApi.GetPointer(this.Base, 0x40);
		}

			

		public IntPtr k__BackingField()
		{
			return ProcessApi.GetPointer(this.Base, 0x48);
		}

			
		public IntPtr   Time()
		{
			return ProcessApi.GetPointer(this.Base, 0x90);
		}

			
		public IntPtr     LazyData()
		{
			return ProcessApi.GetPointer(this.Base, 0x98);
		}

			
		public IntPtr     TextResources()
		{
			return ProcessApi.GetPointer(this.Base, 0xA0);
		}

			
		public IntPtr     Auth()
		{
			return ProcessApi.GetPointer(this.Base, 0xA8);
		}

			
		public IntPtr     DeprecatedAuth()
		{
			return ProcessApi.GetPointer(this.Base, 0xB0);
		}

			
		public IntPtr     Chat()
		{
			return ProcessApi.GetPointer(this.Base, 0xB8);
		}
	
			
		public IntPtr     UserNotes()
		{
			return ProcessApi.GetPointer(this.Base, 0xC0);
		}
		
			
		public IntPtr    AllianceNotes()
		{
			return ProcessApi.GetPointer(this.Base, 0xC8);
		}

			
		public IntPtr    ShortUserNotes()
		{
			return ProcessApi.GetPointer(this.Base, 0xD0);
		}
		
			
		public IntPtr    Online()
		{
			return ProcessApi.GetPointer(this.Base, 0xD8);
		}
		
			
		public IntPtr    Amazon()
		{
			return ProcessApi.GetPointer(this.Base, 0xE0);
		}
		
			
		public IntPtr    SoundVolumeDetectorService()
		{
			return ProcessApi.GetPointer(this.Base, 0xE8);
		}
		
			
		public IntPtr    NetEase()
		{
			return ProcessApi.GetPointer(this.Base, 0xF0);
		}
		
			
		public IntPtr    BattleStateNotifier()
		{
			return ProcessApi.GetPointer(this.Base, 0xF8);
		}
		
			
		public IntPtr    CvcRequest()
		{
			return ProcessApi.GetPointer(this.Base, 0x100);
		}
			
			
		public IntPtr    CvcResponse()
		{
			return ProcessApi.GetPointer(this.Base, 0x108);
		}
		
			
		public IntPtr  Journals()
		{
			return ProcessApi.GetPointer(this.Base, 0x110);
		}
		
			
		public IntPtr    AutoRefresh()
		{
			return ProcessApi.GetPointer(this.Base, 0x118);
		}
			
			
		public IntPtr  Localizer()
		{
			return ProcessApi.GetPointer(this.Base, 0x120);
		}
		
			
		public IntPtr    ExternalStorage()
		{
			return ProcessApi.GetPointer(this.Base, 0x128);
		}
		
			
		public IntPtr  Advertisement()
		{
			return ProcessApi.GetPointer(this.Base, 0x130);
		}
	
			
		public IntPtr  FbManager()
		{
			return ProcessApi.GetPointer(this.Base, 0x138);
		}
		
			
		public IntPtr  Clipboard()
		{
			return ProcessApi.GetPointer(this.Base, 0x140);
		}
		
			
		public IntPtr  Client()
		{
			return ProcessApi.GetPointer(this.Base, 0x148);
		}
		
			
		public IntPtr  Config()
		{
			return ProcessApi.GetPointer(this.Base, 0x150);
		}
		
			
		public IntPtr  _userWrapper()
		{
			return ProcessApi.GetPointer(this.Base, 0x168);
		}
	
			
		public IntPtr  _userThread()
		{
			return ProcessApi.GetPointer(this.Base, 0x170);
		}

			
		public IntPtr  _mainThread()
		{
			return ProcessApi.GetPointer(this.Base, 0x178);
		}
		
			
		public IntPtr  _ticks()
		{
			return ProcessApi.GetPointer(this.Base, 0x180);
		}

			
		public IntPtr    Events()
		{
			return ProcessApi.GetPointer(this.Base, 0x188);
		}

			
		internal IntPtr UserEvents()
		{
			return ProcessApi.GetPointer(this.Base, 0x190);
		}

			
		internal IntPtr CmdQueue()
		{
			return ProcessApi.GetPointer(this.Base, 0x198);
		}

			
		public IntPtr  _configuration()
		{
			return ProcessApi.GetPointer(this.Base, 0x1A0);
		}

			
		public IntPtr  _projectConfiguration()
		{
			return ProcessApi.GetPointer(this.Base, 0x1E0);
		}

			
		public IntPtr  _runningCommands()
		{
			return ProcessApi.GetPointer(this.Base, 0x1E8);
		}
			
		public IntPtr  _commandsSession()
		{
			return ProcessApi.GetPointer(this.Base, 0x1F0);
		}


	}
}