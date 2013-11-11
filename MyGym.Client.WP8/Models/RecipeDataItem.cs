using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Models
{
    [DataContract]
    public class RecipeDataItem : RecipeDataCommon
    {
        public RecipeDataItem()
            : base(String.Empty, String.Empty, String.Empty, String.Empty)
        {
            this._userImages = new ObservableCollection<string>();
        }

        public RecipeDataItem(String uniqueId, String title, String shortTitle, String imagePath, int preptime, String directions, ObservableCollection<string> ingredients, RecipeDataGroup group)
            : base(uniqueId, title, shortTitle, imagePath)
        {
            this._preptime = preptime;
            this._directions = directions;
            this._ingredients = ingredients;
            this._group = group;
            this._userImages = new ObservableCollection<string>();
        }

        private int _preptime = 0;
        [DataMember(Name = "preptime")]
        public int PrepTime
        {
            get { return this._preptime; }
            set
            {
                this._preptime = value;
                RaisePropertyChanged("PrepTime");
            }
        }

        private string _directions = string.Empty;
        [DataMember(Name = "directions")]
        public string Directions
        {
            get { return this._directions; }
            set
            {
                this._directions = value;
                RaisePropertyChanged("Directions");
            }
        }

        private ObservableCollection<string> _userImages;
        [DataMember(Name = "userImages")]
        public ObservableCollection<string> UserImages
        {
            get { return this._userImages; }
            set
            {
                this._userImages = value;
                RaisePropertyChanged("UserImages");
            }
        }

        private ObservableCollection<string> _ingredients;
        [DataMember(Name = "ingredients")]
        public ObservableCollection<string> Ingredients
        {
            get { return this._ingredients; }
            set
            {
                this._ingredients = value;
                RaisePropertyChanged("Ingredients");
            }
        }

        private RecipeDataGroup _group;
        [DataMember(Name = "group")]
        public RecipeDataGroup Group
        {
            get { return this._group; }
            set
            {
                this._group = value;
                RaisePropertyChanged("Group");
            }
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
