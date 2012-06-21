using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet34EntityTeleport {

        private SinZSockets socket;
        public int EID;
        public int X;
        public int Y;
        public int Z;
        public sbyte yaw;
        public sbyte pitch;

        public Packet34EntityTeleport(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
            yaw = socket.readByte();
            pitch = socket.readByte();
        }
    }
}
