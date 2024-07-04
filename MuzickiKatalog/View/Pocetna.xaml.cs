using MuzickiKatalog.Model;
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

namespace MuzickiKatalog.View
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Window
    {
        Osoba ulogovan;
        public Pocetna()
        {
            ulogovan = null;
            InitializeComponent();
        }
        public Pocetna(Korisnik korisnik)
        {
            ulogovan = korisnik;
            InitializeComponent();
            menuNeregistrovani.Visibility = Visibility.Hidden;
            menuKorisnik.Visibility = Visibility.Visible;
            registerDugme.Visibility = Visibility.Hidden;
            logDugme.Content = "Logout";
        }
        public Pocetna(MuzickiUrednik urednik)
        {
            ulogovan = urednik;
            InitializeComponent();
            menuNeregistrovani.Visibility = Visibility.Hidden;
            menuUrednik.Visibility = Visibility.Visible;
            registerDugme.Visibility = Visibility.Hidden;
            logDugme.Content = "Logout";
        }
        public Pocetna(Administrator admin)
        {
            ulogovan = admin;
            InitializeComponent();
            menuNeregistrovani.Visibility = Visibility.Hidden;
            menuAdmin.Visibility = Visibility.Visible;
            registerDugme.Visibility = Visibility.Hidden;
            logDugme.Content = "Logout";
        }

        private void exitDugme_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeDugme_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void logDugme_Click(object sender, RoutedEventArgs e)
        {
            if (ulogovan != null)
            {
                Pocetna pocetna = new Pocetna();
                pocetna.Show();
                this.Close();
            }
            else {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void registerDugme_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Pretraga pretraga = new Pretraga(ulogovan);
            pretraga.Show();
            this.Close();
        }
    }
}
