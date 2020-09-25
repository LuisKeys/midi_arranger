using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midi_arranger.Arranger
{
    public class StyleReader
    {
        public void ReadStyles(ArrangerState arrangerState)
        {
            try
            {
                arrangerState.Styles.Clear();
                string stylePath = this.getStylesFolder();
                String[] stylesFiles = Directory.GetFiles(stylePath);
                foreach(string styleFile in stylesFiles) 
                {
                    readStyle(arrangerState, styleFile);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading styles, the app will close");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private void readStyle(ArrangerState arrangerState, string styleFile) 
        {
            Style style = new Style();
            string line = "";
            StreamReader reader = new StreamReader(styleFile);
            while((line = reader.ReadLine()) != null)
            {
                this.processStyleLine(style, line);
            }
            reader.Close();
            arrangerState.Styles.Add(style);
        }

        private void processStyleLine(Style style, string line) 
        {
            string descriptor = line.Split('=')[0].Trim().ToLower();
            string value = line.Split('=')[1].Trim();
            switch (descriptor) 
            {
                case "name":
                    style.Name = value;
                    break;

                case "description":
                    style.Description = value;
                    break;
            }
        }

        private string getStylesFolder() 
        {
            string stylePath = Path.Combine(Application.StartupPath, "Data\\Styles");
            if (!Directory.Exists(stylePath)) 
            {
                Directory.CreateDirectory(stylePath);
            }

            return stylePath;
        }
    }
}
