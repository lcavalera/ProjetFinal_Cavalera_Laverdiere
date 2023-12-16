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
    public partial class NouveauCompte : ContentPage
    {
        private readonly string _adresseCourriel;
        public NouveauCompte()
        {
            InitializeComponent();
        }
        public NouveauCompte(string adresseCourriel)
        {
            InitializeComponent();
            _adresseCourriel = adresseCourriel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtAdresseCourriel.Text = _adresseCourriel;
        }
        private async void btnCreerCompte_Clicked(object sender, EventArgs e)
        {
            var adresseCourriel = txtAdresseCourriel.Text;
            var motDePasse = txtMotDePasse.Text;
            var comfirmMotDePasse = txtConfirmMotDePasse.Text;
            //Valider Adresse Courriel
            if (string.IsNullOrEmpty(adresseCourriel))
            {
                await DisplayAlert("Alerte", "Veuillez ajouter une adresse courriel", "Fermer");
                return;
            }

            //Valider Mot de Passe
            if (string.IsNullOrEmpty(motDePasse))
            {
                await DisplayAlert("Alerte", "Veuillez ajouter un mot de passe", "Fermer");
                return;
            }

            //Valider Confirmation Mot de Passe
            if (string.IsNullOrEmpty(comfirmMotDePasse))
            {
                await DisplayAlert("Alerte", "Veuillez confirmer le mot de passe", "Fermer");
                return;
            }

            //Valider Mot de Passe et Confirmation correspodent
            if (motDePasse != comfirmMotDePasse)
            {
                await DisplayAlert("Alerte", "La confirmation du mot de passe ne correspond pas. Veuillez ajouter une confirmation correcte.", "Fermer");
                return;
            }
            //Création d'une variable nouveauUtilisateur
            using (var conn = new SQLiteConnection(App.CheminBD))
            {
                conn.Insert(new Utilisateur() { AdresseCourriel=adresseCourriel, MotDePasse=motDePasse});
            }
            await DisplayAlert("Message", "L'utilisateur a été créé avec succès", "Fermer");
            await Navigation.PopAsync();
        }

        private async void btnAnnuler_Clicked(object sender, EventArgs e)
        {
            var reponse = await DisplayAlert("Message", "Voulez-vous quitter sans enregistrer?", "Oui", "Non");
            if (reponse)
            {
                await Navigation.PopAsync();
            }

        }
    }
}