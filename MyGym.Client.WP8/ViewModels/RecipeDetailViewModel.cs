using MyGym.Client.WP8.Models;
using MyGym.Client.WP8.Services.Interfaces;
using MyGym.Client.WP8.ViewModels.Base;
using MyGym.Client.WP8.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGym.Client.WP8.ViewModels
{
    public class RecipeDetailViewModel : BindableBase, IRecipeDetailViewModel
    {
        #region Privates

        private RecipeDataItem _recipeItem;

        private ILiveTileService LiveTileService;
        private IDialogService DialogService;
        private INavigationService NavigationService;
        private IReminderService ReminderService;
        private IShareService ShareService;

        #endregion

        #region Properties

        public RecipeDataItem RecipeItem
        {
            get { return _recipeItem; }
            set { _recipeItem = value; }
        }

        #endregion

        #region Constructor

        public RecipeDetailViewModel(ILiveTileService tileService, IDialogService dialogService, INavigationService navigationService,
            IReminderService reminderService, IShareService shareService)
        {
            this.LiveTileService = tileService;
            this.DialogService = dialogService;
            this.NavigationService = navigationService;
            this.ReminderService = reminderService;
            this.ShareService = shareService;
        }

        #endregion

        #region Commands

        private ICommand _startCookingCommand;
        public ICommand StartCookingCommand { get { return this._startCookingCommand = this._startCookingCommand ?? new DelegateCommand(this.StartCooking); } }
        public void StartCooking()
        {
            ReminderService.SetReminder(this.RecipeItem);
        }

        private ICommand _shareCommand;
        public ICommand ShareCommand { get { return this._shareCommand = this._shareCommand ?? new DelegateCommand(this.Share); } }
        public void Share()
        {
            ShareService.Share(this.RecipeItem.Title, this.RecipeItem.Directions);
        }

        private ICommand _pinToStartCommand;
        public ICommand PinToStartCommand { get { return this._pinToStartCommand = this._pinToStartCommand ?? new DelegateCommand(this.PinToStart); } }
        public void PinToStart()
        {
            var uri = this.NavigationService.GetNavigationSource();
            if (LiveTileService.TileExists(uri))
            {
                LiveTileService.DeleteTile(uri);
                DialogService.Show("Tile Secundario eliminado.");
            }
            else
            {
                LiveTileService.Title = _recipeItem.Title;
                LiveTileService.Count = _recipeItem.PrepTime;
                LiveTileService.BackgroundImagePath = _recipeItem.ImagePath.LocalPath;
                LiveTileService.CreateTile(uri);
            }
        }

        #endregion
    }
}
