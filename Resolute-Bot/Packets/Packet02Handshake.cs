using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet02Handshake {

        private SinZSockets socket;

        public Packet02Handshake(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet02Handshake(SinZSockets socket, String username) {
            this.socket = socket;
            this.username = username;
            write();
        }
        private String username;

        public String hash;

        public void read() {
            hash = socket.readString();
        }

        public void write() {
            socket.writeByte(2);
            socket.writeString(username);
        }
    }
}
