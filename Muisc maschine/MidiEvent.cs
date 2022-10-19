using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muisc_maschine
{
    class MidiEvent
    {
        //the bytes that are sent as MIDI data
        private byte[] buffer = new byte[3];


        // there are 16 channels to chose from. channel 9 is percussion
        private int Channel;


        /// <summary>
        /// send the bytes
        /// </summary>
        public void send()
        {
            
        }
    }
}
