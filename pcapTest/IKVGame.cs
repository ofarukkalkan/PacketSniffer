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
		public ListBox chatBox;
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
			byte[] bagId = BitConverter.GetBytes(bag.Id);
			runCmdWithData("interactcmd___", datacmd.Concat(bagId).ToArray());
		}

		public bool grabBagItem(IKVItemBag bag, IKVItem bagItem, int bagSlot)
		{
			if (bagItem == null || bagItem.itemId == 0)
			{
				MessageBox.Show("item is null or empty");
				return false;
			}
			
			byte[] emptySlotBytes = BitConverter.GetBytes(charLoggedIn.inventory.getFirstEmptySlot());
			byte[] bagSlotBytes = BitConverter.GetBytes(bagSlot);
			byte[] datacmd = commands_map["itemgrabdata__"].bytes;
			byte[] bagId = BitConverter.GetBytes(bag.Id);
			runCmdWithData("itemcmd_______", datacmd.Concat(bagId).Concat(bagSlotBytes).Concat(emptySlotBytes).ToArray());

			return true;
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
