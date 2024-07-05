using MuzickiKatalog.Model;
using Newtonsoft.Json;
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
using System.IO;
namespace MuzickiKatalog.View
{
    /// <summary>
    /// Interaction logic for Dodavanje.xaml
    /// </summary>
    public partial class Dodavanje : Window
    {
        private static readonly string basePath = System.IO.Path.Combine("..", "..", "..", "Data");
        public Dodavanje()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            List<Recenzija> recenzije = new List<Recenzija>();
            Dictionary<int, Zanr> zanrovi = Zanr.UcitajZanrove();
            ZanroviComboBox.ItemsSource = zanrovi.Values;

            //string recenzijeJson = File.ReadAllText(System.IO.Path.Combine(basePath, "Recenzije.json"));
            //List<Recenzija> recenzije = JsonConvert.DeserializeObject<List<Recenzija>>(recenzijeJson);
            RecenzijeComboBox.ItemsSource = recenzije;

            Dictionary<int, Izvodjac> i = Izvodjac.UcitajIzvodjace();
            IzvodjaciComboBox.ItemsSource = i.Values;
            IzvodjaciKoncertComboBox.ItemsSource= i.Values;

            Dictionary<int, MuzickaNumera> mn = MuzickaNumera.UcitajMuzickeNumere();
            MuzickeNumereComboBox.ItemsSource = mn.Values;

            Dictionary<int, MuzickaGrupa> mg = MuzickaGrupa.UcitajMuzickeGrupe();
            GrupaComboBox.ItemsSource = mg.Values;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            string ime = ImeTextBox.Text;
            int prosecnaOcena = int.Parse(ProsecnaOcenaTextBox.Text);
            string opis = OpisTextBox.Text;
            int id = int.Parse(IDTextBox.Text);

            List<Zanr> sviZanrovi = new List<Zanr> { (Zanr)ZanroviComboBox.SelectedItem };
            List<Recenzija> sveRecenzije = new List<Recenzija> { (Recenzija)RecenzijeComboBox.SelectedItem };
            DateTime? datum = DatumDatePicker.SelectedDate;
            List<ElementSistema> izvodjaciKoncert = new List<ElementSistema> { (ElementSistema)IzvodjaciKoncertComboBox.SelectedItem };
            List<MuzickaNumera> muzickeNumere = new List<MuzickaNumera> { (MuzickaNumera)MuzickeNumereComboBox.SelectedItem };
            string snimatelj = SnimateljTextBox.Text;
            string formatPrikaza = FormatPrikazaTextBox.Text;
            List<Izvodjac> izvodjaci = new List<Izvodjac> { (Izvodjac)IzvodjaciComboBox.SelectedItem };
            MuzickaGrupa grupa = (MuzickaGrupa)GrupaComboBox.SelectedItem;

            MuzickiUrednik urednik = new MuzickiUrednik("Ime", "Prezime", "Email", "Telefon", "ID", new List<Recenzija>(), new List<Zanr>());
            urednik.DodajElementSistema(ime, prosecnaOcena, opis, id, sviZanrovi, sveRecenzije, datum, izvodjaciKoncert, 
                muzickeNumere, snimatelj, formatPrikaza, izvodjaci, grupa);
            this.Close();
        }
    }
}
