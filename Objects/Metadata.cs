using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinZationalSockets;
using System.Collections;

namespace Resolute.Bot.Objects {
    class Metadata {

        private SinZSockets socket;
        private byte metadataInfo;
        private int type;
        private int index;
        private object value;
        public Dictionary<int, object> metadata;

        public Metadata(SinZSockets socket) {
            this.socket = socket;
        }

        public void read() {
            metadata = new Dictionary<int, object>();
            metadataInfo = (byte) socket.readByte();
            while (metadataInfo != 127) {
                type = metadataInfo >> 5;
                index = metadataInfo & 0x1F;

                Console.Out.WriteLine("metadata type: " + type);
                Console.Out.WriteLine("metadata index: " + index);
                if (type == 0) {
                    value = (byte)socket.readByte();
                }
                else if (type == 1) {
                    value = socket.readShort();
                }
                else if (type == 2) {
                    value = socket.readInt();
                }
                else if (type == 3) {
                    value = socket.readFloat();
                }
                else if (type == 4) {
                    value = socket.readString();
                }
                else if (type == 5) {
                    Hashtable slot = new Hashtable();
                    slot.Add("id", socket.readShort());
                    slot.Add("count", socket.readByte());
                    slot.Add("damaage", socket.readShort());
                    value = slot;
                }
                else if (type == 6) {
                    int[] coords = new int[3];
                    coords[0] = socket.readInt();
                    coords[1] = socket.readInt();
                    coords[2] = socket.readInt();
                    value = coords;
          
                }
                else {
                    //TODO: uh oh, we fucked up!
                }
                metadata.Add(index, new object[2] { type, value });
                metadataInfo = (byte)socket.readByte();
            }
        }
    }
}
