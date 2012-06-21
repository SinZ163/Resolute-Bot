using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet54TileEntity {

        private SinZSockets socket;
        public int X;
        public short Y;
        public int Z;
        public sbyte a;
        public sbyte b;


        public Packet54TileEntity(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            X = socket.readInt();
            Y = socket.readShort();
            Z = socket.readInt();
            a = socket.readByte();
            b = socket.readByte();
        }
    }
}