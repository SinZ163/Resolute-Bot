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
            Console.In.ReadLine();
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

                if (packetID == 0) {
                    Packet00KeepAlive keepAlive = new Packet00KeepAlive(socket);
                    keepAlive.write();
                }
                else if (packetID == 1) {
                    Packet01Login login = new Packet01Login(socket);
                    Console.Out.WriteLine("Login: " + login.EID);
                }
                else if (packetID == 2) {
                    Packet02Handshake handshake = new Packet02Handshake(socket);
                    if (handshake.hash == "-") {
                        Console.WriteLine("Offline mode enabled by server!");
                        offlineMode = true;
                    }
                    else {
                        offlineMode = false;
                    }

                    Packet01Login login = new Packet01Login(socket, 29, username);
                    Console.Out.WriteLine("Send Login");
                }
                else if (packetID == 3) {
                    Packet03Chat chat = new Packet03Chat(socket);
                    Console.WriteLine("Chat: " + chat.message);
                }
                else if (packetID == 4) {
                    Packet04Time time = new Packet04Time(socket);
                }
                else if (packetID == 5) {
                    Packet05EntityEquipment entityEquipment = new Packet05EntityEquipment(socket);
                }
                else if (packetID == 6) {
                    Packet06SpawnPosition position = new Packet06SpawnPosition(socket);
                }
                else if (packetID == 13) {
                    Packet13PlayerPosition_Look posLook = new Packet13PlayerPosition_Look(socket);
                }
                else if (packetID == 21) {
                    Packet21DroppedItem droppedItem = new Packet21DroppedItem(socket);
                }
                else if (packetID == 24) {
                    Packet24MobSpawn mobSpawn = new Packet24MobSpawn(socket);
                }
                else if (packetID == 25) {
                    Packet25Painting painting = new Packet25Painting(socket);
                    Console.Out.WriteLine("Painting: " + painting.title + " at coords: (X" + painting.X + ", Y" + painting.Y + ", Z" + painting.Z + ").");
                }
                else if (packetID == 28) {
                    Packet28Velocity velocity = new Packet28Velocity(socket);
                }
                else if (packetID == 33) {
                    Packet33EntityLookandMove entityLookMove = new Packet33EntityLookandMove(socket);
                }
                else if (packetID == 40) {
                    Packet40Metadata metadata = new Packet40Metadata(socket);
                }
                else if (packetID == 50) {
                    Packet50PreChunk preChunk = new Packet50PreChunk(socket);
                }
                else if (packetID == 70) {
                    Packet70GameState gameState = new Packet70GameState(socket);
                }
                else if (packetID == 103) {
                    Packet103Slot slot = new Packet103Slot(socket);
                }
                else if (packetID == 104) {
                    Packet104WindowItems windowItems = new Packet104WindowItems(socket);
                }
                else if (packetID == 201) {
                    Packet201PlayerList playerList = new Packet201PlayerList(socket);
                }
                else if (packetID == 202) {
                    Packet202Abilities abilities = new Packet202Abilities(socket);
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
