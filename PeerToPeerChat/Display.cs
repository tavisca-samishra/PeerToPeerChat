using System;
using System.Collections.Generic;
using System.Text;

namespace PeerToPeerChat
{
    public class Display
    {
        internal void ShowRecievedMessage(string data)
        {
            Console.WriteLine("Recieved: {0}", data);
        }

        internal void ShowSentMessage(string message)
        {
            Console.WriteLine("Sent: {0}",message);
        }
    }
}
