using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet202Abilities {

        private SinZSockets socket;
        public bool invul;
        public bool isFlying;
        public bool canFly;
        public bool instaDestroy;

        public Packet202Abilities(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet202Abilities(SinZSockets socket, bool isFlying) {
            this.socket = socket;
            this.isFlying = isFlying;
            write();
        }

        public void read() {
            invul = socket.readBool();
            isFlying = socket.readBool();
            canFly = socket.readBool();
            instaDestroy = socket.readBool();
        }

        public void write() {
            socket.writeBool(false);
            socket.writeBool(isFlying);
            socket.writeBool(false);
            socket.writeBool(false);
        }
    }
}
