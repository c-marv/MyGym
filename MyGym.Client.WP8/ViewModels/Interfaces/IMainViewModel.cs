using MyGym.Client.WP8.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ObservableCollection<RecipeDataGroup> Recipes { get; }
        RecipeDataGroup SelectedRecipeDataGroup { get; set; }
        void LoadRecipes();
        void SaveRecipesToIS();
        void UpdateTile();
    }
}
