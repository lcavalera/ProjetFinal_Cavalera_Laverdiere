using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinal.Models
{
    public class Utilisateur
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AdresseCourriel { get; set; }
        public string MotDePasse { get; set; }
    }
}
