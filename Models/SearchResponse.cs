using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMahindra_Ex
{
    public class SearchResponse
    {
        public string SearchItem { get; set; }
        public string Title { get; set; }
        public string displayLink { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
    }

    public class SearchImageResponse
    {
        public string SearchItem { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
        public string Url { get; set; }
    }
}