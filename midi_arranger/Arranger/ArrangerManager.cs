using System;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Core;

namespace midi_arranger.Arranger
{
    public class ArrangerManager
    {
        public event EventHandler MidiEventRx;

        ArrangerState _arrangerState = null;
        MidiManager _midiManager = null;

        public ArrangerState ArrangerState { get => _arrangerState; set => _arrangerState = value; }
        public MidiManager MidiManager { get => _midiManager; set => _midiManager = value; }

        public ArrangerManager(ArrangerState arrangerState)
        {
            try
            {
                this._arrangerState = arrangerState;
                this.MidiManager = new MidiManager();
                this.MidiManager.InputDevice.EventReceived += InputDevice_EventReceived; ;
                this.MidiManager.InputDevice.StartEventsListening();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error opening MIDI ports: " + e.Message);
                throw;
            }

            try
            {
                ChordReader chordReader = new ChordReader();
                chordReader.ReadChords(this.ArrangerState);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading chords file: " + e.Message);
                throw;
            }
        }

        public void closeDevices()
        {
            this.MidiManager.InputDevice.StartEventsListening();
            this.MidiManager.InputDevice.Dispose();
        }

        private void InputDevice_EventReceived(object sender, Melanchall.DryWetMidi.Devices.MidiEventReceivedEventArgs e)
        {
            EventHandler handler = MidiEventRx;
            if (null != handler) handler(this, e);
            this.ArrangerState.UpdateVirtualKeyboard(e.Event);
        }

        public void UpdateStyleState(int index)
        {
            this.ArrangerState.CurrentStyle = index;
        }

        public void UpdateVariationState(int index)
        {
            this.ArrangerState.CurrentVariation = index;
        }

    }
}
