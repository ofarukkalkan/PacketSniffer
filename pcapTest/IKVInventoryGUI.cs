using System;
using System.Windows.Forms;

namespace pcapTest
{
	public partial class IKVBackPackGUI : Form
	{
		IKVGame gameClient;
		public IKVBackPackGUI(IKVGame gameClient)
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
			gameClient.grabBagItem(bag, tmpItem);
			grabSelectedItemBtn.Enabled = false;
		}

		private void IKVInventoryGUI_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
		}

		private void move2BankBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < itemSlotsGroup.Controls.Count; i++)
			{
				var radio = ((RadioButton)itemSlotsGroup.Controls[i]);
				if (radio.Checked == true)
				{
					gameClient.moveItem2Bank(((IKVItemSlot)radio.Tag).Slot);
					break;
				}
			}

		}

		private void openBankBtn_Click(object sender, EventArgs e)
		{
			gameClient.charLoggedIn.inventory.bankGUI.Text = this.Text;
			gameClient.charLoggedIn.inventory.bankGUI.Show();
		}
	}
}
