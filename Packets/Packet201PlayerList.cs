using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet201PlayerList {

        private SinZSockets socket;
        public String username;
        public bool online;
        public short ping;

        public Packet201PlayerList(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            username = socket.readString();
            online = socket.readBool();
            ping = socket.readShort();
        }
    }
}
