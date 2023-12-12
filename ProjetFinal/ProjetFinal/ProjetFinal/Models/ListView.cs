using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinal.Models
{
    public class ListView
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation {  get; set; }
        public string Lien {  get; set; }
    }
}
