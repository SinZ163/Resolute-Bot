using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet61SoundEffect {

        private SinZSockets socket;
        public int EID;
        public int X;
        public sbyte Y;
        public int Z;
        public int data;

        public Packet61SoundEffect(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            X = socket.readInt();
            Y = socket.readByte();
            Z = socket.readInt();
            data = socket.readInt();
        }
    }
}
