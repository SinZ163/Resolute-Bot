using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;

namespace Resolute.Bot.Packets {
    class Packet01Login {

        private SinZSockets socket;

        public Packet01Login(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public Packet01Login(SinZSockets socket, int version, String username) {
            this.socket = socket;
            this.version = version;
            this.username = username;
            write();
        }
        private int version;
        private String username;

        public int EID;
        public String levelType;
        public int mode;
        public int atmosphere;
        public SByte difficulty;

        public void read() {
            EID = socket.readInt();
            socket.readString();
            levelType = socket.readString();
            mode = socket.readInt();
            atmosphere = socket.readInt();
            difficulty = socket.readByte();
        }

        public void write() {
            socket.writeByte(1);

            socket.writeInt(version);
            socket.writeString(username);
            socket.writeString("");
            socket.writeInt(0);
            socket.writeInt(0);
            socket.writeByte(0);
            socket.writeByte(0);
            socket.writeByte(0);
        }
    }
}
