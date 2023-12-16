using ProjetFinal.Models;
using SQLite;
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
    public partial class Connexion : ContentPage
    {
        public Connexion()
        {
            InitializeComponent();
            var assembly = typeof(Connexion);
            imageTitre.Source = ImageSource.FromResource("ProjetFinal.Assets.Images.image_web.png", assembly);
        }
        private async void btnCreerCompte_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NouveauCompte());
        }

        private async void btnConnexion_Clicked(object sender, EventArgs e)
        {
            var adresseCourriel = txtAdresseCourriel.Text;
            var motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrEmpty(adresseCourriel))
            {
                await DisplayAlert("Alerte", "Veuillez saisir une adresse courriel", "Fermer");
                return;
            }

            if (string.IsNullOrEmpty(motDePasse))
            {
                await DisplayAlert("Alerte", "Veuillez saisir un mot de passe", "Fermer");
                return;
            }
            using (var conn = new SQLiteConnection(App.CheminBD))
            {
                var users = conn.Table<Utilisateur>().ToList();
                var existe = users.Any(u => u.AdresseCourriel == adresseCourriel);
                if (existe)
                {
                    await DisplayAlert("Alerte", "Connexion reussi", "Fermer");
                    App.Current.MainPage = new NavigationPage(new PagePrincipale())
                    {
                        BarBackgroundColor = Color.Black,
                        BarTextColor = Color.White
                    };
                }
                else
                {
                    var utilisateurChoisiOui = await DisplayAlert("Alerte", "Ce Compte n'existe pas, voulez-vous en créer un avec cet identifiant ?", accept: "Oui", cancel:"Non");
                    if (utilisateurChoisiOui)
                    {
                        await Navigation.PushAsync(new NouveauCompte(adresseCourriel));
                    }
                }
            }
                
        }
    }
}