using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIBeatCard
    {
        public void AddBeat(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label BeatLabel = new Label();
            BeatLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, GUIConstants.MID_PANEL_CONTENT_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BeatLabel.Location = getBeatLabelPosition(mainForm, guiMidArea);
            BeatLabel.Name = GUIConstants.BEAT_LABEL_NAME;
            BeatLabel.Size = getBeatLabelSize(mainForm);
            BeatLabel.TabIndex = 0;
            BeatLabel.Text = mainForm.ArrangerState.GetFormattedBeat();
            BeatLabel.ForeColor = GUIConstants.FONT_COLOR;
            BeatLabel.BackColor = GUIConstants.MID_REGION_CARDS_COLOR;
            BeatLabel.FlatStyle = FlatStyle.Flat;
            BeatLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainForm.Controls.Add(BeatLabel);
        }

        public void ResizeBeat(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label BeatLabel = (Label)mainForm.Controls.Find(GUIConstants.BEAT_LABEL_NAME, false)[0];
            BeatLabel.Location = getBeatLabelPosition(mainForm, guiMidArea);
            BeatLabel.Size = getBeatLabelSize(mainForm);
            float fontSize = GUIConstants.MID_PANEL_CONTENT_FONT_SIZE * Convert.ToSingle(BeatLabel.Height) / 65.0F;
            BeatLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private Size getBeatLabelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE * .8);
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.TEMPO_LABEL_WIDTH);
            return new Size(width, height);
        }

        private Point getBeatLabelPosition(MainForm mainForm, GUIMidArea guiMidArea)
        {
            Size panelSize = guiMidArea.GetMidPanelSize(mainForm);
            int x = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS) * 4;
            x += this.getBeatLabelSize(mainForm).Width * 3;
            x += Convert.ToInt32(Convert.ToDouble(panelSize.Width) * GUIConstants.MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN);

            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            y += Convert.ToInt32(Convert.ToDouble(panelSize.Height) * GUIConstants.MID_PANEL_CONTENT_TOP_MARGIN);

            return new Point(x, y);
        }
    }
}
