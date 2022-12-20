using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcapTest
{
	public partial class IKVGameGUI : Form
	{
		public IKVGameGUI()
		{
			InitializeComponent();
		}

		private void startClient2_Click(object sender, EventArgs e)
		{
			Thread t1 = new Thread(new ThreadStart(client2.start));
			t1.Start();
			startClient2.Enabled = false;
			stopClien2Btn.Enabled = true;
		}

		private void startClient1_Click(object sender, EventArgs e)
		{
			Thread t1 = new Thread(new ThreadStart(client1.start));
			t1.Start();
			startClient1.Enabled = false;
			stopClient1Btn.Enabled = true;

		}

		private void acceptRequestBtn1_Click(object sender, EventArgs e)
		{
			var data = new byte[] {
			0x63, 0x79, 0x6e, 0x69};

			var id_data = BitConverter.GetBytes(int.Parse(mainCharIDTxt.Text));

			client1.runCmdWithData("interactcmd___", data.Concat(id_data).ToArray());
		}

		private void acceptRequestBtn2_Click(object sender, EventArgs e)
		{
			var data = new byte[] {
			0x63, 0x79, 0x6e, 0x69};

			var id_data = BitConverter.GetBytes(int.Parse(mainCharIDTxt.Text));

			client2.runCmdWithData("interactcmd___", data.Concat(id_data).ToArray());
		}


		//private void client1BagsList_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    client1.currentBagIndex = client1BagsList.SelectedIndex;
		//    client1.lastSelectedBag = (IKVItemBag)client1BagsList.SelectedItem;

		//    client1BagItemList.Items.Clear();
		//}


		private void stopClient1Btn_Click(object sender, EventArgs e)
		{
			client1.stop();
			startClient1.Enabled = true;
		}

		private void stopClien2Btn_Click(object sender, EventArgs e)
		{
			client2.stop();
			startClient2.Enabled = true;
		}

		private void enterGameClient1Btn_Click(object sender, EventArgs e)
		{
			client1.enterGame(charsClient1List.SelectedItem.ToString());
		}

		private void openInvClient1Btn_Click(object sender, EventArgs e)
		{
			client1.charLoggedIn.inventory.gui.Show();
		}
	}
}
