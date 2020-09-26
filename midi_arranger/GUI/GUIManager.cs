using midi_arranger.Arranger;
using midi_arranger.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace midi_arranger.GUI
{
    public class GUIManager
    {
        bool guiInialized = false;

        public void Resize(MainForm mainForm)
        {
            if (!guiInialized)
            {
                initGUI(mainForm);
            }
            else
            {
                resizeGUI(mainForm);
            }
        }

        private MainForm _mainForm = null;

        public MainForm MainForm { get => _mainForm; set => _mainForm = value; }

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
            y += Convert.ToInt32(Convert.ToDouble(buttonSize.Y) * GUIConstants.VAR_BUTTON_PADDING);

            x += Convert.ToInt32(Convert.ToDouble(mainForm.Width) * GUIConstants.RIGHT_LEFT_MARGINS / 4.0F);

            return new Point(x, y);
        }

        void initGUI(MainForm mainForm) 
        {
            this.MainForm = mainForm;
            guiInialized = true;
            GUIVarButtonsGrid guiVarButtonsGrid = new GUIVarButtonsGrid();
            guiVarButtonsGrid.AddVarButtons(this, mainForm);

            GUIStyltesButtonsGrid guiStyltesButtonsGrid = new GUIStyltesButtonsGrid();
            guiStyltesButtonsGrid.AddStyleButtons(this, mainForm);

            GUIMidArea guiTempo = new GUIMidArea();
            guiTempo.AddTempo(this, mainForm);

            Button curStyleButton = (Button)MainForm.Controls.Find(GUIConstants.STL_BUTTON_NAME_PREFIX + 0, false)[0];
            curStyleButton.BackColor = GUIConstants.STL_CURRENT_COLOR;
        }

        private void resizeGUI(MainForm mainForm)
        {
            GUIVarButtonsGrid guiVarButtonsGrid = new GUIVarButtonsGrid();
            guiVarButtonsGrid.ResizeVarButtons(this, mainForm);

            GUIStyltesButtonsGrid guiStyltesButtonsGrid = new GUIStyltesButtonsGrid();
            guiStyltesButtonsGrid.ResizeStyleButtons(this, mainForm);

            GUIMidArea guiTempo = new GUIMidArea();
            guiTempo.ResizeTempo(this, mainForm);
        }

        public void StyleButton_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(((Button)sender).Name.Replace(GUIConstants.STL_BUTTON_NAME_PREFIX, ""));
            int prevId = this.MainForm.ArrangerState.CurrentStyle;
            Button prevStyleButton = (Button)MainForm.Controls.Find(GUIConstants.STL_BUTTON_NAME_PREFIX + prevId.ToString(), false)[0];
            prevStyleButton.BackColor = GUIConstants.STL_COLOR;
            Button curStyleButton = (Button)MainForm.Controls.Find(GUIConstants.STL_BUTTON_NAME_PREFIX + id.ToString(), false)[0];
            curStyleButton.BackColor = GUIConstants.STL_CURRENT_COLOR;
            this.MainForm.ArrangerManager.UpdateStyleState(id);
        }

        public void VarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Name.Replace(GUIConstants.VAR_BUTTON_NAME_PREFIX, ""));
            this.MainForm.ArrangerManager.UpdateVariationState(id);
        }
    }
}
