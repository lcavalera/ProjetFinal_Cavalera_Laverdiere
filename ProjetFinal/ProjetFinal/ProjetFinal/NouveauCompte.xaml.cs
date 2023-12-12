using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NouveauCompte : ContentPage
    {
        public NouveauCompte()
        {
            InitializeComponent();
        }
        public NouveauCompte(string adresseCourriel)
        {
            InitializeComponent();
        }
    }
}