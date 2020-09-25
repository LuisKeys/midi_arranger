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
        string _name = "";
        string _baseNote = "";
        List<int> _intevals = new List<int>();
        List<string> _notes = new List<string>();
        List<string> _sortedNotes = new List<string>();

        public string Name { get => _name; set => _name = value; }
        public string BaseNote { get => _baseNote; set => _baseNote = value; }
        public List<int> Intevals { get => _intevals; set => _intevals = value; }
        public List<string> Notes { get => _notes; set => _notes = value; }
        public List<string> SortedNotes { get => _sortedNotes; set => _sortedNotes = value; }

        public string GetName(ArrangerState arrangerState) 
        {
            this.GetNotes(arrangerState);

            if (this.Notes.Count == 0) return "";

            this.BaseNote = this.SortedNotes[0];

            this.GetIntervals();
            
            return "";
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
                }

                noteNumber++;
            }

            this.GetSortedNotes();
        }

        public string GetNoteName(int noteNUmber) 
        {
            return "C C#D D#E F F#G G#A A#B ".Substring((noteNUmber % 12) * 2, 2);
        }

        public void GetSortedNotes() 
        {
            bool[] notesBuffer = new bool[12];
            this.SortedNotes.Clear();
            
            foreach (string note in this.Notes) 
            {
                string formatedNote = note;
                if(formatedNote.Length == 1) 
                {
                    formatedNote += " ";
                }
                notesBuffer[NOTES_NAMES_LIST.IndexOf(note) / 2] = true;
            }

            int noteIndex = 0;
            foreach (bool note in notesBuffer)
            {
                if (note) 
                {
                    this.SortedNotes.Add(NOTES_NAMES_LIST.Substring(noteIndex * 2, 2).Trim());
                }

                noteIndex++;
            }
        }

        public void GetIntervals() 
        {
            
        }
    }
}
