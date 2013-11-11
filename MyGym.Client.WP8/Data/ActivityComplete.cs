using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Data
{
    public class ActivityComplete : ObservableCollection<Activity>, INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string ContentInfo { get; set; }

        private Activity _lastAlimentReceived;

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public Activity LastAlimentReceived
        {
            get
            {
                return _lastAlimentReceived;
            }
            set
            {
                _lastAlimentReceived = value;
                NotifyPropertyChanged("LastMessageReceived");
            }
        }

        private bool _hasMultipleMessages;

        public bool HasSingleMessage
        {
            get
            {
                return _hasMultipleMessages;
            }
            set
            {
                _hasMultipleMessages = value;
                NotifyPropertyChanged("HasSingleMessage");
            }
        }

        public ActivityComplete(string ci)
            : base()
        {
            ContentInfo = ci;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            LastAlimentReceived = this.Items[0];
            HasSingleMessage = (this.Items.Count > 1) ? false : true;
        }
    }
}
