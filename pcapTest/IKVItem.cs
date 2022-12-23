using System;
using System.Collections.Generic;
using System.Linq;

namespace pcapTest
{
	public class IKVItem
	{
		public List<byte[]> data = new List<byte[]>();
		public int slot;
		public int itemId;
		public IKVItem()
		{

		}

		public static IKVItem parse(byte[] data, int begin, int end, int bagSlot = -1)
		{
			IKVItem newItem = new IKVItem();

			int rowCount = 10;
			if (bagSlot != -1)
				rowCount = 9;
			int tmpBegin = begin;

			for (int i = 0; i < rowCount && tmpBegin < end; i++, tmpBegin += 4)
			{
				newItem.data.Add(data.Skip(tmpBegin).Take(4).ToArray());
			}

			if (bagSlot != -1)
			{
				newItem.slot = bagSlot;
				newItem.itemId = BitConverter.ToInt32(newItem.data[1], 0);
			}
			else
			{
				newItem.slot = BitConverter.ToInt32(newItem.data[0], 0);
				newItem.itemId = BitConverter.ToInt32(newItem.data[1], 0);
			}
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
			if (other.itemId == itemId && other.slot == slot)
				return true;
			else 
				return false;
		}

		public override string ToString()
		{
			return BitConverter.ToString(BitConverter.GetBytes(itemId));
		}

	}

}
