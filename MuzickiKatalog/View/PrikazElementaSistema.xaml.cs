using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PrikazElementaSistema.xaml
    /// </summary>
    public partial class PrikazElementaSistema : Window
    {
        Osoba osoba;
        ElementSistema element;
        public PrikazElementaSistema(Osoba _osoba, ElementSistema _element)
        {
            osoba = _osoba;
            element = _element;
            InitializeComponent();
            nazivLabela.Content = _element.Ime;
            if (osoba == null)
            {
                omiljenoDugme.Visibility = Visibility.Hidden;
                recenzijaDugme.Visibility= Visibility.Hidden;
            }
            else if (osoba.GetType() != typeof(Korisnik))
            {
                omiljenoDugme.Visibility = Visibility.Hidden;
            }
            ocenaLabela.Content = "Prosecna ocena: " + _element.ProsecnaOcena.ToString();
            opisLabela.Content = _element.Opis;
            zanroviLabela.Content = "Zanr: " + string.Join(", ", _element.SviZanrovi.Select(zanr => zanr.Naziv));

            foreach (Recenzija rec in element.SveRecenzije) 
            {
                RecenzijaPrikaz rp = new RecenzijaPrikaz(rec.Recezent, rec.Opis, rec.Ocena);
                recenzijeLista.Items.Add(rp);
            }
            if (_element.GetType() == typeof(Album)) 
            {
                Album album = (Album) _element;
                autorLabela.Content = album.Izvodjaci[0].Ime;
                autorLabela.Visibility = Visibility.Visible;

                bonusLabela.Content = "Numere";
                bonusLabela.Visibility = Visibility.Visible;
                bonusLista.Visibility = Visibility.Visible;
                foreach (MuzickaNumera numera in album.NumereAlbuma) 
                {
                    bonusLista.Items.Add(new NumerePom(numera.Ime));
                }

            }
            if (_element.GetType() == typeof(MuzickaNumera))
            {
                MuzickaNumera album = (MuzickaNumera)_element;
                autorLabela.Content = album.Izvodjaci[0].Ime;
                autorLabela.Visibility= Visibility.Visible;
            }

            if (_element.GetType() == typeof(Izvodjac)) 
            {
                Izvodjac izvodjac = (Izvodjac)_element;
                bonusLabela.Content = "Numere";
                bonusLabela.Visibility = Visibility.Visible;
                bonusLista.Visibility = Visibility.Visible;
                foreach (MuzickaNumera numera in izvodjac.Numere)
                {
                    bonusLista.Items.Add(new NumerePom(numera.Ime));
                }
            }
            if (_element.GetType() == typeof(MuzickaGrupa))
            {
                MuzickaGrupa grupa = (MuzickaGrupa)_element;
                bonusLabela.Content = "Numere";
                bonusLabela.Visibility = Visibility.Visible;
                bonusLista.Visibility = Visibility.Visible;
                foreach (MuzickaNumera numera in grupa.Numere)
                {
                    bonusLista.Items.Add(new NumerePom(numera.Ime));
                }
            }
            if (_element.GetType() == typeof(Koncert))
            {
                Koncert koncert = (Koncert)_element;
                bonusLabela.Content = "Elementi";
                bonusLabela.Visibility = Visibility.Visible;
                bonusLista.Visibility = Visibility.Visible;
                foreach (ElementSistema elem in koncert.ElementiKoncerta)
                {
                    bonusLista.Items.Add(new NumerePom(elem.Ime));
                }
            }
        }

        private void recenzijaDugme_Click(object sender, RoutedEventArgs e)
        {
            dodavanjeRecenzije dodavanje = new dodavanjeRecenzije(osoba, element);
            dodavanje.Show();
            this.Close();
        }

        private void exitDugme_Click(object sender, RoutedEventArgs e)
        {
            Pretraga pretraga = new Pretraga(osoba);
            pretraga.Show();
            this.Close();
        }

        private void minimizeDugme_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void omiljenoDugme_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = (Korisnik)osoba;
            k.OznaciKaoOmiljeno(element);
        }
    }

    internal class RecenzijaPrikaz 
    {
        private string recezent;
        private string opis;
        private int ocena;
        public string Recezent { get; set; }
        public string Opis { get; set; }
        public int Ocena { get; set; }

        public RecenzijaPrikaz(string _recezent, string _opis, int _ocena) 
        { 
            Recezent = _recezent;
            Opis = _opis;
            Ocena = _ocena;
        }
    }
    internal class NumerePom
    {
        private string ime;
        public string Ime { get; set; }

        public NumerePom(string _ime)
        {
            Ime = _ime;
        }
    }
}
