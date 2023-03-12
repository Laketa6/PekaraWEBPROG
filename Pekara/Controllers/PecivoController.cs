using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pekara.Models;
using Pekara.Konekcija;
using System.Security.Principal;
using System.Net.Http;
using System.Web.UI;

namespace Pekara.Controllers
{
    public class PecivoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unesi()
        {
            return View();
        }

        public ActionResult SacuvajPodatke(Pecivo pecivo)
        {
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("INSERT INTO pecivo VALUES ('" + pecivo.Naziv + "', '" + pecivo.Ukus + "', " + pecivo.Cena + ")", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();
                    kom.ExecuteNonQuery();
                }
            }

            return RedirectToAction("TabelaPeciva");
        }

        public ActionResult TabelaPeciva()
        {
            List<Pecivo> peciva = new List<Pecivo>();
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("SELECT * FROM pecivo", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();

                    SqlDataReader drPecivo = kom.ExecuteReader();
                    DataTable dtPecivo = new DataTable();
                    dtPecivo.Load(drPecivo);

                    foreach (DataRow PecivoSlog in dtPecivo.Rows) peciva.Add(new Pecivo(PecivoSlog));
                }
            }

            return View(peciva);
        }
    }
}