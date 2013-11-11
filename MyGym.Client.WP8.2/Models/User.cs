using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8._2.Models
{
    public class User : INotifyPropertyChanged
    {
        public string email;
        public string password;
        public string nick;
        public string firstName;
        public string lastName;
        public string names;
        public int sexo;
        public int physicalComplexion;
        public int levelActivity;
        public double weight;
        public double height;
        public DateTime dateOfBirth;
        public string Email { get { return email; } set { email = value; ChangedProperty("Email"); } }
        public string Password { get { return password; } set { password = value; ChangedProperty("Password"); } }
        public string Nick { get { return nick; } set { nick = value; ChangedProperty("Nick"); } }
        public string FirstName { get { return firstName; } set { firstName = value; ChangedProperty("FirstName"); } }
        public string LastName { get { return lastName; } set { lastName = value; ChangedProperty("LastName"); } }
        public string Names { get { return names; } set { names = value; ChangedProperty("Names"); } }
        public int Sexo { get { return sexo; } set { sexo = value; ChangedProperty("Sexo"); } }
        public int PhysicalComplexion { get { return physicalComplexion; } set { physicalComplexion = value; ChangedProperty("PhysicalComplexion"); } }
        public int LevelActivity { get { return levelActivity; } set { levelActivity = value; ChangedProperty("LevelActivity"); } }
        public double Weight { get { return weight; } set { weight = value; ChangedProperty("Weight"); } }
        public double Height { get { return height; } set { height = value; ChangedProperty("Height"); } }
        public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; ChangedProperty("DateOfBirth"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangedProperty(string nameprop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameprop));
            }
        }
    }
}
