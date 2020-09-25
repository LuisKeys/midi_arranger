using midi_arranger.Arranger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace midi_arranger
{
    public class GUIManager
    {
        const string FONT_FAMILY = "Courier New Bold";
        
        const int VAR_NUM_COLUMNS = 8;
        const int VAR_NUM_ROWS = 2;
        const double VAR_MATRIX_AREA = 0.4;
        const double VAR_BUTTON_PADDING = 0.05;
        const string VAR_BUTTON_NAME_PREFIX = "var_";

        const int STL_NUM_COLUMNS = 4;
        const int STL_NUM_ROWS = 4;
        const double STL_MATRIX_AREA = 0.5;
        const string STL_BUTTON_NAME_PREFIX = "style_";
        const double STL_BUTTON_PADDING = 0.02;

        const double BLOCKS_PADDING = 0.1;
        const double RIGHT_LEFT_MARGINS = 0.01;

        Color EMPTY_VAR_COLOR = Color.Black;
        Color INTRO_VAR_COLOR = Color.FromArgb(1, 158, 255);
        Color LOOP_VAR_COLOR = Color.FromArgb(255, 219, 35);
        Color FILL_VAR_COLOR = Color.FromArgb(0, 229, 90);
        Color ENDING_VAR_COLOR = Color.FromArgb(255, 58, 73);
        Color FONT_COLOR  = Color.White;
        Color STL_COLOR = Color.Black;
        Color STL_CURRENT_COLOR = Color.FromArgb(1, 158, 255);

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
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) / VAR_NUM_COLUMNS);
            width -= Convert.ToInt32(Convert.ToDouble(mainForm.Width) * RIGHT_LEFT_MARGINS * 2.0F / VAR_NUM_COLUMNS);

            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * VAR_MATRIX_AREA / VAR_NUM_ROWS);
            double net_size = (1.0 - padding * 2.0);
            int witdh_with_padding = Convert.ToInt32(Convert.ToDouble(width) * net_size);
            int height_with_padding = Convert.ToInt32(Convert.ToDouble(height) * net_size);
            return new Point(witdh_with_padding, height_with_padding);
        }

        private Point getVarButtonPosition(MainForm mainForm, int buttonIndex)
        {
            Point buttonSize = getVarButtonSize(mainForm, 0.0);
            int buttonsCount = Convert.ToInt32(VAR_NUM_COLUMNS * VAR_NUM_ROWS);
            int col = buttonIndex % VAR_NUM_COLUMNS;
            int row = (buttonIndex - col) / VAR_NUM_COLUMNS;
            int x = col * buttonSize.X;
            int y = row * buttonSize.Y;

            x += Convert.ToInt32(Convert.ToDouble(buttonSize.X) * VAR_BUTTON_PADDING);
            y += Convert.ToInt32(Convert.ToDouble(buttonSize.Y) * VAR_BUTTON_PADDING);

            x += Convert.ToInt32(Convert.ToDouble(mainForm.Width) * RIGHT_LEFT_MARGINS / 4.0F);

            return new Point(x, y);
        }

        private Point getStyleButtonSize(MainForm mainForm, double padding)
        {
            int width = Convert.ToInt32(Convert.ToDouble(mainForm.Width) / STL_NUM_COLUMNS);
            width -= Convert.ToInt32(Convert.ToDouble(mainForm.Width) * RIGHT_LEFT_MARGINS * 2.0F / STL_NUM_COLUMNS);
            int height = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * STL_MATRIX_AREA / STL_NUM_ROWS);
            height -= Convert.ToInt32(Convert.ToDouble(mainForm.Height) * BLOCKS_PADDING / STL_NUM_ROWS);
            double net_size_x = (1.0 - padding * 2.0);
            double net_size_y = (1.0 - padding * 10.0);
            int witdh_with_padding = Convert.ToInt32(Convert.ToDouble(width) * net_size_x);
            int height_with_padding = Convert.ToInt32(Convert.ToDouble(height) * net_size_y);
            return new Point(witdh_with_padding, height_with_padding);
        }

        private Point getStyleButtonPosition(MainForm mainForm, int buttonIndex)
        {
            Point buttonSize = getStyleButtonSize(mainForm, 0.0);
            int buttonsCount = Convert.ToInt32(STL_NUM_COLUMNS * STL_NUM_ROWS);
            int col = buttonIndex % STL_NUM_COLUMNS;
            int row = (buttonIndex - col) / STL_NUM_COLUMNS;
            int x = col * buttonSize.X;
            int y = row * buttonSize.Y;
            int style_buttons_offset = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * VAR_MATRIX_AREA);
            int blocks_padding = Convert.ToInt32(Convert.ToDouble(mainForm.Height) * BLOCKS_PADDING);

            x += Convert.ToInt32(Convert.ToDouble(buttonSize.X) * STL_BUTTON_PADDING);
            y += Convert.ToInt32(Convert.ToDouble(buttonSize.Y) * STL_BUTTON_PADDING);

            x += Convert.ToInt32(Convert.ToDouble(mainForm.Width) * RIGHT_LEFT_MARGINS / 4.0F);

            y += style_buttons_offset;
            y += blocks_padding;

            return new Point(x, y);
        }

        void initGUI(MainForm mainForm) 
        {
            this.MainForm = mainForm;
            guiInialized = true;
            Point buttonSize = getVarButtonSize(mainForm, VAR_BUTTON_PADDING);

            for (int i = 0; i < VAR_NUM_COLUMNS * VAR_NUM_ROWS; ++i) 
            {
                Point buttonPosition = getVarButtonPosition(mainForm, i);
                Button varButton = new System.Windows.Forms.Button();
                varButton.Font = new System.Drawing.Font(FONT_FAMILY, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                varButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                varButton.Name = VAR_BUTTON_NAME_PREFIX + i.ToString();
                varButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                varButton.TabIndex = i;
                varButton.Text = (i + 1).ToString();
                varButton.ForeColor = FONT_COLOR;
                varButton.BackColor = EMPTY_VAR_COLOR;
                varButton.FlatStyle = FlatStyle.Flat;
                varButton.Click += VarButton_Click;
                mainForm.Controls.Add(varButton);
            }
            
            buttonSize = getStyleButtonSize(mainForm, VAR_BUTTON_PADDING);

            for (int i = 0; i < STL_NUM_COLUMNS * STL_NUM_ROWS; ++i)
            {
                List <Style> styles = mainForm.ArrangerState.Styles;
                string styleName = "-- Empty --";
                if(i < styles.Count) 
                {
                    styleName = styles[i].Name;
                }
                Point buttonPosition = getStyleButtonPosition(mainForm, i);
                Button styleButton = new System.Windows.Forms.Button();
                styleButton.Font = new System.Drawing.Font("Courier New Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                styleButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                styleButton.Name = STL_BUTTON_NAME_PREFIX + i.ToString();
                styleButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                styleButton.TabIndex = i;
                styleButton.Text = (i + 1).ToString() + " : " + styleName;
                styleButton.ForeColor = FONT_COLOR;
                styleButton.BackColor = STL_COLOR;
                styleButton.FlatStyle = FlatStyle.Flat;
                styleButton.Click += StyleButton_Click;
                mainForm.Controls.Add(styleButton);
            }

            Button curStyleButton = (Button)MainForm.Controls.Find(STL_BUTTON_NAME_PREFIX + 0, false)[0];
            curStyleButton.BackColor = STL_CURRENT_COLOR;

        }

        private void resizeGUI(MainForm mainForm)
        {
            guiInialized = true;
            Point buttonSize = getVarButtonSize(mainForm, VAR_BUTTON_PADDING);

            for (int i = 0; i < VAR_NUM_COLUMNS * VAR_NUM_ROWS; ++i)
            {
                Point buttonPosition = getVarButtonPosition(mainForm, i);
                System.Windows.Forms.Button varButton = (System.Windows.Forms.Button)mainForm.Controls.Find(VAR_BUTTON_NAME_PREFIX + i.ToString(), false)[0];
                varButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                varButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                float fontSize = 12F * Convert.ToSingle(buttonSize.Y) / 166.0F;
                varButton.Font = new System.Drawing.Font(FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            buttonSize = getStyleButtonSize(mainForm, STL_BUTTON_PADDING);

            for (int i = 0; i < STL_NUM_COLUMNS * STL_NUM_ROWS; ++i)
            {
                Point buttonPosition = getStyleButtonPosition(mainForm, i);
                System.Windows.Forms.Button styleButton = (System.Windows.Forms.Button)mainForm.Controls.Find(STL_BUTTON_NAME_PREFIX + i.ToString(), false)[0];
                styleButton.Location = new System.Drawing.Point(buttonPosition.X, buttonPosition.Y);
                styleButton.Size = new System.Drawing.Size(buttonSize.X, buttonSize.Y);
                float fontSize = 12F * Convert.ToSingle(buttonSize.Y) / 68.0F;
                styleButton.Font = new System.Drawing.Font(FONT_FAMILY, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

        }

        private void StyleButton_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(((Button)sender).Name.Replace(STL_BUTTON_NAME_PREFIX, ""));
            int prevId = this.MainForm.ArrangerState.CurrentStyle;
            Button prevStyleButton = (Button)MainForm.Controls.Find(STL_BUTTON_NAME_PREFIX + prevId.ToString(), false)[0];
            prevStyleButton.BackColor = STL_COLOR;
            Button curStyleButton = (Button)MainForm.Controls.Find(STL_BUTTON_NAME_PREFIX + id.ToString(), false)[0];
            curStyleButton.BackColor = STL_CURRENT_COLOR;
            this.MainForm.ArrangerManager.UpdateStyleState(id);
        }

        private void VarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Name.Replace(VAR_BUTTON_NAME_PREFIX, ""));
            this.MainForm.ArrangerManager.UpdateVariationState(id);
        }
    }
}
