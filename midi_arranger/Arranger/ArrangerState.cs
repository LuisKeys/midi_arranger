using System;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;

namespace midi_arranger.Arranger
{
    public class ArrangerState
    {
        int _currentStyle = 0;
        int _currentVariation = 0;
        List<Style> _styles = new List<Style>();
        int[] _virtualKeyboard = new int[127];
        List<Chord> _chords = new List<Chord>();
        int _tempo = 120;

        public int CurrentStyle { get => _currentStyle; set => _currentStyle = value; }
        public int CurrentVariation { get => _currentVariation; set => _currentVariation = value; }
        public List<Style> Styles { get => _styles; set => _styles = value; }
        public int[] VirtualKeyboard { get => _virtualKeyboard; set => _virtualKeyboard = value; }
        public List<Chord> Chords { get => _chords; set => _chords = value; }
        public int Tempo { get => _tempo; set => _tempo = value; }

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

            if (midiEvent.EventType == MidiEventType.NoteOn ||
                midiEvent.EventType == MidiEventType.NoteOff)
            {
                Chord chord = new Chord();
                Console.WriteLine(chord.GetName(this));
            }
            

        }
    }
}
