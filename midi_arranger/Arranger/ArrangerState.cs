using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_arranger.Arranger
{
    public class ArrangerState
    {
        private int _currentStyle = 0;
        private int _currentVariation = 0;
        private List<Style> _styles = new List<Style>();

        public int CurrentStyle { get => _currentStyle; set => _currentStyle = value; }

        public int CurrentVariation { get => _currentVariation; set => _currentVariation = value; }
        
        public List<Style> Styles { get => _styles; set => _styles = value; }

        public void UpdateStyleState(int index) 
        {
            this._currentStyle = index;
        }
        public void UpdateVariationState(int index)
        {
            this._currentVariation = index;
        }
    }
}
