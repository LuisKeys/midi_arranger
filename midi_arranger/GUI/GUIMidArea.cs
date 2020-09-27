using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIMidArea
    {
        public void AddMidRegions(GUIManager guiManager, MainForm mainForm)
        {
            GUITempoCard guiTempo = new GUITempoCard();
            guiTempo.AddTempo(guiManager, mainForm, this);

            GUITimeSignatureCard guiTimeSignature = new GUITimeSignatureCard();
            guiTimeSignature.AddTimeSignature(guiManager, mainForm, this);

            GUIChordCard guiChordCard = new GUIChordCard();
            guiChordCard.AddChord(guiManager, mainForm, this);

            GUIBeatCard guiBeatCard = new GUIBeatCard();
            guiBeatCard.AddBeat(guiManager, mainForm, this);

            Panel tempoPanel = new Panel();
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Name = GUIConstants.MID_PANEL_NAME;
            tempoPanel.Size = GetMidPanelSize(mainForm);
            tempoPanel.TabIndex = 0;
            tempoPanel.BackColor = GUIConstants.MID_PANEL_COLOR;
            tempoPanel.BorderStyle = BorderStyle.FixedSingle;
            mainForm.Controls.Add(tempoPanel);
        }

        public void ResizeMidRegions(GUIManager guiManager, MainForm mainForm)
        {
            Panel tempoPanel = (Panel)mainForm.Controls.Find(GUIConstants.MID_PANEL_NAME, false)[0];
            tempoPanel.Location = getMidPanelPosition(mainForm);
            tempoPanel.Size = GetMidPanelSize(mainForm);
            float fontSize = GUIConstants.MID_PANEL_CONTENT_FONT_SIZE * Convert.ToSingle(tempoPanel.Height) / 81.0F;
            tempoPanel.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            GUITempoCard guiTempo = new GUITempoCard();
            guiTempo.ResizeTempo(guiManager, mainForm, this);

            GUITimeSignatureCard guiTimeSignature = new GUITimeSignatureCard();
            guiTimeSignature.ResizeTimeSignature(guiManager, mainForm, this);

            GUIChordCard guiChordCard = new GUIChordCard();
            guiChordCard.ResizeChord(guiManager, mainForm, this);

            GUIBeatCard guiBeatCard = new GUIBeatCard();
            guiBeatCard.ResizeBeat(guiManager, mainForm, this);
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
    }
}
