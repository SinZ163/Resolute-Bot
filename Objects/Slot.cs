using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Objects {
    class Slot {
        private SinZSockets socket;

        public short ID;
        public sbyte count;
        public short damage;
        public byte[] enchantmentInfo;

        public Slot(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            ID = socket.readShort();
            if (ID != -1) {
                count = socket.readByte();
                damage = socket.readShort();
                if (CanEnchant(ID) == true) {
                    short len = socket.readShort();
                    if (len != -1) {
                        enchantmentInfo = new byte[len];
                        socket.stream.Read(enchantmentInfo, 0, enchantmentInfo.Length);
                    }
                }
            }
        }

        private static bool CanEnchant(short value) {
            return (256 <= value && value <= 259) ||
                    (267 <= value && value <= 279) ||
                    (283 <= value && value <= 286) ||
                    (290 <= value && value <= 294) ||
                    (298 <= value && value <= 317) ||
                    value == 261 || value == 359 ||
                    value == 346;
        }
    }
}
