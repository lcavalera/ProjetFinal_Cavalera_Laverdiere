using ProjetFinal.Models;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetFinal
{
    public partial class App : Application
    {
        public static string CheminBD;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public App(string cheminBD)
        {
            InitializeComponent();
            CheminBD = cheminBD;
            MainPage = new NavigationPage(new Connexion());
            using (var conn = new SQLiteConnection(CheminBD))
            {
                conn.CreateTable<Utilisateur>();
                conn.CreateTable<ListViewElement>();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
