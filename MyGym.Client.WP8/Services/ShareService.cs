using Microsoft.Phone.Tasks;
using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services
{
    public class ShareService : IShareService
    {
        public void Share(string title, string message)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "destinatario@correo.es";
            emailComposeTask.Subject = title;
            emailComposeTask.Body = message;

            emailComposeTask.Show();
        }
    }
}
