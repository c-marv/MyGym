using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Models
{
    [DataContract]
    public class UserRecipeImages
    {
        #region Constructor

        public UserRecipeImages(string key, ObservableCollection<string> images)
        {
            this.UniqueId = key;
            this.Images = images;
        }

        #endregion

        #region Properties

        [DataMember(Name = "key")]
        public string UniqueId { get; set; }

        [DataMember(Name = "images")]
        public ObservableCollection<string> Images { get; set; }

        #endregion
    }
}
