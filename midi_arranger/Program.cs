﻿using midi_arranger.Arranger;
using midi_arranger.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midi_arranger
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\chords.csv");
                ArrangerState arrangerState = new ArrangerState();
                ArrangerManager arrangerManager = new ArrangerManager(arrangerState);
                StylesManager stylesManager = new StylesManager();
                GUIManager guiManager = new GUIManager();
                stylesManager.ReadStyles(arrangerState);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(arrangerManager, guiManager));
            }
            catch(Exception e)
            {
                MessageBox.Show("Fatal error: " + e.Message);
                Application.Exit();
            }
        }
    }
}
