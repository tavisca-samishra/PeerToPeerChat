using System;
using System.Net.Sockets;

namespace PeerToPeerChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message();
            try
            {
                NetworkClient networkClient = new NetworkClient();
                networkClient.Connect();
                networkClient.OnNewConnection(message);
            }
            catch (Exception)
            {
                NetworkListener networkListener = new NetworkListener();
                networkListener.StartListening();
                networkListener.OnNewConnection(message);
            }
        }
    }
}
