using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIChordCard
    {
        public void AddChord(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label ChordLabel = new Label();
            ChordLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ChordLabel.Location = getChordLabelPosition(mainForm, guiMidArea);
            ChordLabel.Name = GUIConstants.CHORD_LABEL_NAME;
            ChordLabel.Size = getChordLabelSize(mainForm);
            ChordLabel.TabIndex = 0;
            ChordLabel.Text = mainForm.ArrangerState.GetFormattedChord();
            ChordLabel.ForeColor = GUIConstants.FONT_COLOR;
            ChordLabel.BackColor = GUIConstants.MID_REGION_CARDS_COLOR;
            ChordLabel.FlatStyle = FlatStyle.Flat;
            ChordLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainForm.Controls.Add(ChordLabel);
        }

        public void ResizeChord(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label ChordLabel = (Label)mainForm.Controls.Find(GUIConstants.CHORD_LABEL_NAME, false)[0];
            ChordLabel.Location = getChordLabelPosition(mainForm, guiMidArea);
            ChordLabel.Size = getChordLabelSize(mainForm);
            float fontSize = GUIConstants.MID_PANEL_CONTENT_FONT_SIZE * Convert.ToSingle(ChordLabel.Height) / 65.0F;
            ChordLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private Size getChordLabelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE * .8);
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.TEMPO_LABEL_WIDTH);
            return new Size(width, height);
        }

        private Point getChordLabelPosition(MainForm mainForm, GUIMidArea guiMidArea)
        {
            Size panelSize = guiMidArea.GetMidPanelSize(mainForm);
            int x = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS) * 3;
            x += this.getChordLabelSize(mainForm).Width * 2;
            x += Convert.ToInt32(Convert.ToDouble(panelSize.Width) * GUIConstants.MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN);

            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            y += Convert.ToInt32(Convert.ToDouble(panelSize.Height) * GUIConstants.MID_PANEL_CONTENT_TOP_MARGIN);

            return new Point(x, y);
        }
    }
}
