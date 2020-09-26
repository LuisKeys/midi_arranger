using midi_arranger.Arranger;
using midi_arranger.GUI;
using System;
using System.Windows.Forms;

namespace midi_arranger
{
    public partial class MainForm : Form
    {
        private GUIManager _guiManager;
        private ArrangerState _arrangerState;
        private ArrangerManager _arrangerManager;

        public ArrangerState ArrangerState { get => _arrangerState; set => _arrangerState = value; }
        
        public GUIManager GUIManager { get => _guiManager; set => _guiManager = value; }
        public ArrangerManager ArrangerManager { get => _arrangerManager; set => _arrangerManager = value; }

        public MainForm(ArrangerManager arrangerManager, GUIManager guiManager)
        {
            this.ArrangerManager = arrangerManager;
            this.ArrangerState = arrangerManager.ArrangerState;
            this.GUIManager = guiManager;
            this.ArrangerManager.MidiEventRx += ArrangerManager_MidiEventRx;
            InitializeComponent();
            this.GUIManager.Resize(this);
        }

        private void ArrangerManager_MidiEventRx(object sender, EventArgs e)
        {
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.GUIManager.Resize(this);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ArrangerManager.closeDevices();
                Application.Exit();
            }
        }
    }
}
