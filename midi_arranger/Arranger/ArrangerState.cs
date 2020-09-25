using System;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;

namespace midi_arranger.Arranger
{
    public class ArrangerState
    {
        private int _currentStyle = 0;
        private int _currentVariation = 0;
        private List<Style> _styles = new List<Style>();
        private int[] _virtualKeyboard = new int[127];

        public int CurrentStyle { get => _currentStyle; set => _currentStyle = value; }

        public int CurrentVariation { get => _currentVariation; set => _currentVariation = value; }
        
        public List<Style> Styles { get => _styles; set => _styles = value; }
        public int[] VirtualKeyboard { get => _virtualKeyboard; set => _virtualKeyboard = value; }

        public void UpdateVirtualKeyboard(MidiEvent midiEvent) 
        {
            if(midiEvent.EventType == MidiEventType.NoteOn) 
            {
                int noteNumber = ((NoteOnEvent)midiEvent).NoteNumber;
                int velocity = ((NoteOnEvent)midiEvent).Velocity;
                this.VirtualKeyboard[noteNumber] = velocity;
            }

            if (midiEvent.EventType == MidiEventType.NoteOff)
            {
                int noteNumber = ((NoteOffEvent)midiEvent).NoteNumber;
                this.VirtualKeyboard[noteNumber] = 0;
            }
        }
    }
}
