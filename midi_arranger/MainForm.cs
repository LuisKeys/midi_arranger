using midi_arranger.Arranger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midi_arranger
{
    public partial class MainForm : Form
    {
        private GUIManager _guiManager;
        private ArrangerState _arrangerState;

        public ArrangerState ArrangerState { get => _arrangerState; set => _arrangerState = value; }
        
        public GUIManager GUIManager { get => _guiManager; set => _guiManager = value; }

        public MainForm(ArrangerState arrangerState, GUIManager guiManager)
        {
            this.ArrangerState = arrangerState;
            this.GUIManager = guiManager;
            InitializeComponent();
            this.GUIManager.Resize(this);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.GUIManager.Resize(this);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
