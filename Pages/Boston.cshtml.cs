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
    public class BostonModel : PageModel
    {
        public string About { get; private set; } = "About Boston..";

        public void OnGet()
        {
            var url = "http://137.117.43.80/api/city/about";
			using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }

                About = "<h1>About Boston</h1></br> "+ json_data;
            } 
        }

        public class City
        {
            public string about;
        }
    }
}