using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyGym.Client.WP8.Services
{
    public class StorageService : IStorageService
    {
        // Constructor
        public StorageService()
        {
        }

        // Deserializa un objeto de un fichero
        public T Load<T>(string fileName)
        {
            // Accede al Isolated Storage
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myIsolatedStorage.FileExists(fileName))
                {
                    // El fichero no existe.
                    return default(T);
                }

                // El fichero existe. Abrelo
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(fileName, FileMode.Open))
                {
                    // Deserializa el contenido
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    T data = (T)xml.Deserialize(stream);
                    return data;
                }
            }
        }

        // Serializa un objeto a fichero
        public void Save<T>(string fileName, T data)
        {
            try
            {
                // Accede al Isolated Storage
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    // Crea un fichero para el contenido
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(fileName))
                    {
                        // Serializa el objeto al fichero
                        XmlSerializer xml = new XmlSerializer(typeof(T));
                        xml.Serialize(fileStream, data);
                    }
                }
            }
            catch
            {
                //Log.
            }
        }
    }
}