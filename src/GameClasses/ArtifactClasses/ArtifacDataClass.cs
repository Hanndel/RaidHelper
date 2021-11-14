using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
    class ArtifactData
    {
		public IntPtr Base = IntPtr.Zero;
		public IntPtr Handle = IntPtr.Zero;
		public ArtifactData(IntPtr handle, IntPtr ptr)
		{
			Base = ptr;
			Handle = handle;
		}
		public IntPtr Artifacts()
		{
			return GetPointer(0x28); 
		}
		private IntPtr GetPointer(int ptr)
        {
			IntPtr ClassPointer = IntPtr.Zero;
			byte[] Read = new byte[8];
			int BytesRead = 0;
			ProcessApi.ReadProcessMemory(Handle, Base + ptr, Read, Read.Length, out BytesRead);
			ClassPointer = (IntPtr.Size == 4) ? IntPtr.Add(new IntPtr(BitConverter.ToInt32(Read, 0)), 0) : ClassPointer = IntPtr.Add(new IntPtr(BitConverter.ToInt64(Read, 0)), 0);
			return ClassPointer;
		}
	}
}
