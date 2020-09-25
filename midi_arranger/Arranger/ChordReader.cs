using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace midi_arranger.Arranger
{
    public class ChordReader
    {
        public void ReadChords(ArrangerState arrangerState)
        {
            try
            {
                string chordsFile = this.getChordsFile();
                string line = "";
                StreamReader reader = new StreamReader(chordsFile);
                bool headerRead = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!headerRead) 
                    {
                        headerRead = true;
                    }
                    else 
                    {
                        Console.WriteLine(line);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error chords definition file, the app will close");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private string getChordsFile()
        {
            return Path.Combine(Application.StartupPath, "Data\\chords.csv");
        }
    }
}
