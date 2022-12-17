using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public IKVCharacter charLoggedIn;
		public int charSelected;
	}
}
