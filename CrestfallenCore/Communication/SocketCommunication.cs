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
            var header = new byte[BufferSize];
            var receivedBytes = socket.Receive(header);

            if (receivedBytes <= 0) return null;
            
            var headerSizeAsString = Encoding.UTF8.GetString(header);
            var socketMessageSize = Convert.ToInt32(headerSizeAsString);
            var socketMessage = new byte[socketMessageSize];

            socket.Receive(socketMessage);

            var finalMessageAsString = Encoding.UTF8.GetString(socketMessage); 
            return finalMessageAsString;
        }


        public static void SendMessage(string message, Socket socket)
        {
            try 
            {
                var count = Encoding.UTF8.GetByteCount(message).ToString();
                var msg = count.PadLeft(BufferSize, '0');
                socket.Send(Encoding.UTF8.GetBytes(msg + message));
            }
            catch
            {
                Console.WriteLine("Something bad happened");
            }
        }
    }
}
