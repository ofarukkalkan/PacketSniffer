using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public class IKVCommandStr
	{
		public static readonly string _0x04 = "_0x04";
		public static readonly string _0x08 = "_0x08";
		public static readonly string _0x0c = "_0x0c";
		public static readonly string _0x10 = "_0x10";
		public static readonly string _0x15 = "_0x15";
		public static readonly string _0x1c = "_0x1c";
		public static readonly string _0x38 = "_0x38";
		public static readonly string _0x7c = "_0x7c";


		public static readonly string move = "move";
		public static readonly string teleport = "teleport";
		public static readonly string respawn = "respawn";
		public static readonly string useSkill = "useSkill";
		public static readonly string setSkillPoints = "setSkillPoints";
		public static readonly string interact = "interact";
		public static readonly string interactGate = "interactGate";
		public static readonly string talk = "talk";
		public static readonly string selectOption = "selectOption";
		public static readonly string acceptQuest = "acceptQuest";
		public static readonly string acceptParty = "acceptParty";
		public static readonly string sendMsg = "sendMsg";
		public static readonly string useItem = "useItem";
		public static readonly string moveItem = "moveItem";
		public static readonly string selectBag = "selectBag";
		public static readonly string grabBag = "grabBag";
		public static readonly string selectCharacter = "selectCharacter";

	}
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
				[IKVCommandStr._0x04] = new IKVCommand(new byte[] {
			0x04, 0x00, 0x00, 0x00 }, true),
				[IKVCommandStr._0x08] = new IKVCommand(new byte[] {
			0x08, 0x00, 0x00, 0x00}, true),
				[IKVCommandStr._0x0c] = new IKVCommand(new byte[] {
			0x0c, 0x00, 0x00, 0x00}, true),
				[IKVCommandStr._0x10] = new IKVCommand(new byte[] {
			0x10, 0x00, 0x00, 0x00}, false),
				[IKVCommandStr._0x15] = new IKVCommand(new byte[] {
			0x15, 0x00, 0x00, 0x00}, true),
				[IKVCommandStr._0x1c] = new IKVCommand(new byte[] {
			0x1C, 0x00, 0x00, 0x00}, true),
				[IKVCommandStr._0x38] = new IKVCommand(new byte[] {
			0x38, 0x00, 0x00, 0x00 }, true),
				[IKVCommandStr._0x7c] = new IKVCommand(new byte[] {
			0x7c, 0x00, 0x00, 0x00}, true),

				// movement
				[IKVCommandStr.move] = new IKVCommand(new byte[] {
			0x65, 0x73, 0x72, 0x73 }, true),
				[IKVCommandStr.teleport] = new IKVCommand(new byte[] {
			0x64, 0x6c, 0x63, 0x7a}, true),
				[IKVCommandStr.respawn] = new IKVCommand(new byte[] {
			0x70, 0x73, 0x6c, 0x72}, true),

				// skills
				[IKVCommandStr.useSkill] = new IKVCommand(new byte[] {
			0x74, 0x73, 0x7A, 0x63}, true),
				[IKVCommandStr.setSkillPoints] = new IKVCommand(new byte[] {
			0x63, 0x6c, 0x78, 0x73}, true),

				// interaction					
				[IKVCommandStr.interact] = new IKVCommand(new byte[] {
			0x63, 0x77, 0x74, 0x61}, true),
				[IKVCommandStr.interactGate] = new IKVCommand(new byte[] {
			0x6e, 0x63, 0x68, 0x72}, true),
				[IKVCommandStr.talk] = new IKVCommand(new byte[] {
			0x6b, 0x61, 0x61, 0x74}, true),
				[IKVCommandStr.selectOption] = new IKVCommand(new byte[] {
			0x6e, 0x63, 0x6c, 0x6b}, true),
				[IKVCommandStr.acceptQuest] = new IKVCommand(new byte[] {
			0x71, 0x73, 0x63, 0x61}, true),
				[IKVCommandStr.sendMsg] = new IKVCommand(new byte[] {
			0x63, 0x64, 0x66, 0x63}, true),
				[IKVCommandStr.acceptParty] = new IKVCommand(new byte[] {
			0x63, 0x79, 0x6e, 0x69}, false),
				// login
				[IKVCommandStr.selectCharacter] = new IKVCommand(new byte[] {
			0x6c, 0x61, 0x73, 0x63}, false),
				// items
				[IKVCommandStr.useItem] = new IKVCommand(new byte[] {
			0x69, 0x74, 0x73, 0x75}, false),
				[IKVCommandStr.moveItem] = new IKVCommand(new byte[] {
			0x78, 0x76, 0x6f, 0x6d}, false),
				[IKVCommandStr.selectBag] = new IKVCommand(new byte[] {
			0x62, 0x74, 0x6c, 0x72}, false),
				[IKVCommandStr.grabBag] = new IKVCommand(new byte[] {
			0x74, 0x6d, 0x6f, 0x6c}, false)
			};

			return commands_map;
		}
		public byte[] bytes;
		public bool repeatable;
	}
}
