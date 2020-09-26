using midi_arranger.Arranger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midi_arranger.GUI
{
    public class GUIStyltesButtonsGrid
    {
        public void AddStyleButtons(GUIManager guiManager, MainForm mainForm)
        {
            for (int i = 0; i < GUIConstants.STL_NUM_COLUMNS * GUIConstants.STL_NUM_ROWS; ++i)
            {
                List<Style> styles = mainForm.ArrangerState.Styles;
                string styleName = "-- Empty --";
                if (i < styles.Count)
                {
                    styleName = styles[i].Name;
                }
                Point buttonPosition = getStyleButtonPosition(mainForm, i);
                Button styleButton = new System.Windows.Forms.Button();
                styleButton.Font = new System.Drawing.Font("Courier New Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                styleButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                styleButton.Name = GUIConstants.STL_BUTTON_NAME_PREFIX + i.ToString();
                styleButton.Size = getStyleButtonSize(mainForm, GUIConstants.VAR_BUTTON_PADDING);
                styleButton.TabIndex = i;
                styleButton.Text = (i + 1).ToString() + " : " + styleName;
                styleButton.ForeColor = GUIConstants.FONT_COLOR;
                styleButton.BackColor = GUIConstants.STL_COLOR;
                styleButton.FlatStyle = FlatStyle.Flat;
                styleButton.Click += guiManager.StyleButton_Click;
                mainForm.Controls.Add(styleButton);
            }

            Panel stylePanel = new Panel();
            stylePanel.Name = GUIConstants.STL_PANEL_NAME;
            stylePanel.Location = this.getStylePanelPosition(mainForm);
            stylePanel.Size = this.getStylePanelSize(mainForm);
            stylePanel.TabIndex = 0;
            stylePanel.BackColor = GUIConstants.STL_PANEL_COLOR;
            stylePanel.BorderStyle = BorderStyle.FixedSingle;
            mainForm.Controls.Add(stylePanel);
        }

        public void ResizeStyleButtons(GUIManager guiManager, MainForm mainForm)
        {
            Size buttonSize = getStyleButtonSize(mainForm, GUIConstants.STL_BUTTON_PADDING);

            for (int i = 0; i < GUIConstants.STL_NUM_COLUMNS * GUIConstants.STL_NUM_ROWS; ++i)
            {
                Point buttonPosition = getStyleButtonPosition(mainForm, i);
                System.Windows.Forms.Button styleButton = (System.Windows.Forms.Button)mainForm.Controls.Find(GUIConstants.STL_BUTTON_NAME_PREFIX + i.ToString(), false)[0];
                styleButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                styleButton.Size = buttonSize;
                float fontSize = 12F * Convert.ToSingle(buttonSize.Height) / 68.0F;
                styleButton.Font = new System.Drawing.Font(GUIConstants.FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            Panel stylePanel = (Panel)mainForm.Controls.Find(GUIConstants.STL_PANEL_NAME, false)[0];
            stylePanel.Location = this.getStylePanelPosition(mainForm);
            stylePanel.Size = this.getStylePanelSize(mainForm);
        }

        private Size getStyleButtonSize(MainForm mainForm, double padding)
        {
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) / GUIConstants.STL_NUM_COLUMNS);
            width -= Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS * 2.0F / GUIConstants.STL_NUM_COLUMNS);
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.STL_MATRIX_AREA / GUIConstants.STL_NUM_ROWS);
            height -= Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.BLOCKS_PADDING / GUIConstants.STL_NUM_ROWS);
            double net_size_x = (1.0 - padding * 2.0);
            double net_size_y = (1.0 - padding * 10.0);
            int witdh_with_padding = Convert.ToInt32(Convert.ToDouble(width) * net_size_x);
            int height_with_padding = Convert.ToInt32(Convert.ToDouble(height) * net_size_y);
            return new Size(witdh_with_padding, height_with_padding);
        }

        private Point getStyleButtonPosition(MainForm mainForm, int buttonIndex)
        {
            Size buttonSize = getStyleButtonSize(mainForm, 0.0);
            int buttonsCount = Convert.ToInt32(GUIConstants.STL_NUM_COLUMNS * GUIConstants.STL_NUM_ROWS);
            int col = buttonIndex % GUIConstants.STL_NUM_COLUMNS;
            int row = (buttonIndex - col) / GUIConstants.STL_NUM_COLUMNS;
            int x = col * buttonSize.Width;
            int y = row * buttonSize.Height;
            int style_buttons_offset = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.VAR_MATRIX_AREA);
            int blocks_padding = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.BLOCKS_PADDING);

            x += Convert.ToInt32(Convert.ToDouble(buttonSize.Width) * GUIConstants.STL_BUTTON_PADDING);
            x += Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS);

            y += Convert.ToInt32(Convert.ToDouble(buttonSize.Height) * GUIConstants.STL_BUTTON_PADDING);

            y += style_buttons_offset;
            y += blocks_padding;

            return new Point(x, y);
        }

        private Size getStylePanelSize(MainForm mainForm)
        {
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * GUIConstants.STL_MATRIX_AREA * .7);
            int width = mainForm.Width;
            return new Size(width, height);
        }

        private Point getStylePanelPosition(MainForm mainForm)
        {
            GUIVarButtonsGrid guiVarButtonsGrid = new GUIVarButtonsGrid();
            Size varsPanelSize = guiVarButtonsGrid.GetVarPanelSize(mainForm);

            GUIMidArea guiMidArea = new GUIMidArea();
            Size midPanelSize = guiMidArea.GetMidPanelSize(mainForm);
            int x = 0;
            int y = varsPanelSize.Height + midPanelSize.Height;

            return new Point(x, y);
        }
    }
}
