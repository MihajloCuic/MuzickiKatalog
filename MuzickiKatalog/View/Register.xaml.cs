using MuzickiKatalog.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MuzickiKatalog.Model;

namespace MuzickiKatalog.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Korisnik korisnik = RegistracijaControler.Registracija(imeUnos.Text, prezimeUnos.Text, emailUnos.Text, telefonUnos.Text, lozinkaUnos.Text);
                Pocetna pocetna = new Pocetna(korisnik);
                pocetna.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pocetna pocetna = new Pocetna();
            pocetna.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
