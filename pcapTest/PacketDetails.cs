using PacketDotNet;
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
	public partial class PacketDetails : Form
	{
		public Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();
		public PacketDetails()
		{
			InitializeComponent();
		}

		private void PacketDetails_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
		}

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

	}
}
