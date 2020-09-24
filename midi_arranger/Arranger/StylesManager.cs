using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_arranger.Arranger
{
    public class StylesManager
    {
        public void ReadStyles(ArrangerState arrangerState) 
        {
            StyleReader sr = new StyleReader();
            sr.ReadStyles(arrangerState);
        }
    }
}
