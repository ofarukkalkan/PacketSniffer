using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVItemBag
	{
		public IKVItemBag(int id, IKVVec3Byte pos)
		{
			this.Id = id;
			this.pos = pos;
			this.items = new List<IKVItem>();
		}

		public static IKVItemBag parse(byte[] data, int bytesread)
		{
			if (bytesread < 24)
				return null;

			int id = BitConverter.ToInt32(data.Skip(8).Take(4).ToArray(), 0);
			byte[] x = data.Skip(12).Take(4).ToArray();
			byte[] z = data.Skip(16).Take(4).ToArray();
			byte[] y = data.Skip(20).Take(4).ToArray();

			IKVVec3Byte pos = new IKVVec3Byte(x, y, z);
			IKVItemBag bag = new IKVItemBag(id, pos);
			return bag;
		}

		public override string ToString()
		{
			return BitConverter.ToString(BitConverter.GetBytes(Id));
		}

		private int id;
		public IKVVec3Byte pos;
		public List<IKVItem> items;

		public int Id { get => id; set => id = value; }
	}
}
