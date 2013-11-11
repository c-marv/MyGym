using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services
{
    public class LocalDataService : ILocalDataService
    {
        public IEnumerable<T> Load<T>(string file)
        {
            var sri = App.GetResourceStream(new Uri(file, UriKind.Relative));
            List<Type> types = new List<Type>();
            types.Add(typeof(T));
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(IEnumerable<T>), types);

            return (IEnumerable<T>)deserializer.ReadObject(sri.Stream);
        }
    }
}
