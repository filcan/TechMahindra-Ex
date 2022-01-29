using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMahindra_Ex
{
    public class SearchResult
    {
        public string SearchItem { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
    }

    public class SearchImageResult
    {
        public string SearchItem { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
    }
}