using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public class BloomVariable
    {
        public bool bloomVariable;
        public BloomVariable()
        {
               bloomVariable = false;
        }
        public void SetVariableFlip()
        {
            bloomVariable = !bloomVariable;
        }
    }
}
