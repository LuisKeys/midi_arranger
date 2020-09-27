using System;
using System.Drawing;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIVarButtonsGrid
    {
        public void AddVarButtons(GUIManager guiManager, MainForm mainForm)
        {
            Point buttonSize = getVarButtonSize(mainForm, GUIConstants.VAR_BUTTON_PADDING);

            for (int i = 0; i < GUIConstants.VAR_NUM_COLUMNS * GUIConstants.VAR_NUM_ROWS; ++i)
            {
                Point buttonPosition = getVarButtonPosition(mainForm, i);
                Button varButton = new System.Windows.Forms.Button();
                varButton.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                varButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                varButton.Name = GUIConstants.VAR_BUTTON_NAME_PREFIX + i.ToString();
                varButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                varButton.TabIndex = i;
                varButton.Text = (i + 1).ToString();
                varButton.ForeColor = GUIConstants.FONT_COLOR;
                varButton.BackColor = GUIConstants.EMPTY_VAR_COLOR;
                varButton.FlatStyle = FlatStyle.Flat;
                varButton.Click += guiManager.VarButton_Click;
                mainForm.Controls.Add(varButton);
            }

            Panel varPanel = new Panel();
            varPanel.Name = GUIConstants.VAR_PANEL_NAME;
            varPanel.Location = this.getVarPanelPosition(mainForm);
            varPanel.Size = this.GetVarPanelSize(mainForm);
            varPanel.TabIndex = 0;
            varPanel.BackColor = GUIConstants.VAR_PANEL_COLOR;
            varPanel.BorderStyle = BorderStyle.FixedSingle;
            mainForm.Controls.Add(varPanel);
        }

        public void ResizeVarButtons(GUIManager guiManager, MainForm mainForm)
        {
            Point buttonSize = getVarButtonSize(mainForm, GUIConstants.VAR_BUTTON_PADDING);

            for (int i = 0; i < GUIConstants.VAR_NUM_COLUMNS * GUIConstants.VAR_NUM_ROWS; ++i)
            {
                Point buttonPosition = getVarButtonPosition(mainForm, i);
                System.Windows.Forms.Button varButton = (System.Windows.Forms.Button)mainForm.Controls.Find(GUIConstants.VAR_BUTTON_NAME_PREFIX + i.ToString(), false)[0];
                varButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                varButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                float fontSize = 12F * Convert.ToSingle(buttonSize.Y) / 166.0F;
                varButton.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            Panel varPanel = (Panel)mainForm.Controls.Find(GUIConstants.VAR_PANEL_NAME, false)[0];
            varPanel.Location = this.getVarPanelPosition(mainForm);
            varPanel.Size = this.GetVarPanelSize(mainForm);
        }

        private Point getVarButtonSize(MainForm mainForm, double padding)
        {
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) / GUIConstants.VAR_NUM_COLUMNS);
            width -= Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS * 2.0F / GUIConstants.VAR_NUM_COLUMNS);

            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA / GUIConstants.VAR_NUM_ROWS);
            double net_size = (1.0 - padding * 2.0);
            int witdh_with_padding = Convert.ToInt32(Convert.ToDouble(width) * net_size);
            int height_with_padding = Convert.ToInt32(Convert.ToDouble(height) * net_size);
            return new Point(witdh_with_padding, height_with_padding);
        }

        private Point getVarButtonPosition(MainForm mainForm, int buttonIndex)
        {
            Point buttonSize = getVarButtonSize(mainForm, 0.0);
            int buttonsCount = Convert.ToInt32(GUIConstants.VAR_NUM_COLUMNS * GUIConstants.VAR_NUM_ROWS);
            int col = buttonIndex % GUIConstants.VAR_NUM_COLUMNS;
            int row = (buttonIndex - col) / GUIConstants.VAR_NUM_COLUMNS;
            int x = col * buttonSize.X;
            int y = row * buttonSize.Y;

            x += Convert.ToInt32(Convert.ToDouble(buttonSize.X) * GUIConstants.VAR_BUTTON_PADDING);
            x += Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS);

            y += Convert.ToInt32(Convert.ToDouble(buttonSize.Y) * GUIConstants.VAR_BUTTON_PADDING);


            return new Point(x, y);
        }

        public Size GetVarPanelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            int width = mainForm.Width;
            return new Size(width, height);
        }

        private Point getVarPanelPosition(MainForm mainForm)
        {
            int x = 0;
            int y = 0;

            return new Point(x, y);
        }

    }
}
