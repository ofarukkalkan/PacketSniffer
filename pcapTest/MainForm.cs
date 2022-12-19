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
    static byte[] char1_login = new byte[]
    {
      0x61, 0x6c, 0x77, 0x7a, 0x75, 0x73, 0x65, 0x72,
      0x3d, 0x35, 0x33, 0x31, 0x38, 0x39, 0x34, 0x39,
      0x32, 0x38, 0x39, 0x26, 0x70, 0x61, 0x73, 0x73,
      0x3d, 0x79, 0x57, 0x50, 0x71, 0x48, 0x73, 0x42,
      0x6b, 0x33, 0x52, 0x58, 0x67, 0x49, 0x4f, 0x74,
      0x75, 0x25, 0x32, 0x62, 0x6c, 0x49, 0x55, 0x37,
      0x51, 0x25, 0x33, 0x64, 0x25, 0x33, 0x64, 0x26,
      0x69, 0x73, 0x4d, 0x6f, 0x62, 0x69, 0x6c, 0x65,
      0x3d, 0x54, 0x72, 0x75, 0x65, 0x00, 0x47, 0x35,
      0x43, 0x43, 0x36, 0x42, 0x33, 0x34, 0x46, 0x46,
      0x33, 0x00, 0x32, 0x43, 0x2d, 0x46, 0x30, 0x2d,
      0x35, 0x44, 0x2d, 0x37, 0x38, 0x2d, 0x41, 0x34,
      0x2d, 0x36, 0x45, 0x00, 0x32, 0x00
    };
		static byte[] char1_selection = {
			0x6c, 0x61, 0x73, 0x63, 0x86, 0x3b, 0x2d, 0xbc
		};


    static byte[] char2_login = new byte[]
    {
	    0x61, 0x6c, 0x77, 0x7a, 0x75, 0x73, 0x65, 0x72,
	    0x3d, 0x77, 0x61, 0x6e, 0x74, 0x65, 0x64, 0x64,
	    0x65, 0x77, 0x69, 0x6c, 0x40, 0x67, 0x6d, 0x61,
	    0x69, 0x6c, 0x2e, 0x63, 0x6f, 0x6d, 0x26, 0x70,
	    0x61, 0x73, 0x73, 0x3d, 0x79, 0x57, 0x50, 0x71,
	    0x48, 0x73, 0x42, 0x6b, 0x33, 0x52, 0x56, 0x4d,
	    0x4c, 0x65, 0x67, 0x31, 0x35, 0x32, 0x59, 0x48,
	    0x76, 0x51, 0x25, 0x33, 0x64, 0x25, 0x33, 0x64,
	    0x26, 0x69, 0x73, 0x4d, 0x6f, 0x62, 0x69, 0x6c,
	    0x65, 0x3d, 0x46, 0x61, 0x6c, 0x73, 0x65, 0x00,
	    0x47, 0x35, 0x43, 0x43, 0x36, 0x42, 0x33, 0x34,
	    0x46, 0x46, 0x33, 0x00, 0x32, 0x43, 0x2d, 0x46,
	    0x30, 0x2d, 0x35, 0x44, 0x2d, 0x37, 0x38, 0x2d,
	    0x41, 0x34, 0x2d, 0x36, 0x45, 0x00, 0x32, 0x00
		};
		static byte[] char2_selection = {
			0x6c, 0x61, 0x73, 0x63, 0xc2, 0x5c, 0x30, 0xc5
		};

    AsynchronousClient client1;
    AsynchronousClient client2;

    List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
    int selectedIntIndex;
    LibPcapLiveDevice wifi_device;
    CaptureFileWriterDevice captureFileWriter;
    Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();

    int packetNumber = 1;
    string time_str = "", sourceIP = "", destinationIP = "", protocol_type = "", length = "";

    bool startCapturingAgain = false;

    Thread sniffing;

    public MainForm(List<LibPcapLiveDevice> interfaces, int selectedIndex)
    {
      InitializeComponent();
      this.interfaceList = interfaces;
      selectedIntIndex = selectedIndex;
      // Extract a device from the list
      wifi_device = interfaceList[selectedIntIndex];

			client1 = new AsynchronousClient(27205, char1_login, char1_selection, true, charsClient1List);
			client2 = new AsynchronousClient(27205, char2_login, char2_selection, false, charsClient1List);
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
        textBox1.Enabled = false;

      }
      else if (startCapturingAgain)
      {
        if (MessageBox.Show("Your packets are captured in a file. Starting a new capture will override existing ones.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
        {
          // user clicked ok
          System.IO.File.Delete(Environment.CurrentDirectory + "capture.pcap");
          listView1.Items.Clear();
          capturedPackets_list.Clear();
          packetNumber = 1;
          textBox2.Text = "";
          wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
          sniffing = new Thread(new ThreadStart(sniffing_Proccess));
          sniffing.Start();
          toolStripButton1.Enabled = false;
          toolStripButton2.Enabled = true;
          textBox1.Enabled = false;
        }
      }
      startCapturingAgain = true;
    }

    // paket information
    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      string protocol = e.Item.SubItems[4].Text;
      int key = Int32.Parse(e.Item.SubItems[0].Text);
      Packet packet;
      bool getPacket = capturedPackets_list.TryGetValue(key, out packet);

      switch (protocol)
      {
        case "TCP":
          if (getPacket)
          {
            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
            if (tcpPacket != null)
            {
              int srcPort = tcpPacket.SourcePort;
              int dstPort = tcpPacket.DestinationPort;
              var checksum = tcpPacket.Checksum;

              textBox2.Text = "";
              textBox2.Text = "Packet number: " + key +
                              " Type: TCP" +
                              "\r\nSource port:" + srcPort +
                              "\r\nDestination port: " + dstPort +
                              "\r\nTCP header size: " + tcpPacket.DataOffset +
                              "\r\nWindow size: " + tcpPacket.WindowSize + // bytes that the receiver is willing to receive
                              "\r\nChecksum:" + checksum.ToString() + (tcpPacket.ValidChecksum ? ",valid" : ",invalid") +
                              "\r\nTCP checksum: " + (tcpPacket.ValidTCPChecksum ? ",valid" : ",invalid") +
                              "\r\nSequence number: " + tcpPacket.SequenceNumber.ToString() +
                              "\r\nAcknowledgment number: " + tcpPacket.AcknowledgmentNumber + (tcpPacket.Ack ? ",valid" : ",invalid") +
                              // flags
                              "\r\nUrgent pointer: " + (tcpPacket.Urg ? "valid" : "invalid") +
                              "\r\nACK flag: " + (tcpPacket.Ack ? "1" : "0") + // indicates if the AcknowledgmentNumber is valid
                              "\r\nPSH flag: " + (tcpPacket.Psh ? "1" : "0") + // push 1 = the receiver should pass the data to the app immidiatly, don't buffer it
                              "\r\nRST flag: " + (tcpPacket.Rst ? "1" : "0") + // reset 1 is to abort existing connection
                                                                               // SYN indicates the sequence numbers should be synchronized between the sender and receiver to initiate a connection
                              "\r\nSYN flag: " + (tcpPacket.Syn ? "1" : "0") +
                              // closing the connection with a deal, host_A sends FIN to host_B, B responds with ACK
                              // FIN flag indicates the sender is finished sending
                              "\r\nFIN flag: " + (tcpPacket.Fin ? "1" : "0") +
                              "\r\nECN flag: " + (tcpPacket.ECN ? "1" : "0") +
                              "\r\nCWR flag: " + (tcpPacket.CWR ? "1" : "0") +
                              "\r\nNS flag: " + (tcpPacket.NS ? "1" : "0");
            }
          }
          break;
        case "UDP":
          if (getPacket)
          {
            var udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
            if (udpPacket != null)
            {
              int srcPort = udpPacket.SourcePort;
              int dstPort = udpPacket.DestinationPort;
              var checksum = udpPacket.Checksum;

              textBox2.Text = "";
              textBox2.Text = "Packet number: " + key +
                              " Type: UDP" +
                              "\r\nSource port:" + srcPort +
                              "\r\nDestination port: " + dstPort +
                              "\r\nChecksum:" + checksum.ToString() + " valid: " + udpPacket.ValidChecksum +
                              "\r\nValid UDP checksum: " + udpPacket.ValidUDPChecksum;
            }
          }
          break;
        case "ARP":
          if (getPacket)
          {
            var arpPacket = (ARPPacket)packet.Extract(typeof(ARPPacket));
            if (arpPacket != null)
            {
              System.Net.IPAddress senderAddress = arpPacket.SenderProtocolAddress;
              System.Net.IPAddress targerAddress = arpPacket.TargetProtocolAddress;
              System.Net.NetworkInformation.PhysicalAddress senderHardwareAddress = arpPacket.SenderHardwareAddress;
              System.Net.NetworkInformation.PhysicalAddress targerHardwareAddress = arpPacket.TargetHardwareAddress;

              textBox2.Text = "";
              textBox2.Text = "Packet number: " + key +
                              " Type: ARP" +
                              "\r\nHardware address length:" + arpPacket.HardwareAddressLength +
                              "\r\nProtocol address length: " + arpPacket.ProtocolAddressLength +
                              "\r\nOperation: " + arpPacket.Operation.ToString() + // ARP request or ARP reply ARP_OP_REQ_CODE, ARP_OP_REP_CODE
                              "\r\nSender protocol address: " + senderAddress +
                              "\r\nTarget protocol address: " + targerAddress +
                              "\r\nSender hardware address: " + senderHardwareAddress +
                              "\r\nTarget hardware address: " + targerHardwareAddress;
            }
          }
          break;
        case "ICMP":
          if (getPacket)
          {
            var icmpPacket = (ICMPv4Packet)packet.Extract(typeof(ICMPv4Packet));
            if (icmpPacket != null)
            {
              textBox2.Text = "";
              textBox2.Text = "Packet number: " + key +
                              " Type: ICMP v4" +
                              "\r\nType Code: 0x" + icmpPacket.TypeCode.ToString("x") +
                              "\r\nChecksum: " + icmpPacket.Checksum.ToString("x") +
                              "\r\nID: 0x" + icmpPacket.ID.ToString("x") +
                              "\r\nSequence number: " + icmpPacket.Sequence.ToString("x");
            }
          }
          break;
        case "IGMP":
          if (getPacket)
          {
            var igmpPacket = (IGMPv2Packet)packet.Extract(typeof(IGMPv2Packet));
            if (igmpPacket != null)
            {
              textBox2.Text = "";
              textBox2.Text = "Packet number: " + key +
                              " Type: IGMP v2" +
                              "\r\nType: " + igmpPacket.Type +
                              "\r\nGroup address: " + igmpPacket.GroupAddress +
                              "\r\nMax response time" + igmpPacket.MaxResponseTime;
            }
          }
          break;
        default:
          textBox2.Text = "";
          break;
      }
    }

    private void toolStripButton6_Click(object sender, EventArgs e)// last packet
    {
      var items = listView1.Items;
      var last = items[items.Count - 1];
      last.EnsureVisible();
      last.Selected = true;
    }

    private void toolStripButton5_Click(object sender, EventArgs e)// fist packet
    {
      var first = listView1.Items[0];
      first.EnsureVisible();
      first.Selected = true;
    }

    private void toolStripButton4_Click(object sender, EventArgs e)//next
    {
      if (listView1.SelectedItems.Count == 1)
      {
        int index = listView1.SelectedItems[0].Index;
        listView1.Items[index + 1].Selected = true;
        listView1.Items[index + 1].EnsureVisible();
      }
    }

    private void chooseInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Interfaces openInterfaceForm = new Interfaces();
      this.Hide();
      openInterfaceForm.Show();
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

		private void toolStripButton3_Click(object sender, EventArgs e)// prev
    {
      if (listView1.SelectedItems.Count == 1)
      {
        int index = listView1.SelectedItems[0].Index;
        listView1.Items[index - 1].Selected = true;
        listView1.Items[index - 1].EnsureVisible();
      }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)// Stop sniffing
    {
      sniffing.Abort();
      wifi_device.StopCapture();
      wifi_device.Close();
      captureFileWriter.Close();

      toolStripButton1.Enabled = true;
      textBox1.Enabled = true;
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
        if (textBox1.Text != "")
        {
          wifi_device.Filter = textBox1.Text;
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
						if (repeatClient1Chk.Checked)
							client1.repeatCmd(tcp_packet.PayloadData);

						if (repeatClient2Chk.Checked)
							client2.repeatCmd(tcp_packet.PayloadData);

					}

        }

      }



      // add to the list
      capturedPackets_list.Add(packetNumber, packet);


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


        Action action = () => listView1.Items.Add(item);
        listView1.Invoke(action);

        ++packetNumber;
      }
    }
  }
}


