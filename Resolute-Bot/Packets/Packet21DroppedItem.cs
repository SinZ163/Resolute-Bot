using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet21DroppedItem {

        private SinZSockets socket;
        public int EID;
        public short ID;
        public sbyte count;
        public short damage;
        public int X;
        public int Y;
        public int Z;
        public sbyte rotation;
        public sbyte pitch;
        public sbyte roll;

        public Packet21DroppedItem(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            ID = socket.readShort();
            count = socket.readByte();
            damage = socket.readShort();
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
            rotation = socket.readByte();
            pitch = socket.readByte();
            roll = socket.readByte();
        }
    }
}
