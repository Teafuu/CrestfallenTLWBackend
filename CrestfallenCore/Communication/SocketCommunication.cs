using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CrestfallenCore.Communication
{
    public static class SocketCommunication // redo with larger buffer 
    {
        private static int BufferSize = 3;

        public static string GetMessage(Socket socket)
        {
            byte[] header = new byte[BufferSize];
            int receivedBytes = socket.Receive(header);

            if (receivedBytes > 0)
            {
                byte[] socketMessage = new byte[Convert.ToInt32(Encoding.UTF8.GetString(header))];
                socket.Receive(socketMessage);
                return Encoding.UTF8.GetString(socketMessage);
            }
            throw new Exception("Connection Closed");
        }
        public static void SendMessage(string message, Socket socket)
        {
            try { 
                string msg;
                int count = message.Length;

                if (count < 100)
                    msg = $"0{count}";
                else msg = count.ToString();
                byte[] header = Encoding.UTF8.GetBytes(msg);
                socket.Send(header);
                socket.Send(Encoding.UTF8.GetBytes(message));
            }catch
            {
                Console.WriteLine("Something bad happened");
            }
        }
    }
}
