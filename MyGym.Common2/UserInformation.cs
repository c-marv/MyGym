using MyGym.Common2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Common2
{
    public class UserInformation
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public Sexo Sex { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public ComplexionFisica PhysicalComplexion { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Nivel LevelActivity { get; set; }
    }
}
