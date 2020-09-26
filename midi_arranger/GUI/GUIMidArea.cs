using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIMidArea
    {
        public void AddTempo(GUIManager guiManager, MainForm mainForm)
        {
            Panel tempoPanel = new Panel();
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Name = GUIConstants.MID_PANEL_NAME;
            tempoPanel.Size = getTempoPanelSize(mainForm);
            tempoPanel.TabIndex = 0;
            tempoPanel.BackColor = Color.Black;
            tempoPanel.BorderStyle = BorderStyle.FixedSingle;
            mainForm.Controls.Add(tempoPanel);
        }

        public void ResizeTempo(GUIManager guiManager, MainForm mainForm)
        {
            Panel tempoPanel = (Panel)mainForm.Controls.Find(GUIConstants.MID_PANEL_NAME, false)[0];
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Size = getTempoPanelSize(mainForm);
        }

        public Size getTempoPanelSize(MainForm mainForm) 
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE);
            int width = mainForm.Width;
            return new Size(width, height);
        }

        private Point getMidPanelPosition(MainForm mainForm) 
        {
            int x = 0;
            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);

            return new Point(x, y);
        }
    }
}
