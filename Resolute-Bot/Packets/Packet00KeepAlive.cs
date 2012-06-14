using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet00KeepAlive {

        private SinZSockets socket;
        public int ID;
        
        public Packet00KeepAlive(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet00KeepAlive(SinZSockets socket, int ID) {
            this.socket = socket;
            this.ID = ID;
            write();
        }

        public void read() {
            ID = socket.readInt();
        }

        public void write() {
            socket.writeByte(0);
            socket.writeInt(ID);
        }

    }
}
