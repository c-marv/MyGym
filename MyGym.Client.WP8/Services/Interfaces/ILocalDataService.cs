using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services.Interfaces
{
    public interface ILocalDataService
    {
        IEnumerable<T> Load<T>(string file);
    }
}
