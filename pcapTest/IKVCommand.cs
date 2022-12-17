using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVCommand
	{
		public IKVCommand(byte[] data, bool repeatable)
		{
			this.bytes = data;
			this.repeatable = repeatable;
		}

		public static Dictionary<string, IKVCommand> getCommandMap()
		{
			Dictionary<string, IKVCommand> commands_map = new Dictionary<string, IKVCommand>
			{
				// movement
				["movecmd________"] = new IKVCommand(new byte[] {
			0x38, 0x00, 0x00, 0x00 }, true),
				["movedata_______"] = new IKVCommand(new byte[] {
			0x65, 0x73, 0x72, 0x73 }, true),
				["spawncmd______"] = new IKVCommand(new byte[] {
			0x04, 0x00, 0x00, 0x00 }, true),
				["teleportcmd2?_"] = new IKVCommand(new byte[] {
			0x64, 0x6c, 0x63, 0x7a}, true),
				["respawndata___"] = new IKVCommand(new byte[] {
			0x70, 0x73, 0x6c, 0x72}, true),
				// skills
				["useskillcmd___"] = new IKVCommand(new byte[] {
			0x1C, 0x00, 0x00, 0x00}, true),
				["useskilldata__"] = new IKVCommand(new byte[] {
			0x74, 0x73, 0x7A, 0x63}, true),
				["applyskillcmd_"] = new IKVCommand(new byte[] {
			0x7c, 0x00, 0x00, 0x00}, true),
				["applyskilldata"] = new IKVCommand(new byte[] {
			0x63, 0x6c, 0x78, 0x73}, true),
				// interaction					
				["interactcmd___"] = new IKVCommand(new byte[] {
			0x08, 0x00, 0x00, 0x00}, true),
				["interactdata__"] = new IKVCommand(new byte[] {
			0x63, 0x77, 0x74, 0x61}, true),
				["talkcmd_______"] = new IKVCommand(new byte[] {
			0x6b, 0x61, 0x61, 0x74}, true),
				["selectoptcmd__"] = new IKVCommand(new byte[] {
			0x0c, 0x00, 0x00, 0x00}, true),
				["selectoptdata_"] = new IKVCommand(new byte[] {
			0x6e, 0x63, 0x6c, 0x6b}, true),
				["acceptquestdat"] = new IKVCommand(new byte[] {
			0x71, 0x73, 0x63, 0x61}, true),
				["sendrpcmd_____"] = new IKVCommand(new byte[] {
			0x15, 0x00, 0x00, 0x00}, true),
				["msgdata_______"] = new IKVCommand(new byte[] {
			0x63, 0x64, 0x66, 0x63}, true),

				//commands_map["acceptpartydat"] = new byte[] {
				//0x63, 0x79, 0x6e, 0x69};


				// items
				//commands_map["useitemdata___"] = new byte[] {
				//0x69, 0x74, 0x73, 0x75};

				//commands_map["moveitemdata__"] = new byte[] {
				//0x78, 0x76, 0x6f, 0x6d};

				["selectbagcmd__"] = new IKVCommand(new byte[] {
			0x62, 0x74, 0x6c, 0x72}, false)
			};

			//commands_map["itemcmd_______"] = new byte[] {
			//0x10, 0x00, 0x00, 0x00};

			//commands_map["itemgrabdata__"] = new byte[] {
			//0x74, 0x6d, 0x6f, 0x6c};


			return commands_map;
		}
		public byte[] bytes;
		public bool repeatable;
	}
}
