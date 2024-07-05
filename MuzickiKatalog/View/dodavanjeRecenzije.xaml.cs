using MuzickiKatalog.Controller;
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
    /// Interaction logic for dodavanjeRecenzije.xaml
    /// </summary>
    public partial class dodavanjeRecenzije : Window
    {
        public Osoba recezent;
        public ElementSistema recenziraniElement;
        public dodavanjeRecenzije(Osoba _recezent, ElementSistema _recenziraniElement)
        {
            recenziraniElement = _recenziraniElement;
            recezent = _recezent;
            InitializeComponent();
        }

        private void dodajRecenzijuDugme_Click(object sender, RoutedEventArgs e)
        {
            int ocena = 0;
            foreach (ComboBoxItem item in ocenaComboBox.Items)
            {
                if (item.IsSelected)
                {
                    ocena = int.Parse(item.Content.ToString());
                    break;
                }
            }
            string opis = opisTextBlock.Text;
            try
            {
                recenziraniElement = RecenzijaControler.DodajRecenziju(opis, ocena, recezent.Id, recenziraniElement.Id);

                PrikazElementaSistema prikazRecenziranogElementa = new PrikazElementaSistema(recezent, recenziraniElement);
                prikazRecenziranogElementa.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Message poruka = new Message(ex.Message);
            }
        }

        private void exitDugme_Click(object sender, RoutedEventArgs e)
        {
            PrikazElementaSistema prikazRecenziranogElementa = new PrikazElementaSistema(recezent, recenziraniElement);
            prikazRecenziranogElementa.Show();
            this.Close();
        }

        private void minimizeDugme_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
