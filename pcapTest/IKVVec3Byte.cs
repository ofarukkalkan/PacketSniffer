using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVVec3Byte
	{
		public IKVVec3Byte(byte[] x, byte[] y, byte[] z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public byte[] x;
		public byte[] y;
		public byte[] z;

		public override string ToString()
		{
			return "position -> x : " + BitConverter.ToString(x) + " - y : " + BitConverter.ToString(y) + " - z : " + BitConverter.ToString(z);
		}
	}
}
