using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace pcapTest
{
	public class IKVInventory
	{
		public IKVInventory(IKVGame gameClient)
		{
			this.bags = new List<IKVItemBag>();
			this.slots = new List<IKVItemSlot>(36);
			this.gameClient = gameClient;
			this.gui = new IKVInventoryGUI(gameClient);
			this.openedBag = null;

			int slotCounter = 0;
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					IKVSlotType slotType = IKVSlotType.hidden;
					if (slotCounter > 13)
						slotType = IKVSlotType.bag;
					slots.Add(new IKVItemSlot(slotCounter, null, slotType));
					TextBox box = new TextBox
					{
						Size = new System.Drawing.Size(100, 40)
					};
					box.Location = new System.Drawing.Point(280 + (j * 5) + (j * box.Size.Width), 20 + (i * box.Height) + (i * 5));
					box.Tag = BitConverter.ToString(BitConverter.GetBytes(slotCounter));
					box.ReadOnly = true;

					switch (slotCounter)
					{
						case 2:
						case 4:
						case 5:
							box.BackColor = Color.Tomato;
							break;
						case 9:
						case 10:
							box.BackColor = Color.Wheat;
							break;
						case 3:
							box.BackColor = Color.Olive;
							break;
						case 11:
							box.BackColor = Color.Cyan;
							break;
						case 12:
							box.BackColor = Color.Silver;
							break;
						case 13:
							box.BackColor = Color.Crimson;
							break;
						case 14:
							box.BackColor = Color.Crimson;
							break;
						case 15:
							box.BackColor = Color.RoyalBlue;
							break;
						case 16:
							box.BackColor = Color.RoyalBlue;
							break;

						default:
							break;
					}

					Binding binding = new Binding("Text", slots[slotCounter], "Item", false, DataSourceUpdateMode.OnPropertyChanged);
					box.DataBindings.Add(binding);
					gui.Controls.Add(box);

					slotCounter++;
				}

			}



		}
		public static IKVInventory parse(IKVGame gameClient, byte[] data, int begin, int end)
		{
			IKVInventory newInv = new IKVInventory(gameClient);

			int tmpBegin = begin;

			for (; tmpBegin < end; tmpBegin += 40)
			{

				IKVItem newItem = IKVItem.parse(data, tmpBegin, tmpBegin + 40);
				newInv.slots[newItem.slot].Item = newItem;

			}
			
			return newInv;
		}

		public int getFirstEmptySlot()
		{
			for (int i = 0x0d; i <= 0x24; i++)
			{
				if (slots[i].Item == null)
					return i;
			}
			return -1;
		}

		public IKVGame gameClient;
		public List<IKVItemSlot> slots;
		public List<IKVItemBag> bags;
		public IKVItemBag openedBag;
		public IKVInventoryGUI gui;

	}
}
