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
			this.itemSlots = new Dictionary<int, IKVItemSlot>(36 + 128);
			this.gameClient = gameClient;
			this.backPackGUI = new IKVBackPackGUI(gameClient);
			this.bankGUI = new IKVBankGUI();
			this.openedBag = null;

			int slotCounter = 1;
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					IKVSlotType slotType = IKVSlotType.hidden;
					if (slotCounter > 12)
						slotType = IKVSlotType.backPack;
					itemSlots[slotCounter] = new IKVItemSlot(slotCounter, null, slotType);
					RadioButton box = new RadioButton
					{
						Size = new System.Drawing.Size(90, 30)
					};
					box.Location = new System.Drawing.Point(10 + (j * 5) + (j * box.Size.Width), 10 + (i * box.Height) + (i * 5));
					box.Tag = itemSlots[slotCounter];

					switch (slotCounter)
					{
						case 2:
						case 4:
						case 5:
							box.BackColor = Color.Tomato;
							break;
						case 9:
						case 0x0a:
							box.BackColor = Color.Wheat;
							break;
						case 3:
							box.BackColor = Color.Olive;
							break;
						case 0x0b:
							box.BackColor = Color.Cyan;
							break;
						case 0x0c:
							box.BackColor = Color.Silver;
							break;
						case 0x0d:
							box.BackColor = Color.Crimson;
							break;
						case 0x0e:
							box.BackColor = Color.Crimson;
							break;
						case 0x0f:
							box.BackColor = Color.RoyalBlue;
							break;
						case 0x10:
							box.BackColor = Color.RoyalBlue;
							break;

						default:
							box.BackColor = Color.LightGray;
							break;
					}

					Binding binding = new Binding("Text", itemSlots[slotCounter], "Item", false, DataSourceUpdateMode.OnPropertyChanged);
					box.DataBindings.Add(binding);
					backPackGUI.itemSlotsGroup.Controls.Add(box);

					slotCounter++;
				}

			}


			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					IKVSlotType slotType = IKVSlotType.bank;
					itemSlots[slotCounter] = new IKVItemSlot(slotCounter, null, slotType);

					RadioButton box = new RadioButton
					{
						Size = new System.Drawing.Size(90, 30)
					};
					box.Location = new System.Drawing.Point(10 + (j * 5) + (j * box.Size.Width), 10 + (i * box.Height) + (i * 5));
					box.Tag = itemSlots[slotCounter];
					box.BackColor = Color.PaleGoldenrod;

					Binding binding = new Binding("Text", itemSlots[slotCounter], "Item", false, DataSourceUpdateMode.OnPropertyChanged);
					box.DataBindings.Add(binding);
					bankGUI.itemsGroup.Controls.Add(box);
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
				newInv.itemSlots[newItem.slot].Item = newItem;

			}
			
			return newInv;
		}

		public int getFirstBackPackEmptySlot()
		{
			for (int i = 0x0d; i <= 0x24; i++)
			{
				if (itemSlots[i].Item == null)
					return i;
			}
			return -1;
		}

		public int getFirsBankEmptySlot()
		{
			for (int i = 0x25; i <= 0xa4; i++)
			{
				if (itemSlots[i].Item == null)
					return i;
			}
			return -1;
		}


		public IKVGame gameClient;
		public Dictionary<int, IKVItemSlot> itemSlots;
		public List<IKVItemBag> bags;
		public IKVItemBag openedBag;
		public IKVBackPackGUI backPackGUI;
		public IKVBankGUI bankGUI;

	}
}
