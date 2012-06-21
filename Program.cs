using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using SinZationalSockets;
using Resolute.Bot.Packets;
using System.Timers;
using System.Threading;

namespace Resolute.Bot {
    class Program {
        public SinZSockets socket;
        public bool finished = false;
        public bool offlineMode = false;

        public String username;
        public String address;
        public int port;

        static void Main(string[] args) {

            String username = "SinZBot";
            String address = "localhost";
            String sessionID = "";
            int port = 25565;
            TcpClient clientsocket = new TcpClient(address, port);
            NetworkStream stream = clientsocket.GetStream();
            SinZSockets socket = new SinZSockets(stream);

            SocketThread socketClass = new SocketThread();

            Thread socketThread = new Thread(() => socketClass.init(username, sessionID, address, port, socket));
            socketThread.Start();
        }
    }
}
