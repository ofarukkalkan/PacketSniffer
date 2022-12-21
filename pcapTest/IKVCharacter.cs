using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVCharacter
	{
		public IKVCharacter()
		{
		}
		public static IKVCharacter parse(IKVGame gameClient, byte[] data, int begin, int end)
		{
			IKVCharacter newChar = new IKVCharacter();
			// parse name
			int pos = begin;
			List<byte> nameList = new List<byte>();
	
			while (data[pos] != 0x00)
			{
				nameList.Add(data[pos]);
				pos++;
			}
			newChar.name = System.Text.Encoding.Default.GetString(nameList.ToArray());
			pos += 13;

			IKVInventory newInv = IKVInventory.parse(gameClient, data, pos, end);
			newChar.inventory = newInv;

			return newChar;
		}
		public override string ToString()
		{
			return name;
		}
		public IKVInventory inventory;
		public string name;
	}
}
