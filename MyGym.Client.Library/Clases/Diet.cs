using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.Library.Clases
{
    public class Diet
    {
        [JsonProperty("DietID")]
        public int DietID { get; set; }

        [JsonProperty("MealTime")]
        public List<string> MealTime { get; set; }

        [JsonProperty("RecomendationID")]
        public int RecomendationID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ImageURL")]
        public string ImageURL { get; set; }
   

    }

    public class DietResult
    {
        [JsonProperty("success")]
        public bool success { get; set; }

        [JsonProperty("data")]
        public List<Diet> data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
