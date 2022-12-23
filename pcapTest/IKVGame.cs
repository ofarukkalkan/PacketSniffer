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
		public Form mdiParent;
		public IKVCharacter charLoggedIn;

		public void moveItem2Bank(int slot)
		{

			if (slot >= 0x0d && slot <= 0x24)
			{
				byte[] emptyBankSlotBytes = BitConverter.GetBytes(charLoggedIn.inventory.getFirsBankEmptySlot());
				byte[] itemIDBytes = BitConverter.GetBytes(charLoggedIn.inventory.itemSlots[slot].Item.itemId);

				byte[] cmd = commands_map[IKVCommandStr.moveItem].bytes;
				execCmd(IKVCommandStr._0x10, cmd.Concat(charSelection).Concat(itemIDBytes).Concat(emptyBankSlotBytes).ToArray());
			}
		}

		public void openBag(IKVItemBag bag)
		{
			if(bag == null)
			{
				MessageBox.Show("bag not selected");
				return;
			}
			byte[] cmd = commands_map[IKVCommandStr.selectBag].bytes;
			byte[] bagId = BitConverter.GetBytes(bag.Id);
			execCmd(IKVCommandStr._0x08, cmd.Concat(bagId).ToArray());
		}

		public bool grabBagItem(IKVItemBag bag, IKVItem bagItem, int bagSlot)
		{
			if (bagItem == null || bagItem.itemId == 0)
			{
				MessageBox.Show("item is null or empty");
				return false;
			}
			
			byte[] emptySlotBytes = BitConverter.GetBytes(charLoggedIn.inventory.getFirstBackPackEmptySlot());
			byte[] bagSlotBytes = BitConverter.GetBytes(bagSlot);
			byte[] cmd = commands_map[IKVCommandStr.grabBag].bytes;
			byte[] bagId = BitConverter.GetBytes(bag.Id);
			execCmd(IKVCommandStr._0x10, cmd.Concat(bagId).Concat(bagSlotBytes).Concat(emptySlotBytes).ToArray());

			return true;
		}

		public virtual void repeatCmd(byte[] cmd)
		{

		}

		public virtual void execCmd(string cmdLength, byte[] cmd)
		{

		}

		public virtual void enterGame(string charName)
		{

		}
	}
}
