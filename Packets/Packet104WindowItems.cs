using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resolute.Bot.Objects;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet104WindowItems {

        private SinZSockets socket;
        public sbyte ID;
        public short count;
        public Slot[] slotArray;

        public Packet104WindowItems(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            ID = socket.readByte();
            count = socket.readShort();
            slotArray = new Slot[count];
            for (int i = 0; i < slotArray.Length; i++) {
                slotArray[i] = new Slot(socket);
            }
        }
    }
}
