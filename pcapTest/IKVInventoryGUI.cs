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

		private void grabSelectedItemBtn_Click(object sender, EventArgs e)
		{
			IKVItemBag bag = (IKVItemBag)bagList.SelectedItem;
			if(bag == null)
			{
				MessageBox.Show("bag was null. couldnt grab items");
				return;
			}
			IKVItem tmpItem = (IKVItem)itemList.SelectedItem;
			gameClient.grabBagItem(bag, tmpItem, itemList.SelectedIndex);

		}

		private void IKVInventoryGUI_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
		}
	}
}
