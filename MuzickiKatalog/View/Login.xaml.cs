using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginDugme_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = korisnickoImeUnos.Text;
            string lozinka = lozinkaUnos.Text;

            //List<Recenzija> l = new List<Recenzija>();
            //List<Zanr> z = new List<Zanr>();
            //MuzickiUrednik m = new MuzickiUrednik("milos","milosavljevic","milos@gmail.com","123123","milos@gmail.com",l,z);
            //m.Dodaj();
            Osoba o = KorisnickiNalog.Login(korisnickoIme, lozinka);

            Dictionary<string,MuzickiUrednik> sviUrednici = MuzickiUrednik.UcitajUrednike();
            //Dictionary<string, Korisnik> sviKorisnici = Korisnik.UcitajKorisnike();
            //Dictionary<string,Administrator> sviAdministratori = Administrator.UcitajAdministratore();
            if(sviUrednici.ContainsKey(o.Id))
            {
                Pocetna pocetna = new Pocetna(sviUrednici[o.Id]);
                pocetna.Show();
                this.Close();
            }

        }

        private void exitDugme_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeDugme_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
