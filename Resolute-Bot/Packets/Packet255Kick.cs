using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet255Kick {
        private SinZSockets socket;

        public Packet255Kick(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet255Kick(SinZSockets socket, String reason) {
            this.socket = socket;
            this.reason = reason;
            write();
        }

        public String reason;

        public void read() {
            reason = socket.readString();
        }

        public void write() {
            socket.writeByte(-127);
            socket.writeString(reason);
        }
    }
}
