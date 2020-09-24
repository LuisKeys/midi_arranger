using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_arranger.Arranger
{
    public class Style
    {
        private string _name = "";
        private string _description = "";
        private List<Variation> _variations = new List<Variation>();

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }

        public List<Variation> Variations { get => _variations; set => _variations = value; }
    }
}
