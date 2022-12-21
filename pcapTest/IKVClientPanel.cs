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
	public partial class IKVClientPanel : Form
	{
		public AsynchronousClient client;
		public string mainCharID;
		public IKVClientPanel(string charID)
		{
			InitializeComponent();

			mainCharID = charID;
		}

		private void IKVClientPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
		}

		private void startClientBtn_Click(object sender, EventArgs e)
		{
			if(portListBox.SelectedItem != null
				&& loginDataListBox.SelectedItem != null
				&& charSelectionDataListBox.SelectedItem != null)
			{
				int port = Int32.Parse(portListBox.SelectedItem.ToString().Split(' ')[1]);
				byte[] loginBytes = Utils.ToByteArray(loginDataListBox.SelectedItem.ToString().Split(' ')[1]);
				byte[] charSelectionBytes = Utils.ToByteArray(charSelectionDataListBox.SelectedItem.ToString().Split(' ')[1]);

				client = new AsynchronousClient(port, loginBytes, charSelectionBytes, charsList);
				Thread t1 = new Thread(new ThreadStart(client.start));
				t1.Start();
				startClientBtn.Enabled = false;
				stopClientBtn.Enabled = true;

				enterGameBtn.Enabled = true;
				openInventoryBtn.Enabled = true;
				acceptRequestBtn.Enabled = true;

				chatBox.Enabled = true;
				repeatChk.Enabled = true;
				charsList.Enabled = true;
			}
			else
			{
				MessageBox.Show("select login info port and char selection");
			}

		}

		private void stopClientBtn_Click(object sender, EventArgs e)
		{
			if (client == null)
				return;

			client.stop();
			startClientBtn.Enabled = true;
			stopClientBtn.Enabled = false;

			enterGameBtn.Enabled = false;
			openInventoryBtn.Enabled = false;
			acceptRequestBtn.Enabled = false;

			chatBox.Enabled = false;
			repeatChk.Enabled = false;
			charsList.Enabled = false;

			client = null;
		}

		private void enterGameBtn_Click(object sender, EventArgs e)
		{
			client.enterGame(charsList.SelectedItem.ToString());
		}

		private void acceptRequestBtn_Click(object sender, EventArgs e)
		{
			var data = new byte[] {
			0x63, 0x79, 0x6e, 0x69};

			var id_data = BitConverter.GetBytes(int.Parse(mainCharID));

			client.runCmdWithData("interactcmd___", data.Concat(id_data).ToArray());
		}

		private void openInventoryBtn_Click(object sender, EventArgs e)
		{
			client.charLoggedIn.inventory.gui.Show();
		}
	}
}
