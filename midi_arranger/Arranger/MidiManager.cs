using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Devices;

namespace midi_arranger.Arranger
{
    public class MidiManager
    {
        string _inputDeviceName = "GarageKey";
        InputDevice _inputDevice = null;

        public string InputDeviceName { get => _inputDeviceName; set => _inputDeviceName = value; }
        public InputDevice InputDevice { get => _inputDevice; set => _inputDevice = value; }

        public MidiManager() 
        {
            foreach(var inputDevice in InputDevice.GetAll()) 
            {
                Console.WriteLine(inputDevice.Name);
            }

            this.InputDevice = InputDevice.GetByName(this.InputDeviceName);
        }
    }
}
