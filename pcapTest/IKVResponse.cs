using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;


namespace pcapTest
{
	class CharsListedResponse : IKVResponse
	{
		public CharsListedResponse(byte[] cmd) : base(cmd)
		{
		}

		public override bool process(IKVGame gameClient, byte[] data, int begin, int end)
		{
			int charCount = BitConverter.ToInt32(data, begin + 8);
			byte[] endToken = { 0xff, 0xff, 0xff, 0xff };

			int tmpBegin = begin + 12;
			
			for (int i = 0; i < charCount; i++)
			{

				int pos = Utils.containsCommand(data, tmpBegin, end, endToken);
				if(pos > 0)
				{
					IKVCharacter newChar = IKVCharacter.parse(gameClient, data, tmpBegin, pos);
					gameClient.chars.Add(newChar);

					Action action = () => gameClient.charListBox.Items.Add(newChar);
					gameClient.charListBox.Invoke(action);
				}
				tmpBegin = pos + 4;
			}



			return true;
		}
	}

	class BagDroppedResponse : IKVResponse
	{
		public BagDroppedResponse(byte[] cmd) : base(cmd)
		{
		}

		public override bool process(IKVGame gameClient, byte[] data, int begin, int end)
		{
			IKVItemBag bag = IKVItemBag.parse(data, end);
			gameClient.charLoggedIn.inventory.bags.Add(bag);
			Action act = () =>
			{
				gameClient.charLoggedIn.inventory.gui.bagList.Items.Clear();
				gameClient.charLoggedIn.inventory.gui.bagList.Items.AddRange(gameClient.charLoggedIn.inventory.bags.ToArray());
			};
			gameClient.charLoggedIn.inventory.gui.bagList.Invoke(act);
			return true;
		}
	}

	class BagOpenedResponse : IKVResponse
	{
		public BagOpenedResponse(byte[] cmd) : base(cmd)
		{
		}

		public override bool process(IKVGame gameClient, byte[] data, int begin, int end)
		{
			int tmpBegin = begin + 12;
			int slotCounter = 0;
			IKVItemBag bagOpened = null;

			int openedBagId = BitConverter.ToInt32(data.Skip(8).Take(4).ToArray(), 0);

			foreach (var bag in gameClient.charLoggedIn.inventory.bags)
			{
				if(bag.Id == openedBagId)
				{
					bagOpened = bag;
					bagOpened.items.Clear();
					break;
				}
			}


			for (; tmpBegin < end; tmpBegin += 36, slotCounter++)
			{
				IKVItem item = IKVItem.parse(data, tmpBegin, tmpBegin + 36, slotCounter);
				if (item.itemId != 0)
				{
					bagOpened?.items.Add(item);
					Action action = () => gameClient.charLoggedIn.inventory.gui.itemList.Items.Add(item);
					gameClient.charLoggedIn.inventory.gui.itemList.Invoke(action);
				}

			}

			gameClient.charLoggedIn.inventory.openedBag = bagOpened;

			return true;
		}
	}

	class BagItemGrabbedResponse : IKVResponse
	{
		public BagItemGrabbedResponse(byte[] cmd) : base(cmd)
		{
		}

		public override bool process(IKVGame gameClient, byte[] data, int begin, int end)
		{

			int itemId = BitConverter.ToInt32(data.Skip(begin + 4).Take(4).ToArray(), 0);
			int invSlot = BitConverter.ToInt32(data.Skip(begin + 12).Take(4).ToArray(), 0);
			int bagSlot = BitConverter.ToInt32(data.Skip(begin + 16).Take(4).ToArray(), 0);
			int bagId = BitConverter.ToInt32(data.Skip(begin + 20).Take(4).ToArray(), 0);

			if(gameClient.charLoggedIn.inventory.openedBag.Id == bagId)
			{
				foreach (var item in gameClient.charLoggedIn.inventory.openedBag.items)
				{
					if (item.itemId == itemId)
					{
						gameClient.charLoggedIn.inventory.openedBag.items.Remove(item);

						Action action = () =>
						{
							gameClient.charLoggedIn.inventory.slots[invSlot].Item = item;
							gameClient.charLoggedIn.inventory.gui.itemList.Items.Remove(item);
							gameClient.charLoggedIn.inventory.gui.grabSelectedItemBtn.Enabled = true;
						};
						gameClient.charLoggedIn.inventory.gui.itemList.Invoke(action);
						break;
					}
				}

			}

			return true;
		}
	}

	class SystemChatResponse : IKVResponse
	{
		public SystemChatResponse(byte[] cmd) : base(cmd)
		{
		}

		public override bool process(IKVGame gameClient, byte[] data, int begin, int end)
		{
			int count = BitConverter.ToInt32(data.Skip(begin + 12).Take(4).ToArray(), 0);
			string msg = Encoding.UTF8.GetString(data, begin + 16, begin + 16 + count);

			Action act = () =>
			{
				gameClient.chatBox.Items.Add(msg);
			};
			gameClient.chatBox.Invoke(act);
			return true;
		}
	}


	public abstract class IKVResponse
	{
		public IKVResponse(byte[] cmd)
		{
			bytes = cmd;
		}
		public static Dictionary<string, IKVResponse> getResponseMap()
		{
			if (response_map == null)
			{
				Dictionary<string, IKVResponse> map = new Dictionary<string, IKVResponse>
				{
					//response_map["moved__________"] = new byte[]{
					//0x30, 0x00, 0x00, 0x00,
					//0x6d, 0x69, 0x6e, 0x6b,
					//0x0d, 0x1f, 0x09, 0x00};

					//response_map["userportedout__"] = new byte[] {
					//0x08, 0x00, 0x00, 0x00,
					//0x68, 0x71, 0x73, 0x75};

					//response_map["userportedin___"] = new byte[] {
					//0x78, 0x02, 0x00, 0x00,
					//0x69, 0x72, 0x77, 0x65};

					[nameof(CharsListedResponse)] = new CharsListedResponse(new byte[] {
					0x66, 0x67, 0x6d, 0x69 }),

					[nameof(BagDroppedResponse)] = new BagDroppedResponse(new byte[] {
					0x70, 0x73, 0x62, 0x61}),

					[nameof(BagOpenedResponse)] = new BagOpenedResponse(new byte[] {
					0x73, 0x64, 0x62, 0x74}),

					[nameof(BagItemGrabbedResponse)] = new BagItemGrabbedResponse(new byte[] {
					0x66, 0x61, 0x74, 0x6c}),

					[nameof(SystemChatResponse)] = new SystemChatResponse(new byte[] {
					0x63, 0x74, 0x65, 0x72}),

				};

				return map;
			}
			else return response_map;

		}

		public abstract bool process(IKVGame gameClient, byte[] data, int begin, int end);

		public static Dictionary<string, IKVResponse> response_map;
		public byte[] bytes;
	}
}
