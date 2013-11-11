using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Data
{

    public class Activity: INotifyPropertyChanged
    {   
        private bool _unread;
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Time { get; set; }
        public bool Unread
        {
            get { return _unread; }
            set
            {
                _unread = value;
                NotifyPropertyChanged("Unread");
            }
        }

        public Activity(string sender, string subject, string body)
        {
            Sender = sender;
            Subject = subject;
            Body = body;
        }

        public Activity(string sender, string subject, string body, string time, bool unread)
        {
            Sender = sender;
            Subject = subject;
            Body = body;
            Time = time;
            Unread = unread;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}



