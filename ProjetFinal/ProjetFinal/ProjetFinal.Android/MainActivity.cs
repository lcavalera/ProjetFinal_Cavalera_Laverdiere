using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace ProjetFinal.Droid
{
    [Activity(Label = "ProjetFinal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string nomBD = "WebKeep_db.sqlite";
            string repertoire = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string cheminBD = System.IO.Path.Combine(repertoire, nomBD);
            //enlever parametre de App() pour utiliser des donnés static
            //LoadApplication(new App(cheminBD));
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}