using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using SinZationalSockets;
using Resolute.Bot.Packets;

namespace Resolute.Bot {
    class Program {
        public SinZSockets socket;
        public bool finished = false;
        public bool offlineMode = false;

        public String username;
        public String address;
        public int port;

        public Program(String username, String address, int port, SinZSockets socket) {
            this.username = username;
            this.address = address;
            this.port = port;
            this.socket = socket;

            String handshakeMessage = username + ";" + address + ":" + port;
            Packet02Handshake handshake = new Packet02Handshake(socket, handshakeMessage);
            Console.Out.WriteLine("Send handshake");

            loop();
        }

        static void Main(string[] args) {

            String username = "S1NZ";
            String address = "localhost";
            int port = 25565;
            TcpClient clientsocket = new TcpClient(address, port);
            NetworkStream stream = clientsocket.GetStream();
            SinZSockets socket = new SinZSockets(stream);
            new Program(username, address, port, socket);
        }

        public void loop() {
            if (finished != true) {

                byte packetID = (byte) socket.readByte();
                Console.WriteLine("Received packet: " + packetID);

                if (packetID == 1) {
                    Packet01Login login1 = new Packet01Login(socket);
                }
                else if (packetID == 2) {
                    Packet02Handshake handshake1 = new Packet02Handshake(socket);
                    if (handshake1.hash == "-") {
                        Console.WriteLine("Offline mode enabled by server!");
                        offlineMode = true;
                    }
                    else {
                        offlineMode = false;
                    }

                    Packet01Login login = new Packet01Login(socket, 29, username);
                    Console.Out.WriteLine("Send Login");
                }
                else if (packetID == 255) {
                    Packet255Kick kick = new Packet255Kick(socket);
                    Console.WriteLine("Kick reason: " + kick.reason);
                    finished = true;
                }
                else {
                    Packet255Kick kick = new Packet255Kick(socket, "Invalid packet!");
                    finished = true;
                }


                loop();
            }
        }
    }
}
