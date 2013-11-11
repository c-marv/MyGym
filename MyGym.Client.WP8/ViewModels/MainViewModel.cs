using MyGym.Client.WP8.Models;
using MyGym.Client.WP8.Services.Interfaces;
using MyGym.Client.WP8.ViewModels.Base;
using MyGym.Client.WP8.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.ViewModels
{
    public class MainViewModel : BindableBase, IMainViewModel
    {
        #region Privates

        private RecipeDataGroup _recipeDataGroup;
        private RecipeRepository _recipeRepository = new RecipeRepository();

        // Servicios dependientes de la plataforma que necesitamos en este ViewModel
        private IStorageService StorageService;
        private ILocalDataService LocalDataService;
        private INavigationService NavigationService;
        private ILiveTileService LiveTileService;
        #endregion

        #region Properties

        public ObservableCollection<RecipeDataGroup> Recipes { get { return this._recipeRepository.ItemGroups; } }

        public RecipeDataGroup SelectedRecipeDataGroup
        {
            get { return _recipeDataGroup; }
            set
            {
                _recipeDataGroup = value;
                this.NavigationService.NavigateToGroupDetailPage(_recipeDataGroup);
            }
        }

        #endregion

        #region Constructor

        public MainViewModel(ILocalDataService localDataService, IStorageService storageService, INavigationService navigationService,
            ILiveTileService liveTileService)
        {
            this.LocalDataService = localDataService;
            this.StorageService = storageService;
            this.NavigationService = navigationService;
            this.LiveTileService = liveTileService;
        }

        #endregion

        #region Methods

        // Carga la colección de recetas
        public void LoadRecipes()
        {
            IEnumerable<RecipeDataItem> recipes =
                new ObservableCollection<RecipeDataItem>((this.LocalDataService.Load<RecipeDataItem>("Data\\Recipes.txt").ToList()));

            List<string> IDs = new List<string>();
            RecipeDataGroup group = null;
            foreach (var recipe in recipes)
            {
                if (!IDs.Contains(recipe.Group.UniqueId))
                {
                    group = recipe.Group;
                    group.Items = new ObservableCollection<RecipeDataItem>();
                    IDs.Add(recipe.Group.UniqueId);
                    _recipeRepository.ItemGroups.Add(group);
                }

                _recipeRepository.AssignedUserImages(recipe);
                group.Items.Add(recipe);
            }
        }

        // Guarda la colección de cartas a disco
        public void SaveRecipesToIS()
        {
            this.StorageService.Save<ObservableCollection<RecipeDataGroup>>("RecipesFile",
                this._recipeRepository.ItemGroups
            );
        }

        public void UpdateTile()
        {
            // Título
            this.LiveTileService.Title = "Recetario";
            this.LiveTileService.BackTitle = "WP8";

            // Contador
            this.LiveTileService.Count = this._recipeRepository.ItemGroups.Count;

            // Texto
            this.LiveTileService.BackContent = "SecondNug";

            // Actualiza el live tile
            this.LiveTileService.UpdateTile();
        }

        #endregion
    }
}
