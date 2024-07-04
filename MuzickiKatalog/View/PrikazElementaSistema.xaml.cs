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
        }
    }
}
