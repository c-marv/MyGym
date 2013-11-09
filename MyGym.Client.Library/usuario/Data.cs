using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.Library.usuario
{
    public class Data
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public int Sex { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int PhysicalComplexion { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class RootObject
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}
