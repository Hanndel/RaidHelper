using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RaidHelper
{
    class ArtifactListClass
    {
		public IntPtr Base = IntPtr.Zero;
		public IntPtr Handle = IntPtr.Zero;
		private TextBox TextBox;
		private ListView ListView;
		public ArtifactListClass(TextBox textBox, ListView viewToHandle)
		{
			TextBox = textBox;
			ListView = viewToHandle;
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
		public async Task ArtifactsAsync()
		{
			int Count = (int)ReturnRead(Handle, this.ArtifactsPointerList() + 0x18);
			List<Task<ArtifactClass>> ArtifactReturning = new List<Task<ArtifactClass>>();
			for (int i = 0; i < Count; i++)
			{
				int position = (0x20 + (i * 0x8));
				IntPtr validPtr = ReturnRead(Handle, this.ArtifactsPointerList() + position);
				if (validPtr != IntPtr.Zero)
				{
					ArtifactReturning.Add(Task.Run(() => new ArtifactClass(validPtr)));
				}
			}
			ArtifactClass[] result = await Task.WhenAll(ArtifactReturning);
			List<ArtifactClass> resultAsList = result.ToList<ArtifactClass>();
			List<Task<ListViewItem>> AddTask = new List<Task<ListViewItem>>();
			ListView.Invoke(() => ListView.Visible = false);
			foreach (ArtifactClass resultAs in resultAsList)
            {
				ListViewItem row = new ListViewItem(resultAs.setKindId);
				AddTask.Add(Task.Run(() => 
					ListView.Invoke(() => 
						ListView.Items.Add(row)
					)
				));
			}
			await Task.WhenAll(AddTask);
			ListView.Invoke(() =>  ListView.Visible = true);

			ListView.Invoke(() => ListView.View = View.Details);
		}
		private void AddColumns()
		{
			ListView.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
			ListView.Columns.Add("Item Column", -2, HorizontalAlignment.Left);

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
