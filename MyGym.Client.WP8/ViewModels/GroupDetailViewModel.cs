using MyGym.Client.WP8.Models;
using MyGym.Client.WP8.Services.Interfaces;
using MyGym.Client.WP8.ViewModels.Base;
using MyGym.Client.WP8.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.ViewModels
{
    public class GroupDetailViewModel : BindableBase, IGroupDetailViewModel
    {
        #region Privates

        private RecipeDataGroup _recipeGroup;
        private RecipeDataItem _selectedRecipe;

        private INavigationService NavigationService;

        #endregion

        #region Properties

        public RecipeDataGroup RecipeGroup
        {
            get { return _recipeGroup; }
            set { _recipeGroup = value; }
        }

        public RecipeDataItem SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                this.NavigationService.NavigateToRecipeDetailPage(_selectedRecipe);
            }
        }

        #endregion

        #region Constructor

        public GroupDetailViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        #endregion
    }
}
