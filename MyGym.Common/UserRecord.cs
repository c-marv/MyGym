using MyGym.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Common
{
    public class UserRecord
    {
        public double Weight { get; set; }
        public double Heigth { get; set; }
        public DateTime Date { get; set; }
        public EstadoNutricional NutritionalStatus { get; set; }
    }
}
