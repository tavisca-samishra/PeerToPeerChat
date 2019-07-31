using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PeerToPeerChat
{
    public class Conversation
    {
        Display display = new Display();
        internal void Write(Socket handler,Message message)
        {
            while (true)
            {
                message.Text = Console.ReadLine();
                display.ShowSentMessage(message.Text);
                byte[] msg = Encoding.ASCII.GetBytes(message.Text);
                int bytesSent = handler.Send(msg);
            }
        }
        internal void Receive(Socket handler)
        {
            while (true)
            {
                string data = "";
                byte[] bytess = new byte[1024];
                int bytesRec = handler.Receive(bytess);
                data = Encoding.ASCII.GetString(bytess, 0, bytesRec);
                display.ShowRecievedMessage(data);
            }
        }
    }
}
