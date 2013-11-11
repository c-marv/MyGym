using Microsoft.Phone.Shell;
using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services
{
    public class LiveTileService : ILiveTileService
    {
        // Título
        public string Title { get; set; }
        public string BackTitle { get; set; }

        // Contador
        public int Count { get; set; }

        // Texto
        public string BackContent { get; set; }

        // Imágenes
        public string BackgroundImagePath { get; set; }
        public string BackBackgroundImagePath { get; set; }

        public string Url { get; set; }

        public void UpdateTile()
        {
            StandardTileData tileData = new StandardTileData
            {
                Title = this.Title ?? "",
                Count = this.Count,
                BackTitle = this.BackTitle ?? "",
                BackContent = this.BackContent ?? "",
                BackgroundImage = new Uri(this.BackgroundImagePath ?? "", UriKind.Relative),
                BackBackgroundImage = new Uri(this.BackBackgroundImagePath ?? "", UriKind.Relative)
            };

            // Actualiza el live tile con la plantilla
            ShellTile.ActiveTiles.FirstOrDefault().Update(tileData);
        }

        public bool TileExists(string NavSource)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(o => o.NavigationUri.ToString().Contains(NavSource));
            return tile == null ? false : true;
        }

        public void CreateTile(string NavSource)
        {
            StandardTileData tileData = new StandardTileData
            {
                Title = this.Title ?? "",
                Count = this.Count,
                BackTitle = this.BackTitle ?? "",
                BackContent = this.BackContent ?? "",
                BackgroundImage = new Uri(this.BackgroundImagePath ?? "", UriKind.Relative),
                BackBackgroundImage = new Uri(this.BackBackgroundImagePath ?? "", UriKind.Relative)
            };

            NavSource += string.Format("?title={0}", this.Title ?? "");
            ShellTile.Create(new Uri(NavSource, UriKind.Relative), tileData);
        }

        public void DeleteTile(string NavSource)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(o => o.NavigationUri.ToString().Contains(NavSource));
            if (tile == null) return;

            tile.Delete();
        }
    }
}
