﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;
using Resolute.Bot.Objects;

namespace Resolute.Bot.Packets {
    class Packet40Metadata {

        private SinZSockets socket;
        public int EID;
        public Metadata metadata;

        public Packet40Metadata(SinZSockets socket) {
            this.socket = socket;
            read();
        }

        public void read() {
            EID = socket.readInt();
            Console.Out.WriteLine("INB4 Metadata");
            metadata = new Metadata(socket);
            metadata.read();
        }
    }
}
