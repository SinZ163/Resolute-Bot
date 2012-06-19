using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet35EntityHeadLook {

        private SinZSockets socket;
        public int EID;
        public sbyte headYaw;

        public Packet35EntityHeadLook(SinZSockets socket) {
            this.socket = socket;
            read();
        }


        public void read() {
            EID = socket.readInt();
            headYaw = socket.readByte();
        }
    }
}
