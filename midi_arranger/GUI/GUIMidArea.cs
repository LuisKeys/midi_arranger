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
            Label tempoLabel = new Label();
            tempoLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tempoLabel.Location = getTempoLabelPosition(mainForm);
            tempoLabel.Name = GUIConstants.TEMPO_LABEL_NAME;
            tempoLabel.Size = getTempoLabelSize(mainForm);
            tempoLabel.TabIndex = 0;
            tempoLabel.Text = "Tempo : " + mainForm.ArrangerState.GetFormatedTempo();
            tempoLabel.ForeColor = GUIConstants.FONT_COLOR;
            tempoLabel.BackColor = Color.Black;
            tempoLabel.FlatStyle = FlatStyle.Flat;
            tempoLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainForm.Controls.Add(tempoLabel);

            Panel tempoPanel = new Panel();
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Name = GUIConstants.MID_PANEL_NAME;
            tempoPanel.Size = GetMidPanelSize(mainForm);
            tempoPanel.TabIndex = 0;
            tempoPanel.BackColor = GUIConstants.MID_PANEL_COLOR;
            tempoPanel.BorderStyle = BorderStyle.FixedSingle;
            mainForm.Controls.Add(tempoPanel);
        }

        public void ResizeTempo(GUIManager guiManager, MainForm mainForm)
        {
            Panel tempoPanel = (Panel)mainForm.Controls.Find(GUIConstants.MID_PANEL_NAME, false)[0];
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Size = GetMidPanelSize(mainForm);
            float fontSize = 30F * Convert.ToSingle(tempoPanel.Height) / 81.0F;
            tempoPanel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Label tempoLabel = (Label)mainForm.Controls.Find(GUIConstants.TEMPO_LABEL_NAME, false)[0];
            tempoLabel.Location = getTempoLabelPosition(mainForm);
            tempoLabel.Size = getTempoLabelSize(mainForm);
        }

        public Size GetMidPanelSize(MainForm mainForm) 
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
        private Size getTempoLabelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE * .8);
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.TEMPO_LABEL_WIDTH);
            return new Size(width, height);
        }

        private Point getTempoLabelPosition(MainForm mainForm)
        {
            Size panelSize = this.GetMidPanelSize(mainForm);
            int x = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS);
            x += Convert.ToInt32(Convert.ToDouble(panelSize.Width) * GUIConstants.MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN);
            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            y += Convert.ToInt32(Convert.ToDouble(panelSize.Height) * GUIConstants.MID_PANEL_CONTENT_TOP_MARGIN);

            return new Point(x, y);
        }
    }
}
