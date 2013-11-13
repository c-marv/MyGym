using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MyGym.Client.WP8._2.Views
{
    public partial class Activities : PhoneApplicationPage
    {
        private bool seleccionado=false;
        public Activities()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (rExcepcional.IsChecked.Value || rLeve.IsChecked.Value || rModerada.IsChecked.Value || rIntensa.IsChecked.Value || rExcepcional.IsChecked.Value)
                seleccionado = true;

            if (seleccionado)
            {
                MessageBoxResult result;
                {
                    result = MessageBox.Show("Sure to keep your information, then could not modify",
                                               "Warning",
                                               MessageBoxButton.OKCancel);

                    if (result == MessageBoxResult.OK)
                    {
                        NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing data");
            }
            //ACA SE DEBE ACTUALIZAR EL NIVEL DE ACTIVIDAD
            //Metodos.AgregarDatosUsuario(nuevoDatosUsuario);
                   
        }
    }
}