using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services.Interfaces
{
    public interface IStorageService
    {
        T Load<T>(string fileName);
        void Save<T>(string fileName, T data);
    }
}
