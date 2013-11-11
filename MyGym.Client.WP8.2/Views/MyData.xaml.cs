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

namespace MyGym.Client.WP8._2.Views
{
    public partial class MyData : PhoneApplicationPage
    {
        private int sexoActual=0;//femenino 0 , masculino 1
        public MyData()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {


            User usuario = new User();
            usuario.Email = txtCorreo.Text;
            usuario.FirstName = txtFirtsName.Text;
            usuario.lastName = txtLastName.Text;
            usuario.Names = txtName.Text;
            usuario.Password = txtPassword.ToString();
            usuario.Nick = txtNick.Text;
            usuario.DateOfBirth =(DateTime) dtFecha.Value;
            usuario.Sexo = sexoActual;//por defecto mujer con 0 
            
        }

        private void btnMujer_Click(object sender, RoutedEventArgs e)
        {
            bordeH.Background = new SolidColorBrush(Colors.Transparent);
            bordeM.Background = new SolidColorBrush(Colors.Yellow);
            sexoActual = 0;
        }

        private void btnHombre_Click(object sender, RoutedEventArgs e)
        {
            bordeH.Background = new SolidColorBrush(Colors.Transparent);
            bordeM.Background = new SolidColorBrush(Colors.Yellow);
            sexoActual = 1;
        }
    }
}