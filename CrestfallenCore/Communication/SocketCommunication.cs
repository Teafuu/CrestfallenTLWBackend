using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CrestfallenCore.Communication
{
    public static class SocketCommunication // redo with larger buffer 
    {
        private static int BufferSize = 20;

        public static string GetMessage(Socket socket)
        {
            byte[] header = new byte[BufferSize];
            int receivedBytes = socket.Receive(header);

            if (receivedBytes > 0)
            {
                string headerSizeAsString = Encoding.UTF8.GetString(header);
                int socketMessageSize = Convert.ToInt32(headerSizeAsString);
                byte[] socketMessage = new byte[socketMessageSize];

                socket.Receive(socketMessage);

                string finalMessageAsString = Encoding.UTF8.GetString(socketMessage); 
                return finalMessageAsString;
            }
            throw new Exception("Connection Closed");
        }


        public static void SendMessage(string message, Socket socket)
        {
            try {
                string count = Encoding.UTF8.GetByteCount(message).ToString();
                string msg = count.PadLeft(BufferSize, '0');
                socket.Send(Encoding.UTF8.GetBytes(msg + message));
            }
            catch
            {
                Console.WriteLine("Something bad happened");
            }
        }
    }
}
