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
    public class WhisperModel : PageModel
    {
        public string Lyrics { get; private set; } = "Careless Whisper..";

        private List<Item> download_serialized_json_data(string url)
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }

                // if string with JSON data is not empty, deserialize it to class and return its instance 
                //return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();

                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json_data);
                return items;
            }
        }

        public void OnGet()
        {
            //LoadJson();

            //var url = "https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID ";
            var url = "https://raw.githubusercontent.com/dinorows/files/master/gmjb.json";
            //var currencyRates = _download_serialized_json_data<Item>(url);
            var songs = download_serialized_json_data(url);
            foreach (var song in songs)
            {
                if (song.title == "Careless Whisper")
                {
                    Lyrics = "<h1>Careless Whisper</h1><br/>" + song.lyrics;
                }
            }
        }

        public void LoadJson()
        {
            string url = "https://raw.githubusercontent.com/dinorows/files/master/gmjb.json";
            using (StreamReader r = new StreamReader(url))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }

        public class Item
        {
            public string title;
            public string author;
            public string lyrics;
        }
    }
}