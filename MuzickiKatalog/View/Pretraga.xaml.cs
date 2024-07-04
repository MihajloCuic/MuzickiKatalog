﻿using MuzickiKatalog.Model;
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
    /// Interaction logic for Pretraga.xaml
    /// </summary>
    public partial class Pretraga : Window
    {
        Osoba osoba;
        public Pretraga(Osoba ulogovan)
        {
            osoba = ulogovan;
            InitializeComponent();
        }
    }
}
