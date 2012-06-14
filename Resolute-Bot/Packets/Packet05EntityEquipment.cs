using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet05EntityEquipment {
        private SinZSockets socket;
        public int EID;
        public short slot;
        public short id;
        public short damage;

        public Packet05EntityEquipment(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            Console.Out.WriteLine("EID: " + EID);
            slot = socket.readShort();
            id = socket.readShort();
            if (id != -1) {
                damage = socket.readShort();
            }
        }
    }
}
