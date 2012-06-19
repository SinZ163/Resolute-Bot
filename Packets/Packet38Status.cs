using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet38Status {

        private SinZSockets socket;
        public int EID;
        public sbyte status;

        public Packet38Status(SinZSockets socket) {
            this.socket = socket;
            read();
        }


        public void read() {
            EID = socket.readInt();
            status = socket.readByte();
        }
    }
}
