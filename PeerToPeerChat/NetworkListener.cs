using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PeerToPeerChat
{
    public class NetworkListener
    {
        Socket handler;
        public void StartListening()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            handler = listener.Accept();
        }
        public void OnNewConnection(Message message)
        {
            Console.WriteLine("Connected");
            Console.WriteLine("Start chatting...");
            Conversation conversation = new Conversation();
            Thread threadWrite = new Thread(() => conversation.Write(handler,message));
            Thread threadRead = new Thread(() => conversation.Receive(handler));
            threadWrite.Start();
            threadRead.Start();
        }
    }
}
