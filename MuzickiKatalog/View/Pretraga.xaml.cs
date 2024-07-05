using MuzickiKatalog.Controller;
using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Pretraga.xaml
    /// </summary>
    public partial class Pretraga : Window
    {
        Osoba osoba;
        private ObservableCollection<Pronadjen> Pronadjeni { get; set; }
        private List<ElementSistema> Nadjeni { get; set; }
        public Pretraga(Osoba ulogovan)
        {
            Pronadjeni = new ObservableCollection<Pronadjen>();
            Nadjeni = new List<ElementSistema>();
            osoba = ulogovan;
            InitializeComponent();
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            if (osoba == null)
            { 
                Pocetna pocetna = new Pocetna();
                pocetna.Show();
            }
            else if (osoba.GetType() == typeof(Korisnik))
            {
                Pocetna pocetna = new Pocetna((Korisnik) osoba);
                pocetna.Show();
            }
            else if (osoba.GetType() == typeof(MuzickiUrednik))
            {
                Pocetna pocetna = new Pocetna((MuzickiUrednik)osoba);
                pocetna.Show();
            }
            else 
            {
                Pocetna pocetna = new Pocetna((Administrator) osoba);
                pocetna.Show();
            }
            this.Close();
        }

        private void pretragaDugme_Click(object sender, RoutedEventArgs e)
        {
            List<ElementSistema> pronadjeniElementi = PretragaControler.PronadjiElementeSistema(pretragaUpis.Text);
            Nadjeni = pronadjeniElementi;

            foreach (ElementSistema pronadjeniElement in pronadjeniElementi)
            {
                Pronadjeni.Add(new Pronadjen(pronadjeniElement.Id, pronadjeniElement.Ime));
            }
            rezultatiPretrage.ItemsSource = Pronadjeni;
        }

        private void ListViewSelection_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if (rezultatiPretrage.SelectedItem != null)
            {
                foreach (ElementSistema elem in Nadjeni)
                {
                    Pronadjen p = (Pronadjen)rezultatiPretrage.SelectedItem;
                    if (elem.Id == p.Id) 
                    {
                        PrikazElementaSistema prikazElementaSistema = new PrikazElementaSistema(osoba, elem);
                        prikazElementaSistema.Show();
                        break;
                    }
                }
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

    internal class Pronadjen 
    {
        private int id;
        private string naziv;
        public int Id { get; set; }
        public string Naziv { get; set; }

        public Pronadjen(int _id, string _naziv) 
        {
            Id = _id;
            Naziv = _naziv;
        }
    }
}
