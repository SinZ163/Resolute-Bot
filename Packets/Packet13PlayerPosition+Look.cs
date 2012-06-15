using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet13PlayerPosition_Look {

        private SinZSockets socket;

        public double X;
        public double Y;
        public double Z;
        public double stance;
        public float yaw;
        public float pitch;
        public bool onGround;

        public Packet13PlayerPosition_Look(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet13PlayerPosition_Look(SinZSockets socket, double X, double Y, double Z, double stance, float yaw, float pitch, bool onGround) {
            this.socket = socket;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.stance = stance;
            this.yaw = yaw;
            this.pitch = pitch;
            this.onGround = onGround;
            write();
        }

        public void read() {
            X = socket.readDouble();
            stance = socket.readDouble();
            Y = socket.readDouble();
            Z = socket.readDouble();
            yaw = socket.readFloat();
            pitch = socket.readFloat();
            onGround = socket.readBool();
        }

        public void write() {
            socket.writeByte(13);

            socket.writeDouble(X);
            socket.writeDouble(Y);
            socket.writeDouble(stance);
            socket.writeDouble(Z);
            socket.writeFloat(yaw);
            socket.writeFloat(pitch);
            socket.writeBool(onGround);
        }
    }
}
