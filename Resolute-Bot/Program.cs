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
        static void Main(string[] args) {

            bool offlineMode = false;
            String username = "S1NZ";
            String address = "mcsteamed.net";
            int port = 25565;

            TcpClient clientsocket = new TcpClient(address, port);
            NetworkStream stream = clientsocket.GetStream();
            SinZSockets socket = new SinZSockets(stream);

            String handshakeMessage = username + ";" + address + ":" + port;
            Packet02Handshake handshake = new Packet02Handshake(socket, handshakeMessage);
            Console.Out.WriteLine("Send handshake");
            byte packetID = (byte) socket.readByte();
            Console.WriteLine("Received packet: " + packetID);
            if (packetID == 2) {
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
                String reason = socket.readString();
                Console.WriteLine("Kick reason: " + reason);
            }
            else {
                //TODO: ...What? we didn't receive a handshake, KILL ALL HUMANS
            }

            byte packetID2 = (byte) socket.readByte();
            if (packetID2 == 1) {
                Packet01Login login1 = new Packet01Login(socket);
            }
            else if (packetID2 == 255) {
                String kickReason = socket.readString();
                Console.WriteLine("Received kick: " + kickReason);
            }
            else {
                //TODO: ...What? we didn't receive a login OR a kick? KILL ALL HUMANS
            }
        }
    }
}
