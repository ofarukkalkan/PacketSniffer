using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVItem
	{
		public IKVItem(Dictionary<string, byte[]> map)
		{
			data = map;

		}

		public IKVItem(IKVItem other)
		{
			data = other.data;
		}
		public static List<IKVItem> parse(byte[] data, int bytesread)
		{
			byte[] end_token = new byte[] { 0x00, 0x00, 0x7a, 0x44 };

			List<IKVItem> list = new List<IKVItem>();

			Dictionary<string, byte[]> map = new Dictionary<string, byte[]>();
			int bytePos = 4;
			int rowCounter = 1;

			while (bytePos < bytesread)
			{
				byte[] currentRow = data.Skip(bytePos).Take(4).ToArray();
				map["data" + rowCounter] = currentRow;
				bytePos += 4;
				rowCounter++;

				if (Utils.startsWithCommand(currentRow, currentRow.Length, end_token))
				{
					IKVItem newItem = new IKVItem(map);
					list.Add(newItem);
					map.Clear();
				}

			}
			return list;
		}

		Dictionary<string, byte[]> data;

		public override string ToString()
		{
			string str = "";
			foreach (var row in data)
			{
				str += "[" + row.Key + "=" + BitConverter.ToString(row.Value) + "]";
			}
			return str;
		}
	}

}
