using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services.Interfaces
{
    public interface ILiveTileService
    {
        string Title { get; set; }
        string BackTitle { get; set; }

        int Count { get; set; }

        string BackContent { get; set; }

        string BackgroundImagePath { get; set; }
        string BackBackgroundImagePath { get; set; }

        string Url { get; set; }

        bool TileExists(string NavSource);
        void CreateTile(string NavSource);
        void DeleteTile(string NavSource);
        void UpdateTile();
    }
}
