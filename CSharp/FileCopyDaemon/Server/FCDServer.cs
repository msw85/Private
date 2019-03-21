using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server {
    public class FCDServer {
        IPHostEntry IPHost;
        private ArrayList nSockets;

        public FCDServer() {
            Setup();
        }

        public void Setup() {
            IPHost = Dns.GetHostEntry(Dns.GetHostName());

            Debug.WriteLine(IPHost.AddressList[0].ToString());

            nSockets = new ArrayList();
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();
        }

        private void listenerThread() {
            IPAddress iPAddress = IPAddress.Parse(IPHost.AddressList[0].ToString());
            TcpListener tcpListener = new TcpListener(iPAddress, 12345);
            tcpListener.Start();
            while (true) {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected) {
                    //Control.CheckForIllegalCrossThreadCalls = false;

                    Debug.WriteLine(handlerSocket.RemoteEndPoint.ToString() + " connected.");

                    lock (this) {
                        nSockets.Add(handlerSocket);
                    }
                    ThreadStart thdstHandler = new
                    ThreadStart(handlerThread);
                    Thread thdHandler = new Thread(thdstHandler);
                    thdHandler.Start();
                }
            }
        }
        private void handlerThread() {
            Socket handlerSocket = (Socket)nSockets[nSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            int thisRead = 0;
            int blockSize = 1024;
            Byte[] dataByte = new Byte[blockSize];
            lock (this) {
                // Only one process can access
                // the same file at any given time
                Stream fileStream = File.OpenWrite("C:/SubmittedFile.txt");
                while (true) {
                    thisRead = networkStream.Read(dataByte, 0, blockSize);
                    fileStream.Write(dataByte, 0, thisRead);
                    if (thisRead == 0) break;
                }
                fileStream.Close();
            }
            Debug.WriteLine("File Written");
            handlerSocket = null;
        }
    }
}
