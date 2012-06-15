using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet33EntityLookandMove {

        private SinZSockets socket;
        public int EID;
        public sbyte dX;
        public sbyte dY;
        public sbyte dZ;
        public sbyte yaw;
        public sbyte pitch;

        public Packet33EntityLookandMove(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            dX = socket.readByte();
            dY = socket.readByte();
            dZ = socket.readByte();
            yaw = socket.readByte();
            pitch = socket.readByte();
        }
    }
}
