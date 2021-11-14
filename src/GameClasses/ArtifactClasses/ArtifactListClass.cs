using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
    class ArtifactListClass
    {
		public IntPtr Base = IntPtr.Zero;
		public IntPtr Handle = IntPtr.Zero;
		public ArtifactListClass()
		{
			int[] ArtifactListPointers = new int[] { 0x18, 0xb8, 0x8, 0x20, 0x0 };
			Base = ProcessApi.FindDMAAddy(Globals.Handle, (IntPtr)(Globals.Base + 0x0358B990), ArtifactListPointers);
			Handle = Globals.Handle;
		}
		public IntPtr ArtifactsPointerList()
		{
			IntPtr NewClass = IntPtr.Zero;
			NewClass = ProcessApi.FindDMAAddy(Handle, (IntPtr)(Base+0x10), new int[] {0x18, 0x10, 0x10, 0x0});
			return NewClass;
		}
		public List<ArtifactClass> Artifacts()
		{
			int Count = (int)ReturnRead(Handle, this.ArtifactsPointerList() + 0x18);
			List<ArtifactClass> ArtifactReturning = new List<ArtifactClass>();
			for (int i = 0; i < Count; i++)
            {
				int position = (0x20 + (i * 0x8));
				IntPtr validPtr = ReturnRead(Handle, this.ArtifactsPointerList() + position);
				if (validPtr != IntPtr.Zero)
                {
					ArtifactReturning.Add(new ArtifactClass(validPtr));

				}
			}
			return ArtifactReturning;
		}

		private IntPtr BytesToHexa(byte[] array)
        {
			IntPtr somethingToReturn = (IntPtr.Size == 4) ? IntPtr.Add(new IntPtr(BitConverter.ToInt32(array, 0)), 0) : somethingToReturn = IntPtr.Add(new IntPtr(BitConverter.ToInt64(array, 0)), 0);
			return somethingToReturn;
		}

		private IntPtr ReturnRead(IntPtr handle, IntPtr ptr)
		{
			byte[] Read = new byte[8];
			int BytesRead = 0;
			ProcessApi.ReadProcessMemory(handle, ptr, Read, Read.Length, out BytesRead);
			return BytesToHexa(Read);
		}
	}
}
