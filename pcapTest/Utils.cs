using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcapTest
{
	public class Utils
	{
		public static int containsCommand(byte[] data, int start, int bytesRead, byte[] command)
		{
			var len = command.Length;
			var limit = bytesRead - len;
			for (var i = start; i <= limit; i++)
			{
				var k = 0;
				for (; k < len; k++)
				{
					if (command[k] != data[i + k]) break;
				}
				if (k == len) return i;
			}
			return -1;
		}

		public static bool startsWithCommand(byte[] data, int bytesRead, byte[] command)
		{
			for (int i = 0; i < bytesRead; i++)
			{
				if (i < command.Length)
				{
					if (data[i] != command[i]) return false;
				}
				else break;
			}
			return true;
		}

		public static byte[] ToByteArray(string hexString)
		{
			byte[] retval = new byte[hexString.Length / 2];
			for (int i = 0; i < hexString.Length; i += 2)
				retval[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
			return retval;
		}
	}
}
