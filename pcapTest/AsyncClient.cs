using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Base;

namespace pcapTest
{
	// State object for receiving data from remote device.  
	public class StateObject
	{
		// Client socket.  
		public Socket workSocket = null;
		// Size of receive buffer.  
		public const int BufferSize = 10000;
		// Receive buffer.  
		public byte[] buffer = new byte[BufferSize];
		// Received data string.  
		public StringBuilder sb = new StringBuilder();
	}


	public class AsynchronousClient : IKVGame
	{

		IPAddress ipAddress;
		IPEndPoint remoteEP;
		Socket client;

		// ManualResetEvent instances signal completion.  
		ManualResetEvent connectDone = new ManualResetEvent(false);
		ManualResetEvent sendDone = new ManualResetEvent(false);
		ManualResetEvent receiveDone = new ManualResetEvent(false);


		// The port number for the remote device.  
		int port; // kuklaci 27206 // beyazkosk 27205

		string ip_addess = "93.155.105.236";

		public AsynchronousClient(int port, byte[] loginData, byte[] charSelection, int mainCharID, Form mdiParent, ListBox charListBox, ListBox chatBox, CheckBox autoAcceptPartyChk)
		{
			this.loginData = loginData;
			this.charSelection = charSelection;
			this.port = port;
			this.mainCharID = mainCharID;

			this.mdiParent = mdiParent;
			this.charListBox = charListBox;
			this.autoAcceptPartyChk = autoAcceptPartyChk;
			this.chatBox = chatBox;

			commands_map = IKVCommand.getCommandMap();
			response_map = IKVResponse.getResponseMap();

			ipAddress = IPAddress.Parse(ip_addess);
			remoteEP = new IPEndPoint(ipAddress, this.port);

		}


		private void processResponse(byte[] data, int bytesRead)
		{
			bool flag = false;

			foreach (var response in response_map)
			{
				int cmdPos = Utils.containsCommand(data, 0, bytesRead, response.Value.bytes);
				if (cmdPos > 0)
				{
					flag = response.Value.process(this, data, cmdPos, bytesRead);
				}
			}
#if DEBUG
			if (flag)
				Console.WriteLine("unknown_command -> " + BitConverter.ToString(data.Take(bytesRead > 16 ? 16 : bytesRead).ToArray()));
#endif
		}


