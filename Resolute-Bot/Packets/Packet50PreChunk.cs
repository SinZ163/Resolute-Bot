using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet50PreChunk {

        private SinZSockets socket;
        public int X;
        public int Z;
        public bool mode;

        public Packet50PreChunk(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            X = socket.readInt();
            Z = socket.readInt();
            mode = socket.readBool();
        }
    }
}
