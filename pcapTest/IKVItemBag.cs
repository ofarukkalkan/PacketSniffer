using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVItemBag
	{
		public IKVItemBag(byte[] id, IKVVec3Byte pos)
		{
			this.id = id;
			this.pos = pos;
		}

		public void setItem(int index, IKVItem item)
		{
			items[index] = item;
		}

		public IKVItem takeItem(int index)
		{
			if (index < items.Count)
			{
				IKVItem item = items[index];
				items[index] = null;
				return item;
			}
			else return null;
		}

		public static IKVItemBag parse(byte[] data, int bytesread)
		{
			if (bytesread < 24)
				return null;

			byte[] id = data.Skip(8).Take(4).ToArray();
			byte[] x = data.Skip(12).Take(4).ToArray();
			byte[] z = data.Skip(16).Take(4).ToArray();
			byte[] y = data.Skip(20).Take(4).ToArray();

			IKVVec3Byte pos = new IKVVec3Byte(x, y, z);
			IKVItemBag bag = new IKVItemBag(id, pos);
			return bag;
		}
		public string listItems()
		{
			string str = "";
			foreach (var item in items)
			{
				str += "[" + item.Key + " : " + item.Value.ToString() + "]";
			}
			return str;
		}
		public override string ToString()
		{
			return "bag -> id : " + BitConverter.ToString(id) + " " + pos.ToString();
		}

		public byte[] id;
		public IKVVec3Byte pos;
		public Dictionary<int, IKVItem> items;
	}
}