		private void StartClient()
		{

			try
			{
				// Create a TCP/IP socket.  
				client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				client.DontFragment = true;
				client.Ttl = 128;
				client.NoDelay = true;

				// Connect to the remote endpoint.  
				client.BeginConnect(remoteEP,
						new AsyncCallback(ConnectCallback), client);
				connectDone.WaitOne();


				/////////////////  giris yapma istegi gonder
				Send(client, new byte[] { 0x08, 0x00, 0x00, 0x00 });
				sendDone.WaitOne();
				Send(client, new byte[] { 0x64, 0x65, 0x76, 0x70, 0x08, 0x00, 0x00, 0x00 });
				sendDone.WaitOne();
				Console.WriteLine("Giris istegi gonderildi");
				Receive(client);

				///////////////// giris bilgilerini gonder
				Send(client, BitConverter.GetBytes(loginData.Length));
				sendDone.WaitOne();
				Send(client, loginData);
				sendDone.WaitOne();
				Console.WriteLine("Giris bilgileri gonderildi. karakter listesi bekleniyor ");
				Receive(client);
				//receiveDone.WaitOne();
				Thread.Sleep(2000);


				do
				{


					if (client.Available > 0)
					{
						Receive(client);
					}

					Thread.Sleep(10);
				} while (true);

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void ConnectCallback(IAsyncResult ar)
		{
			try
			{
				// Retrieve the socket from the state object.  
				Socket client = (Socket)ar.AsyncState;

				// Complete the connection.  
				client.EndConnect(ar);

				Console.WriteLine("Socket connected to {0}",
						client.RemoteEndPoint.ToString());

				// Signal that the connection has been made.  
				connectDone.Set();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void Receive(Socket client)
		{
			try
			{
				// Create the state object.  
				StateObject state = new StateObject();
				state.workSocket = client;

				// Begin receiving the data from the remote device.  
				client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
						new AsyncCallback(ReceiveCallback), state);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void ReceiveCallback(IAsyncResult ar)
		{
			try
			{
				// Retrieve the state object and the client socket
				// from the asynchronous state object.  
				StateObject state = (StateObject)ar.AsyncState;
				Socket client = state.workSocket;

				// Read data from the remote device.  
				int bytesRead = client.EndReceive(ar);

				if (bytesRead > 0)
				{
					// There might be more data, so store the data received so far.  
					var str = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
					state.sb.Append(str);

					processResponse(state.buffer, bytesRead);

					// Get the rest of the data.  
					client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
							new AsyncCallback(ReceiveCallback), state);

					receiveDone.Set();
				}
				else
				{
					// All the data has arrived; put it in response.  
					if (state.sb.Length > 1)
					{
						//processResponse(state.buffer, bytesRead);
					}
					// Signal that all bytes have been received.  
					receiveDone.Set();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void Send(Socket client, byte[] byteData)
		{
#if DEBUG
			Console.WriteLine("Sending bytes to server : " + BitConverter.ToString(byteData.Take(byteData.Length > 16 ? 16 : byteData.Length).ToArray()));
#endif

			// Begin sending the data to the remote device.  
			client.BeginSend(byteData, 0, byteData.Length, 0,
					new AsyncCallback(SendCallback), client);
		}

		private void SendCallback(IAsyncResult ar)
		{
			try
			{
				// Retrieve the socket from the state object.  
				Socket client = (Socket)ar.AsyncState;

				// Complete sending the data to the remote device.  
				int bytesSent = client.EndSend(ar);
#if DEBUG
				Console.WriteLine("Sent {0} bytes to server.", bytesSent);
#endif
				// Signal that all bytes have been sent.  
				sendDone.Set();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public override void repeatCmd(byte[] cmd)
		{
			if (cmd == null) return;
			bool flag = true;
			foreach (var command in commands_map)
			{
				
				if (command.Value.repeatable && Utils.startsWithCommand(cmd, cmd.Length, command.Value.bytes))
				{
					flag = false;
					Send(client, cmd);
				}
			}
#if DEBUG
			if (flag)
				Console.WriteLine("unknown_command -> " + BitConverter.ToString(cmd.Take(cmd.Length > 16 ? 16 : cmd.Length).ToArray()));
#endif
		}

		public override void execCmd(string cmdLength, byte[] cmd)
		{
			Send(client, commands_map[cmdLength].bytes);
			sendDone.WaitOne();
			Send(client, cmd);
		}

		public override void enterGame(string charName)
		{
			charLoggedIn = chars.Find(character => character.name == charName);
			if (charLoggedIn == null)
			{
				MessageBox.Show("char not found");
				return;
			}
			///////////////// karakter sec
			Send(client, commands_map[IKVCommandStr._0x08].bytes);
			sendDone.WaitOne();
			byte[] selectiondata = commands_map[IKVCommandStr.selectCharacter].bytes;
			Send(client, selectiondata.Concat(charSelection).ToArray());
			sendDone.WaitOne();
			Console.WriteLine("Karakter secme istegi gonderildi ");
			Receive(client);

			Thread.Sleep(1000);

			/////////////////  oyuna gir
			Send(client, commands_map[IKVCommandStr._0x04].bytes);
			sendDone.WaitOne();
			Send(client, new byte[] { 0x73, 0x69, 0x78, 0x74 });
			sendDone.WaitOne();
			Console.WriteLine("Oyuna girme istegi gonderildi ");

			Thread.Sleep(200);


		}


		public void start()
		{
			StartClient();
		}
		public void stop()
		{
			if(client == null)
			{
				MessageBox.Show("client is not started");
				return;
			}
			// Release the socket.  
			client.Shutdown(SocketShutdown.Both);
			client.Close();
		}
	}
}
