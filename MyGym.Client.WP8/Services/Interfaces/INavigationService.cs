using MyGym.Client.WP8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services.Interfaces
{
    public interface INavigationService
    {
        string GetNavigationSource();
        void NavigateToGroupDetailPage(RecipeDataGroup recipeDataGroup);
        void NavigateToRecipeDetailPage(RecipeDataItem recipeDataItem);
    }
}
