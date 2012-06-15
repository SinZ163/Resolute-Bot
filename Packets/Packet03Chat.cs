using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet03Chat {

        private SinZSockets socket;
        public String message;

        public Packet03Chat(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet03Chat(SinZSockets socket, String message) {
            this.socket = socket;
            this.message = message;
            write();
        }

        public void read() {
            message = socket.readString();
        }

        public void write() {
            socket.writeByte(3);
            socket.writeString(message);
        }
    }
}
