using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet70GameState {
        private SinZSockets socket;
        public sbyte reason;
        public sbyte gameMode;

        public Packet70GameState(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            reason = socket.readByte();
            gameMode = socket.readByte();
        }
    }
}
