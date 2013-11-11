using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using MyGym.Client.WP8.ViewModels.Base;

namespace MyGym.Client.WP8.Models
{
    [DataContract]
    public class RecipeDataGroup : RecipeDataCommon
    {
        public RecipeDataGroup()
            : base(String.Empty, String.Empty, String.Empty, String.Empty)
        {
        }

        public RecipeDataGroup(String uniqueId, String title, String shortTitle, String imagePath, String description)
            : base(uniqueId, title, shortTitle, imagePath)
        {
        }

        private bool _licensedRequired;
        public bool LicensedRequired
        {
            get { return _licensedRequired; }
            set { _licensedRequired = value; }
        }

        private ObservableCollection<RecipeDataItem> _items = new ObservableCollection<RecipeDataItem>();
        [DataMember(Name = "group")]
        public ObservableCollection<RecipeDataItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private string _description = string.Empty;
        [DataMember(Name = "description")]
        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                RaisePropertyChanged("Description");
            }
        }

        //private ImageSource _groupImage;
        private string _groupImagePath;
        [DataMember(Name = "groupImage")]
        public string GroupImagePath
        {
            get
            {
                return _groupImagePath;
            }
            set
            {
                _groupImagePath = value;
            }
        }

        [IgnoreDataMember]
        public string GroupImage
        {
            get
            {
                return this._groupImagePath;
            }
            set
            {
                this._groupImagePath = value;
                RaisePropertyChanged("GroupImage");
            }
        }


        public int RecipesCount
        {
            get
            {
                return this.Items.Count;
            }
        }

        public void SetGroupImage(String path)
        {
            //this._groupImage = null;
            this._groupImagePath = path;
            this.RaisePropertyChanged("GroupImage");
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
