using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyGym.Client.WP8.Services
{
    public class DialogService : IDialogService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }

        public void Show(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);
        }
    }
}
