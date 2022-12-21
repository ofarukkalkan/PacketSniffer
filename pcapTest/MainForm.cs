using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SharpPcap.LibPcap;
using SharpPcap;
using PacketDotNet;
using System.Linq;

namespace pcapTest
{
  public partial class MainForm : Form
  {

    List<IKVClientPanel> clientPanels = new List<IKVClientPanel>();

    List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
    int selectedIntIndex;
    LibPcapLiveDevice wifi_device;
    CaptureFileWriterDevice captureFileWriter;


    int packetNumber = 1;
    string time_str = "", sourceIP = "", destinationIP = "", protocol_type = "", length = "";

    bool startCapturingAgain = false;

    PacketDetails packetDetailsForm;
		Thread sniffing;

    public MainForm(List<LibPcapLiveDevice> interfaces, int selectedIndex)
    {
      InitializeComponent();
      this.interfaceList = interfaces;
      selectedIntIndex = selectedIndex;
      // Extract a device from the list
      wifi_device = interfaceList[selectedIntIndex];

			packetDetailsForm = new PacketDetails();
      packetDetailsForm.MdiParent = this;
		}

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      System.Windows.Forms.Application.Exit();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)// Start sniffing
    {
      if (startCapturingAgain == false) //first time 
      {
        System.IO.File.Delete(Environment.CurrentDirectory + "capture.pcap");
        wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
        sniffing = new Thread(new ThreadStart(sniffing_Proccess));
        sniffing.Start();
        toolStripButton1.Enabled = false;
        toolStripButton2.Enabled = true;
        toolStripFilterTextBox.Enabled = false;

      }
      else if (startCapturingAgain)
      {
        if (MessageBox.Show("Your packets are captured in a file. Starting a new capture will override existing ones.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
        {
          // user clicked ok
          System.IO.File.Delete(Environment.CurrentDirectory + "capture.pcap");
					packetDetailsForm.listView1.Items.Clear();
					packetDetailsForm.capturedPackets_list.Clear();
          packetNumber = 1;
					packetDetailsForm.textBox2.Text = "";
          wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
          sniffing = new Thread(new ThreadStart(sniffing_Proccess));
          sniffing.Start();
          toolStripButton1.Enabled = false;
          toolStripButton2.Enabled = true;
					toolStripFilterTextBox.Enabled = false;
        }
      }
      startCapturingAgain = true;
    }

    // paket information


    private void toolStripButton6_Click(object sender, EventArgs e)// last packet
    {
      var items = packetDetailsForm.listView1.Items;
      var last = items[items.Count - 1];
      last.EnsureVisible();
      last.Selected = true;
    }

    private void toolStripButton5_Click(object sender, EventArgs e)// fist packet
    {
      var first = packetDetailsForm.listView1.Items[0];
      first.EnsureVisible();
      first.Selected = true;
    }

    private void toolStripButton4_Click(object sender, EventArgs e)//next
    {
      if (packetDetailsForm.listView1.SelectedItems.Count == 1)
      {
        int index = packetDetailsForm.listView1.SelectedItems[0].Index;
				packetDetailsForm.listView1.Items[index + 1].Selected = true;
				packetDetailsForm.listView1.Items[index + 1].EnsureVisible();
      }
    }

    private void chooseInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Interfaces openInterfaceForm = new Interfaces();
      this.Hide();
      openInterfaceForm.Show();
    }

		private void toolStripPacketDetailsBtn_Click(object sender, EventArgs e)
		{
      packetDetailsForm.Show();
		}

		private void toolStripNewClientBtn_Click(object sender, EventArgs e)
		{
			var newPanel = new IKVClientPanel(toolStripMainCharIDTxtBox.Text)
			{
				MdiParent = this
			};
			clientPanels.Add(newPanel);
      newPanel.Show();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)// prev
    {
      if (packetDetailsForm.listView1.SelectedItems.Count == 1)
      {
        int index = packetDetailsForm.listView1.SelectedItems[0].Index;
        packetDetailsForm.listView1.Items[index - 1].Selected = true;
				packetDetailsForm.listView1.Items[index - 1].EnsureVisible();
      }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)// Stop sniffing
    {
      sniffing.Abort();
      wifi_device.StopCapture();
      wifi_device.Close();
      captureFileWriter.Close();

      toolStripButton1.Enabled = true;
			toolStripFilterTextBox.Enabled = true;
      toolStripButton2.Enabled = false;
    }

    private void sniffing_Proccess()
    {
      // Open the device for capturing
      int readTimeoutMilliseconds = 1000;
      wifi_device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

      // Start the capturing process
      if (wifi_device.Opened)
      {
        if (toolStripFilterTextBox.Text != "")
        {
          wifi_device.Filter = toolStripFilterTextBox.Text;
        }
        captureFileWriter = new CaptureFileWriterDevice(wifi_device, Environment.CurrentDirectory + "capture.pcap");
        wifi_device.Capture();
      }
    }

    public void Device_OnPacketArrival(object sender, CaptureEventArgs e)
    {
      // dump to a file
      captureFileWriter.Write(e.Packet);


      // start extracting properties for the listview 
      DateTime time = e.Packet.Timeval.Date;
      time_str = (time.Hour + 1) + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
      length = e.Packet.Data.Length.ToString();


      var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
      var ip_packet = packet.PayloadPacket;

      if (ip_packet != null)
      {
        var tcp_packet = ip_packet.PayloadPacket;
        if (tcp_packet != null)
        {
          if (tcp_packet.PayloadData.Length > 0)
          {
            foreach (var clientPanel in clientPanels)
            {
              if(clientPanel.repeatChk.Checked)
								clientPanel.client?.repeatCmd(tcp_packet.PayloadData);

						}
					}

        }

      }



			// add to the list
			packetDetailsForm.capturedPackets_list.Add(packetNumber, packet);


      var ipPacket = (IpPacket)packet.Extract(typeof(IpPacket));


      if (ipPacket != null)
      {
        System.Net.IPAddress srcIp = ipPacket.SourceAddress;
        System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
        protocol_type = ipPacket.Protocol.ToString();
        sourceIP = srcIp.ToString();
        destinationIP = dstIp.ToString();



        var protocolPacket = ipPacket.PayloadPacket;

        ListViewItem item = new ListViewItem(packetNumber.ToString());
        item.SubItems.Add(time_str);
        item.SubItems.Add(sourceIP);
        item.SubItems.Add(destinationIP);
        item.SubItems.Add(protocol_type);
        item.SubItems.Add(length);


        Action action = () => packetDetailsForm.listView1.Items.Add(item);
				packetDetailsForm.Invoke(action);

        ++packetNumber;
      }
    }
  }
}


