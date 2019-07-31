using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PeerToPeerChat
{
    public class NetworkClient
    {
        Socket handler;
        public void Connect()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            handler = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            handler.Connect(remoteEP);
        }
        public void OnNewConnection(Message message)
        {
            Console.WriteLine("Connected");
            Console.WriteLine("Start chatting...");
            Conversation conversation = new Conversation();
            Thread threadWrite = new Thread(() => conversation.Write(handler, message));
            Thread threadRead = new Thread(() => conversation.Receive(handler));
            threadWrite.Start();
            threadRead.Start();
        }
    }
}