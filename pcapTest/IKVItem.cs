using System;
using System.Collections.Generic;
using System.Linq;

namespace pcapTest
{
	public class IKVItem
	{
		public Dictionary<string, byte[]> data = new Dictionary<string, byte[]>();
		public int slot;
		public int itemId;
		public IKVItem()
		{

		}

		public static IKVItem parse(byte[] data, int begin, int end)
		{
			IKVItem newItem = new IKVItem();

			int tmpBegin = begin;
			for (int i = 0; i < 10 && tmpBegin < end; i++, tmpBegin += 4) {

				newItem.data["data" + i] = data.Skip(tmpBegin).Take(4).ToArray();

			}
			newItem.slot = BitConverter.ToInt32(newItem.data["data0"], 0);
			newItem.itemId = BitConverter.ToInt32(newItem.data["data1"], 0);

			return newItem;
		}

		public override bool Equals(object obj)
		{
			//Check for null and compare run-time types.
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			IKVItem other = (IKVItem)obj;
			foreach (var row in data)
			{
				if (BitConverter.ToInt32(other.data[row.Key], 0)
					!= BitConverter.ToInt32(row.Value, 0))
					return false;
			}
			return true;
		}

		public override string ToString()
		{
			return BitConverter.ToString(data["data1"]);
		}

		public string getDetail()
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
