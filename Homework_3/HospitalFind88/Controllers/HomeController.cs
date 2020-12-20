using HospitalFind88.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace HospitalFind88.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            
            return View();

        }
        
        public ActionResult Location()
        { 
            string markers = "[";
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", sdr["Name"]);
                    markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                    markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                    markers += string.Format("'web': '{0}',", sdr["Website"]);
                    markers += string.Format("'emergency': '{0}',", sdr["Emergency"]);
                    markers += string.Format("'phone': '{0}',", sdr["Phone"]);
                    markers += string.Format("'str': '{0}',", sdr["Street"]);
                    markers += string.Format("'pc': '{0}',", sdr["Postcode"]);
                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
        [HttpPost]
        public ActionResult Location(Locations location)
        {
            if (ModelState.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", location.Name);
                    cmd.Parameters.AddWithValue("@Latitude", location.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", location.Longitude);
                    cmd.Parameters.AddWithValue("@Emergency", location.Emergency);
                    cmd.Parameters.AddWithValue("@Website", location.Website);
                    cmd.Parameters.AddWithValue("@Phone", location.Phone);
                    cmd.Parameters.AddWithValue("@Street", location.Street);
                    cmd.Parameters.AddWithValue("@Postcode", location.Postcode);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {

            }
            return RedirectToAction("Location");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}