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
        int _Tempo = 120;
        int _time_sign_count = 4;
        int _time_sign_note_lenght = 4;
        int _beat = 0;
        Chord _chord = new Chord();

        public int CurrentStyle { get => _currentStyle; set => _currentStyle = value; }
        public int CurrentVariation { get => _currentVariation; set => _currentVariation = value; }
        public List<Style> Styles { get => _styles; set => _styles = value; }
        public int[] VirtualKeyboard { get => _virtualKeyboard; set => _virtualKeyboard = value; }
        public List<Chord> Chords { get => _chords; set => _chords = value; }
        public int Tempo { get => _Tempo; set => _Tempo = value; }
        public int Time_sign_count { get => _time_sign_count; set => _time_sign_count = value; }
        public int Time_sign_note_lenght { get => _time_sign_note_lenght; set => _time_sign_note_lenght = value; }
        public Chord Chord { get => _chord; set => _chord = value; }
        public int Beat { get => _beat; set => _beat = value; }

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

        public string GetFormattedTempo() 
        {
            string formattedTempo = Tempo.ToString().PadLeft(3, ' ');
            return formattedTempo;
        }

        public string GetFormattedTimeSignature()
        {
            string formattedTimeSignature = this.Time_sign_count.ToString();
            formattedTimeSignature += "/";
            formattedTimeSignature += this.Time_sign_note_lenght.ToString();
            return formattedTimeSignature;
        }

        public string GetFormattedChord()
        {
            this.Chord.Name = "maj";
            return "C " + this.Chord.Name;
        }
        public string GetFormattedBeat()
        {
            return "| . . .";
        }
    }
}
