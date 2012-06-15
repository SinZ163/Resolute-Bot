using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet06SpawnPosition {

        private SinZSockets socket;
        public int X;
        public int Y;
        public int Z;

        public Packet06SpawnPosition(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
        }
    }
}
