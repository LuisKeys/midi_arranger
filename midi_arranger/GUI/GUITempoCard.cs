using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUITempoCard    {
        public void AddTempo(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label tempoLabel = new Label();
            tempoLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, GUIConstants.MID_PANEL_CONTENT_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tempoLabel.Location = getTempoLabelPosition(mainForm, guiMidArea);
            tempoLabel.Name = GUIConstants.TEMPO_LABEL_NAME;
            tempoLabel.Size = getTempoLabelSize(mainForm);
            tempoLabel.TabIndex = 0;
            tempoLabel.Text = mainForm.ArrangerState.GetFormattedTempo();
            tempoLabel.ForeColor = GUIConstants.FONT_COLOR;
            tempoLabel.BackColor = GUIConstants.MID_REGION_CARDS_COLOR;
            tempoLabel.FlatStyle = FlatStyle.Flat;
            tempoLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainForm.Controls.Add(tempoLabel);
        }

        public void ResizeTempo(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label tempoLabel = (Label)mainForm.Controls.Find(GUIConstants.TEMPO_LABEL_NAME, false)[0];
            tempoLabel.Location = getTempoLabelPosition(mainForm, guiMidArea);
            tempoLabel.Size = getTempoLabelSize(mainForm);
            float fontSize = GUIConstants.MID_PANEL_CONTENT_FONT_SIZE * Convert.ToSingle(tempoLabel.Height) / 65.0F;
            tempoLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private Size getTempoLabelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE * .8);
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.TEMPO_LABEL_WIDTH);
            return new Size(width, height);
        }

        private Point getTempoLabelPosition(MainForm mainForm, GUIMidArea guiMidArea)
        {
            Size panelSize = guiMidArea.GetMidPanelSize(mainForm);
            int x = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS);
            x += Convert.ToInt32(Convert.ToDouble(panelSize.Width) * GUIConstants.MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN);
            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            y += Convert.ToInt32(Convert.ToDouble(panelSize.Height) * GUIConstants.MID_PANEL_CONTENT_TOP_MARGIN);

            return new Point(x, y);
        }
    }
}
