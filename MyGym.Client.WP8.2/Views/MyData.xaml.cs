using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyGym.Client.WP8._2.Models;
using System.Windows.Media;

using MyGym.Client.Library.Events;

namespace MyGym.Client.WP8._2.Views
{
    public partial class MyData : PhoneApplicationPage
    {
        private int sexoActual=-1;//femenino 0 , masculino 1
        public MyData()
        {
            
            InitializeComponent();
            App.FirstTimeLaunch = true;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            User usuario = new User();

            usuario.Email = txtCorreo.Text;
            usuario.FirstName = txtFirtsName.Text;
            usuario.LastName = txtLastName.Text;
            usuario.Names = txtName.Text;
            usuario.Password = txtPassword.ToString();
            usuario.Nick = txtNick.Text;
            usuario.DateOfBirth =(DateTime) dtFecha.Value;
            usuario.Sexo = sexoActual;


            MessageBox.Show(usuario.Nick);
            if (usuario.sexo != -1 && !usuario.Email.Equals("") && !usuario.FirstName.Equals("")&& !usuario.LastName.Equals("")&&
                !usuario.Names.Equals("")&&!usuario.Password.Equals("") && !usuario.Nick.Equals(""))
            {
                MessageBoxResult result;
                {
                    result = MessageBox.Show("Sure to keep your information, then could not modify",
                                               "Warning",
                                               MessageBoxButton.OKCancel);

                    if (result == MessageBoxResult.OK)
                    {
                        DataMethods.Register(usuario.Email, usuario.Password, usuario.Nick, usuario.FirstName, usuario.LastName, usuario.Names, usuario.Sexo, usuario.PhysicalComplexion, usuario.LevelActivity, usuario.Weight, usuario.Height, usuario.DateOfBirth);
                        NavigationService.Navigate(new Uri("/Views/Information.xaml", UriKind.Relative));
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing data");
            }
            
            //ACA DEBERIA GUARDAR EL USUARIO CON SU INFORMACION Y ENVIAR EN NAVEGACION MI NICK Y PASSWORD PARA LUEGO ACTUALIZAR INFO
            //Metodos.AgregarDatosUsuario(nuevoDatosUsuario);
                   
            
        }

        private void btnMujer_Click(object sender, RoutedEventArgs e)
        {
            bordeH.Background = new SolidColorBrush(Colors.Transparent);
            bordeM.Background = new SolidColorBrush(Colors.Yellow);
            sexoActual = 0;
        }

        private void btnHombre_Click(object sender, RoutedEventArgs e)
        {
            bordeH.Background = new SolidColorBrush(Colors.Yellow);
            bordeM.Background = new SolidColorBrush(Colors.Transparent);
            sexoActual = 1;
        }
    }
}