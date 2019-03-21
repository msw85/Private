using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    public class FCDClient {
        static void Main(string[] args) {
        }

        public void SendFile() {
            Stream fileStream = File.OpenRead("D:/Testarea/FileCopyDaemon/test.txt");
            // Alocate memory space for the file
            byte[] fileBuffer = new byte[fileStream.Length];

            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            // Open a TCP/IP Connection and send the data
            TcpClient clientSocket = new TcpClient("127.0.0.1", 12345);

            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Write(fileBuffer, 0, fileBuffer.GetLength(0));
            networkStream.Close();
        }
    }
}
