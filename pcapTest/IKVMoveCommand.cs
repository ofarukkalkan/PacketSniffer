using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVMoveCommand : IKVCommand
	{
		public IKVMoveCommand(byte[] data, bool repeatable) : base(data, repeatable)
		{

		}

		public static IKVMoveCommand prepMoveData(IKVCommand cmd, IKVVec3Byte pos)
		{
			IKVMoveCommand movecmd = new IKVMoveCommand(cmd.bytes, cmd.repeatable);

			movecmd.bytes.
				Concat(new byte[]
				{
					0x00, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00
				}).
				Concat(pos.x).
				Concat(pos.z).
				Concat(pos.y).
				Concat(new byte[]{
					0x0b, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
					0x01, 0x00, 0x00, 0x00,
					0x00, 0x00, 0x00, 0x00,
				}).ToArray();

			return movecmd;
		}
	}
}
