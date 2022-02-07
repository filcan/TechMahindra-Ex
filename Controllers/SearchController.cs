using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TechMahindra_Ex.Controllers
{
    public class SearchController : Controller
    {
        // apiKey#1       : AIzaSyD4FFIzIwCYGSk3jx5Fkc5ADiTXFPfbWnE
        // searchEngine#1 : fbcb2f4d27103455f

        // apiKey#2       : AIzaSyAPFJLlisozh1kOdXpPCLcDiH2sS7EWFmI
        // searchEngine#2 : 77139038659594bd4

        string apiKey = "AIzaSyD4FFIzIwCYGSk3jx5Fkc5ADiTXFPfbWnE";                  // Got this from https://developers.google.com/custom-search/v1/introduction/?apix=true
        string searchEngineId = "fbcb2f4d27103455f";                                // Got this from https://cse.google.com/cse/setup/basic?cx=fbcb2f4d27103455f

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchImage()
        {
            return View("SearchImage");
        }

        // Search
        public ActionResult SearchResult(string searchKeyword)
        {
            string searchQuery = (searchKeyword == null) ? Request["search"] : searchKeyword;

            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + searchEngineId + "&q=" + searchQuery + "&num=4");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<SearchResponse>();
            foreach (var item in jsonData.items)
            {
                results.Add(new SearchResponse
                {
                    Title = item.title,
                    Link = item.link,
                    displayLink = item.displayLink,
                    Snippet = item.snippet,
                });
                Session["resultData"] = results.ToList();
            }
            if (searchKeyword == null)
            {
                return View("ShowResults", results.ToList());                      // For Search Engine
            }
            else
            {
                return Json(results.ToList(), JsonRequestBehavior.AllowGet);       // For Static [Top 4 UML Design]
            }
        }

        // Search for Image
        public ActionResult SearchImageResult()
        {
            string searchQuery = Request["search"];

            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + searchEngineId + "&q=" + searchQuery + "&num=4&searchType=image");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<SearchImageResponse>();
            foreach (var item in jsonData.items)
            {
                results.Add(new SearchImageResponse
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                    Url = item.image.contextLink
                });
            }
            return View("ShowImageResults", results.ToList());
        }

        // Display Result For Top 4 UML Design
        public ActionResult DisplayResult()
        {
            return View("ShowResults", Session["resultData"]);
        }
    }
}