using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace MyGym.Client.WP8._2.Views
{
    public partial class Information : PhoneApplicationPage
    {
        private int complexionActual=-1;
        public Information()
        {
            InitializeComponent();
            sldPeso.ValueChanged += sldPeso_ValueChanged;
            sldAltura.ValueChanged += sldAltura_ValueChanged;
        }

        private void sldAltura_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sldAltura.Value = (int)(sldAltura.Value);
        }

        private void sldPeso_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sldPeso.Value = (int)(sldPeso.Value);
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (complexionActual != -1)
            {
                MessageBoxResult result;
                {
                    result = MessageBox.Show("Sure to keep your information, then could not modify",
                                               "Warning",
                                               MessageBoxButton.OKCancel);

                    if (result == MessageBoxResult.OK)
                    {
                        NavigationService.Navigate(new Uri("/Views/Activities.xaml", UriKind.Relative));
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing data");
            }
            //ACA DEBERIA ACTUALIZAR O MAS BIEN AGREGAR LOSA DATOS Q FALTAN DEL USUARIO GUARDADO
            //CLARO PREVIAMENTE LOGEANDO CON EL NICK Y PASSWORD Q ME ENVIARA LA ANTERIOR PAGINA!
            //Metodos.AgregarDatosUsuario(nuevoDatosUsuario);
        }

        private void btnComplexionBaja_Click(object sender, RoutedEventArgs e)
        {
            borde1.Background = new SolidColorBrush(Colors.Yellow);
            borde2.Background = new SolidColorBrush(Colors.Transparent);
            borde3.Background = new SolidColorBrush(Colors.Transparent);
            complexionActual = 0;
        }

        private void btnComplexionMedia_Click(object sender, RoutedEventArgs e)
        {
            borde1.Background = new SolidColorBrush(Colors.Transparent);
            borde2.Background = new SolidColorBrush(Colors.Yellow);
            borde3.Background = new SolidColorBrush(Colors.Transparent);
            complexionActual = 1;
        }

        private void btnComplexionAlta_Click(object sender, RoutedEventArgs e)
        {
            borde1.Background = new SolidColorBrush(Colors.Transparent);
            borde2.Background = new SolidColorBrush(Colors.Transparent);
            borde3.Background = new SolidColorBrush(Colors.Yellow);
            complexionActual = 2;
        }

    }
}