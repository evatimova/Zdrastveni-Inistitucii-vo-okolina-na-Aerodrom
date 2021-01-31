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

        // Action that returns HomeView
        public ActionResult Index()
        {
            return View();
        }

        // Action that returns LocationView and provides the GoogleMap with hospitals Locations
        // acquired from the GoogleMap Database.
        public ActionResult Location()
        { 
            string markers = "[";
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; //gets the connectionString for the Database
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMap", con);  // puts spGetMap procedure from Database in Command cmd
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())         // reads the information from database and sets the markers for the map
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", sdr["Name"]);
                    markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                    markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
    }
}