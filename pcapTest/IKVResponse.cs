using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


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
					IKVCharacter newChar = IKVCharacter.parse(data, tmpBegin, pos);
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

			Action action = () => gameClient.charLoggedIn.inventory.gui.bagList.Items.Add(bag);
			gameClient.charLoggedIn.inventory.gui.bagList.Invoke(action);
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

					//["bagopened______"] = new IKVResponse(new byte[] {
					//0x73, 0x64, 0x62, 0x74})
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
