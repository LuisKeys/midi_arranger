using midi_arranger.Arranger;
using System;
using System.Collections.Generic;
using System.Linq;
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
                ArrangerState arrangerState = new ArrangerState();
                StylesManager stylesManager = new StylesManager();
                stylesManager.ReadStyles(arrangerState);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(arrangerState));
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}
