using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_arranger.Arranger
{
    public class Chord
    {
        const string NOTES_NAMES_LIST = "C C#D D#E F F#G G#A A#B ";
        const string FIRST_INVERSION = "1 inv";
        const string SECOND_INVERSION = "2 inv";
        string _name = "";
        string _baseNote = "";
        int _baseNoteNumber = 0;
        List<int> _intevals = new List<int>();
        List<string> _notes = new List<string>();
        List<int> _notesNumbers = new List<int>();
        int _inversion = 0;

        public string Name { get => _name; set => _name = value; }
        public string BaseNote { get => _baseNote; set => _baseNote = value; }
        public int BaseNoteNumber { get => _baseNoteNumber; set => _baseNoteNumber = value; }
        public List<int> Intevals { get => _intevals; set => _intevals = value; }
        public List<string> Notes { get => _notes; set => _notes = value; }
        public List<int> NotesNumbers { get => _notesNumbers; set => _notesNumbers = value; }
        public int Inversion { get => _inversion; set => _inversion = value; }

        public string GetName(ArrangerState arrangerState) 
        {
            this.GetNotes(arrangerState);
            this.Inversion = 0;

            if (this.Notes.Count == 0) return "";

            this.BaseNote = this.Notes[0];
            this.BaseNoteNumber = this.NotesNumbers[0];

            this.GetIntervals();

            foreach(Chord chord in arrangerState.Chords) 
            {
                if(this.CompareIntervals(this, chord)) 
                {
                    this.Name = chord.Name;
                }
            }

            if(this.Name.IndexOf(FIRST_INVERSION) > -1) 
            {
                this.BaseNote = this.Notes[2];
                this.BaseNoteNumber = this.NotesNumbers[2];
            }

            if (this.Name.IndexOf(SECOND_INVERSION) > -1)
            {
                this.BaseNote = this.Notes[1];
                this.BaseNoteNumber = this.NotesNumbers[1];
            }

            return this.BaseNote + this.Name;
        }

        public bool CompareIntervals(Chord chordA, Chord chordB) 
        {
            if(chordA.Intevals.Count != chordB.Intevals.Count) 
            {
                return false;
            }

            int intervalIndex = 0;
            foreach(int intervalA in chordA.Intevals) 
            {
                if(intervalA != chordB.Intevals[intervalIndex])
                {
                    return false;
                }

                intervalIndex++;
            }

            return true;
        }

        public void GetNotes(ArrangerState arrangerState) 
        {
            this.Notes.Clear();
            int noteNumber = 0;

            foreach(int velocity in arrangerState.VirtualKeyboard) 
            {
                if(velocity > 0) 
                {
                    this.Notes.Add(this.GetNoteName(noteNumber));
                    this.NotesNumbers.Add(noteNumber);
                }

                noteNumber++;
            }
        }

        public string GetNoteName(int noteNUmber) 
        {
            return "C C#D D#E F F#G G#A A#B ".Substring((noteNUmber % 12) * 2, 2);
        }

        public void GetIntervals() 
        {
            this.Intevals.Clear();
        
            foreach(int noteNumber in this.NotesNumbers) 
            {
                this.Intevals.Add(noteNumber - this.BaseNoteNumber);
            }

            StringBuilder intervalsstring = new StringBuilder();
            foreach (int interval in this.Intevals)
            {
                intervalsstring.Append(interval.ToString());
            }

            Console.WriteLine(intervalsstring.ToString());
        }

        public int GetNoteIndexInOctave(string note) 
        {
            string formatedNote = note;
            if (formatedNote.Length == 1)
            {
                formatedNote += " ";
            }
            int noteIndex = NOTES_NAMES_LIST.IndexOf(formatedNote) / 2;

            return noteIndex;
        }
    }
}
