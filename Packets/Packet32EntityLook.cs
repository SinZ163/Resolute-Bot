using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet32EntityLook {

        private SinZSockets socket;
        public int EID;
        public sbyte yaw;
        public sbyte pitch;

        public Packet32EntityLook(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            yaw = socket.readByte();
            pitch = socket.readByte();
        }
    }
}
