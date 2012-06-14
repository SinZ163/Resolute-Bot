using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;
using Resolute.Bot.Objects;

namespace Resolute.Bot.Packets {
    class Packet24MobSpawn {
        private SinZSockets socket;
        public int EID;
        public sbyte type;
        public int X;
        public int Y;
        public int Z;
        public sbyte yaw;
        public sbyte pitch;
        public sbyte headYaw;
        public Metadata metadata;

        public Packet24MobSpawn(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            type = socket.readByte();
            Console.Out.WriteLine("Mob type: " + type);
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
            yaw = socket.readByte();
            pitch = socket.readByte();
            headYaw = socket.readByte();
            metadata = new Metadata(socket);
        }
    }
}
