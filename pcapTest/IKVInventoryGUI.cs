using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcapTest
{
	public partial class IKVInventoryGUI : Form
	{
		IKVGame gameClient;
		public IKVInventoryGUI(IKVGame gameClient)
		{
			InitializeComponent();
			this.gameClient = gameClient;
		}

		private void openBagBtn_Click(object sender, EventArgs e)
		{
			itemList.Items.Clear();
			IKVItemBag bag = (IKVItemBag)bagList.SelectedItem;
			gameClient.openBag(bag);
		}
	}
}
