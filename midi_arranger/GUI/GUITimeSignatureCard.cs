using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUITimeSignatureCard
    {
        public void AddTimeSignature(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label TimeSignatureLabel = new Label();
            TimeSignatureLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, GUIConstants.MID_PANEL_CONTENT_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimeSignatureLabel.Location = getTimeSignatureLabelPosition(mainForm, guiMidArea);
            TimeSignatureLabel.Name = GUIConstants.TIME_SIGNATURE_LABEL_NAME;
            TimeSignatureLabel.Size = getTimeSignatureLabelSize(mainForm);
            TimeSignatureLabel.TabIndex = 0;
            TimeSignatureLabel.Text = mainForm.ArrangerState.GetFormattedTimeSignature();
            TimeSignatureLabel.ForeColor = GUIConstants.FONT_COLOR;
            TimeSignatureLabel.BackColor = GUIConstants.MID_REGION_CARDS_COLOR;
            TimeSignatureLabel.FlatStyle = FlatStyle.Flat;
            TimeSignatureLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainForm.Controls.Add(TimeSignatureLabel);
        }

        public void ResizeTimeSignature(GUIManager guiManager, MainForm mainForm, GUIMidArea guiMidArea)
        {
            Label TimeSignatureLabel = (Label)mainForm.Controls.Find(GUIConstants.TIME_SIGNATURE_LABEL_NAME, false)[0];
            TimeSignatureLabel.Location = getTimeSignatureLabelPosition(mainForm, guiMidArea);
            TimeSignatureLabel.Size = getTimeSignatureLabelSize(mainForm);
            float fontSize = GUIConstants.MID_PANEL_CONTENT_FONT_SIZE * Convert.ToSingle(TimeSignatureLabel.Height) / 65.0F;
            TimeSignatureLabel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private Size getTimeSignatureLabelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.MID_PANEL_SIZE * .8);
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.TEMPO_LABEL_WIDTH);
            return new Size(width, height);
        }

        private Point getTimeSignatureLabelPosition(MainForm mainForm, GUIMidArea guiMidArea)
        {
            Size panelSize = guiMidArea.GetMidPanelSize(mainForm);
            int x = Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS) * 2;
            x += this.getTimeSignatureLabelSize(mainForm).Width;
            x += Convert.ToInt32(Convert.ToDouble(panelSize.Width) * GUIConstants.MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN);

            int y = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            y += Convert.ToInt32(Convert.ToDouble(panelSize.Height) * GUIConstants.MID_PANEL_CONTENT_TOP_MARGIN);

            return new Point(x, y);
        }
    }
}
