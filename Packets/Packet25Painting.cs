using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet25Painting {

        private SinZSockets socket;
        public int EID;
        public String title;
        public int X;
        public int Y;
        public int Z;
        public int direction;

        public Packet25Painting(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            title = socket.readString();
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
            direction = socket.readInt();
        }
    }
}
