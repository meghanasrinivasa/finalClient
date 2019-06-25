using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication1.Pages
{
    public class TouristModel : PageModel
    {
        public string place { get; private set; } = "Tourist  Places";

        public void OnGet()
        {
            var url = "http://137.117.43.80/api/city/tourist";
			using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }

                place = "<h1>Tourist Places</h1></br> "+ json_data;
            } 
        }

        public class City
        {
            public string place;
        }
    }
}