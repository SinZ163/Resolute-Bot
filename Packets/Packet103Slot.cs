using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;
using Resolute.Bot.Objects;

namespace Resolute.Bot.Packets {
    class Packet103Slot {

        private SinZSockets socket;
        public sbyte ID;
        public short slotNumber;
        public Slot slot;

        public Packet103Slot(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            ID = socket.readByte();
            slotNumber = socket.readShort();
            slot = new Slot(socket);
        }
    }
}
