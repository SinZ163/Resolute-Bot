using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet28Velocity {

        private SinZSockets socket;
        public int EID;
        public short X;
        public short Y;
        public short Z;

        public Packet28Velocity(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            X = socket.readShort();
            Y = socket.readShort();
            Z = socket.readShort();
        }
    }
}
