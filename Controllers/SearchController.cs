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
    public class SearchController : Controller
    {
        // apiKey#1       : AIzaSyD4FFIzIwCYGSk3jx5Fkc5ADiTXFPfbWnE
        // searchEngine#1 : fbcb2f4d27103455f

        // apiKey#2       : AIzaSyAPFJLlisozh1kOdXpPCLcDiH2sS7EWFmI
        // searchEngine#2 : 129e9516dffb81f9f

        string apiKey = "AIzaSyD4FFIzIwCYGSk3jx5Fkc5ADiTXFPfbWnE";                  // Got this from https://developers.google.com/custom-search/v1/introduction/?apix=true
        string searchEngineId = "fbcb2f4d27103455f";                                // Got this from https://cse.google.com/cse/setup/basic?cx=fbcb2f4d27103455f

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowResults()
        {
            string searchQuery = Request["search"];

            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + searchEngineId + "&q=" + searchQuery + "&num=4");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<SearchResult>();
            foreach (var item in jsonData.items)
            {
                results.Add(new SearchResult
                {
                    SearchItem = searchQuery,
                    Title = item.title,
                    Link = item.link,
                    displayLink = item.displayLink,
                    Snippet = item.snippet,
                });
            }
            return View("ShowResults", results.ToList());
        }

        public ActionResult ShowImageResults()
        {
            string searchQuery = Request["search"];

            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + searchEngineId + "&q=" + searchQuery + "&num=4&searchType=image");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<SearchResult>();
            foreach (var item in jsonData.items)
            {
                results.Add(new SearchResult
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                });
            }
            return View(results.ToList());
        }
    }
}