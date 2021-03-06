﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_arranger.GUI
{
    public class GUIConstants
    {
        public const string FONT_FAMILY = "Courier New Bold";

        public const int VAR_NUM_COLUMNS = 8;
        public const int VAR_NUM_ROWS = 2;
        public const double VAR_MATRIX_AREA = 0.4;
        public const double VAR_BUTTON_PADDING = 0.05;
        public const string VAR_BUTTON_NAME_PREFIX = "var_";
        public const string VAR_PANEL_NAME = "var_panel";

        public const int STL_NUM_COLUMNS = 4;
        public const int STL_NUM_ROWS = 4;
        public const double STL_MATRIX_AREA = 0.6;
        public const string STL_BUTTON_NAME_PREFIX = "style_";
        public const double STL_BUTTON_PADDING = 0.02;
        public const string STL_PANEL_NAME = "style_panel";

        public const double BLOCKS_PADDING = 0.2;
        public const double RIGHT_LEFT_MARGINS = 0.01;

        public const double MID_PANEL_SIZE = 0.18;
        public const string MID_PANEL_NAME = "mid_panel";
        public const double MID_PANEL_CONTENT_TOP_MARGIN = 0.1;
        public const double MID_PANEL_CONTENT_RIGHT_LEFT_MARGIN = 0.005;
        public const float MID_PANEL_CONTENT_FONT_SIZE = 35F;
        public const string TEMPO_LABEL_NAME = "tempo_label";
        public const double TEMPO_LABEL_WIDTH = 0.235;
        public const string TIME_SIGNATURE_LABEL_NAME = "time_signature_label";
        public const double TIME_SIGNATURE_LABEL_WIDTH = 0.235;
        public const string CHORD_LABEL_NAME = "chord_label";
        public const double CHORD_LABEL_WIDTH = 0.235;
        public const string BEAT_LABEL_NAME = "beat_label";
        public const double BEAT_LABEL_WIDTH = 0.235;

        public static Color EMPTY_VAR_COLOR = Color.Black;
        public static Color INTRO_VAR_COLOR = Color.FromArgb(1, 158, 255);
        public static Color LOOP_VAR_COLOR = Color.FromArgb(255, 219, 35);
        public static Color FILL_VAR_COLOR = Color.FromArgb(0, 229, 90);
        public static Color ENDING_VAR_COLOR = Color.FromArgb(255, 58, 73);
        public static Color FONT_COLOR = Color.White;
        public static Color STL_COLOR = Color.Black;
        public static Color STL_CURRENT_COLOR = Color.FromArgb(1, 158, 255);
        public static Color MID_REGION_CARDS_COLOR = Color.Black;

        public static Color VAR_PANEL_COLOR = Color.FromArgb(60, 1, 158, 255);
        public static Color MID_PANEL_COLOR = Color.FromArgb(100, 1, 158, 255);
        public static Color STL_PANEL_COLOR = Color.FromArgb(60, 1, 158, 255);
    }
}
