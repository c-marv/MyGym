using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    public class Instruccion
    {
        public int InstruccionID { get; set; }
        public string Content { get; set; }
        public int Step { get; set; }
    }
}
