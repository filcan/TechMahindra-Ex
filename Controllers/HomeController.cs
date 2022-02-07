using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TechMahindra_Ex.Controllers
{
    public class HomeController : Controller
    {

        string apiKey = "AIzaSyD4FFIzIwCYGSk3jx5Fkc5ADiTXFPfbWnE";      // Got this from https://developers.google.com/custom-search/v1/introduction/?apix=true
        string searchEngineId = "fbcb2f4d27103455f";                                // Got this from https://cse.google.com/cse/setup/basic?cx=fbcb2f4d27103455f

        public ActionResult Index()
        {
            return View();
        }
    }
}