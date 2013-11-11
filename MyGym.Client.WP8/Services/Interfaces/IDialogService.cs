using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services.Interfaces
{
    public interface IDialogService
    {
        void Show(string message);

        void Show(string message, string caption);
    }
}
