using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.Library.Clases
{
    public class Data
    {
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Nick")]
        public string Nick { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Names")]
        public string Names { get; set; }

        [JsonProperty("Sex")]
        public int Sex { get; set; }

        [JsonProperty("Weight")]
        public double Weight { get; set; }

        [JsonProperty("Height")]
        public double Height { get; set; }

        [JsonProperty("PhysicalComplexion")]
        public int PhysicalComplexion { get; set; }

        [JsonProperty("LevelActivity")]
        public int LevelActivity { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }

    public class DataResult
    {
        [JsonProperty("success")]
        public bool success { get; set; }

        [JsonProperty("data")]
        public Data data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
