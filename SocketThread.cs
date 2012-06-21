using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;
using System.Threading;
using Resolute.Bot.Packets;

namespace Resolute.Bot {
    class SocketThread {
        public SocketThread() {

        }

        public String username;
        public String sessionID;
        public String address;
        public int port;
        public SinZSockets socket;
        public bool finished = false;
        public bool offlineMode = false;

        public void init(String username, String sessionID, String address, int port, SinZSockets socket) {
            this.username = username;
            this.sessionID = sessionID;
            this.address = address;
            this.port = port;
            this.socket = socket;

            String handshakeMessage = username + ";" + address + ":" + port;
            Packet02Handshake handshake = new Packet02Handshake(socket, handshakeMessage);
            Console.Out.WriteLine("Send handshake");

            while (finished != true) {
                loop();
                Thread.Sleep(10);
            }
            socket.stream.Close();
            Console.In.ReadLine();
        }

        public void loop() {
            byte packetID = (byte)socket.readByte();
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
            else if (packetID == 23) {
                Packet23VehicleSpawn vehicalSpawn = new Packet23VehicleSpawn(socket);
            }
            else if (packetID == 24) {
                Packet24MobSpawn mobSpawn = new Packet24MobSpawn(socket);
            }
            else if (packetID == 25) {
                Packet25Painting painting = new Packet25Painting(socket);
            }
            else if (packetID == 28) {
                Packet28Velocity velocity = new Packet28Velocity(socket);
            }
            else if (packetID == 29) {
                Packet29EntityDeath death = new Packet29EntityDeath(socket);
            }
            else if (packetID == 31) {
                Packet31EntityMove entityMove = new Packet31EntityMove(socket);
            }
            else if (packetID == 32) {
                Packet32EntityLook entityLook = new Packet32EntityLook(socket);
            }
            else if (packetID == 33) {
                Packet33EntityLookandMove entityLookMove = new Packet33EntityLookandMove(socket);
            }
            else if (packetID == 34) {
                Packet34EntityTeleport entityTeleport = new Packet34EntityTeleport(socket);
            }
            else if (packetID == 35) {
                Packet35EntityHeadLook entityHeadLook = new Packet35EntityHeadLook(socket);
            }
            else if (packetID == 38) {
                Packet38Status stauts = new Packet38Status(socket);
            }
            else if (packetID == 40) {
                Packet40Metadata metadata = new Packet40Metadata(socket);
            }
            else if (packetID == 50) {
                Packet50PreChunk preChunk = new Packet50PreChunk(socket);
            }
            else if (packetID == 54) {
                Packet54TileEntity tileEntity = new Packet54TileEntity(socket);
            }
            else if (packetID == 61) {
                Packet61SoundEffect soundEffect = new Packet61SoundEffect(socket);
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
        }
    }
}
