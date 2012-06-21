using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet23VehicleSpawn {

        private SinZSockets socket;
        public int EID;
        public sbyte type;
        public int X;
        public int Y;
        public int Z;
        public int throwerEID;
        public short sX;
        public short sY;
        public short sZ;

        public Packet23VehicleSpawn(SinZSockets socket) {
            EID = socket.readInt();
            type = socket.readByte();
            X = socket.readInt();
            Y = socket.readInt();
            Z = socket.readInt();
            throwerEID = socket.readInt();
            if (throwerEID > 0) {
                sX = socket.readShort();
                sY = socket.readShort();
                sZ = socket.readShort();
            }
        }
    }
}
