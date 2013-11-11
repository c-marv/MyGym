using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Ioc.Interfaces
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
