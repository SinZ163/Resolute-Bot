using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet31EntityMove {

        private SinZSockets socket;
        public int EID;
        public sbyte dX;
        public sbyte dY;
        public sbyte dZ;


        public Packet31EntityMove(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            dX = socket.readByte();
            dY = socket.readByte();
            dZ = socket.readByte();
        }
    }
}
