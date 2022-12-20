using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcapTest
{
	public class IKVGame
	{
		public IKVGame()
		{

		}

		public byte[] loginData;
		public byte[] charSelection;

		public Dictionary<string, IKVCommand> commands_map;
		public Dictionary<string, IKVResponse> response_map;

		public List<IKVCharacter> chars = new List<IKVCharacter>();
		public ListBox charListBox;
		public IKVCharacter charLoggedIn;

		public void gotoBag(IKVItemBag bag)
		{
			IKVMoveCommand datacmd = IKVMoveCommand.prepMoveData(commands_map["movedata_______"], bag.pos);
			runCmdWithData("movecmd________", datacmd.bytes);
		}

		public void openBag(IKVItemBag bag)
		{
			if(bag == null)
			{
				MessageBox.Show("bag not selected");
				return;
			}
			byte[] datacmd = commands_map["selectbagcmd__"].bytes;
			runCmdWithData("interactcmd___", datacmd.Concat(bag.id).ToArray());
		}

		public virtual void repeatCmd(byte[] cmd)
		{

		}

		public virtual void runCmdWithData(string cmd, byte[] datacmd)
		{

		}

		public virtual void enterGame(string charName)
		{

		}
	}
}
