using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet04Time {

        private SinZSockets socket;
        public long time;

        public Packet04Time(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            time = socket.readLong();
        }
    }
}
