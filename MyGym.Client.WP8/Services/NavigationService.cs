using Microsoft.Phone.Controls;
using MyGym.Client.WP8.Models;
using MyGym.Client.WP8.Services.Interfaces;
using MyGym.Client.WP8.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services
{
    public class NavigationService : INavigationService
    {
        private RecipeDataItem _selectedRecipeDataItem;
        private RecipeDataGroup _selectedRecipeDataGroup;

        public string GetNavigationSource()
        {
            return (App.Current.RootVisual as PhoneApplicationFrame).Source.ToString();
        }

        public void NavigateToGroupDetailPage(RecipeDataGroup recipeDataGroup)
        {
            _selectedRecipeDataGroup = recipeDataGroup;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigated += NavigateToGroupDetailPageNavigated;
            App.RootFrame.Navigate(new Uri("/View/GroupDetailPage.xaml", UriKind.Relative));
        }

        public void NavigateToRecipeDetailPage(RecipeDataItem recipeDataItem)
        {
            _selectedRecipeDataItem = recipeDataItem;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigated += NavigateToRecipeDetailPageNavigated;
            App.RootFrame.Navigate(new Uri("/View/RecipeDetailPage.xaml", UriKind.Relative));
        }

        void NavigateToGroupDetailPageNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigated -= NavigateToGroupDetailPageNavigated;

            //if (e.Content.GetType() == typeof(GroupDetailPage))
            //    (e.Content as GroupDetailPage).rRecipeGroup = _selectedRecipeDataGroup;
        }

        void NavigateToRecipeDetailPageNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigated -= NavigateToRecipeDetailPageNavigated;

            //if (e.Content.GetType() == typeof(RecipeDetailPage))
            //    (e.Content as RecipeDetailPage).RecipeItem = _selectedRecipeDataItem;
        }
    }
}
