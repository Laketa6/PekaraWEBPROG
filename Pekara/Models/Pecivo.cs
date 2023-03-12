using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Pekara.Models
{
    public class Pecivo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Ukus { get; set; }
        public decimal Cena { get; set; }

        public Pecivo() { }

        public Pecivo(DataRow Pecivo)
        {
            Id = (int)Pecivo["Id"];
            Naziv = Pecivo["Naziv"].ToString();
            Ukus = Pecivo["Ukus"].ToString();
            Cena = (decimal)Pecivo["Cena"];
        }
    }
}