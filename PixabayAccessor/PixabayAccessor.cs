using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using SearchPixabay.Entities;
using SearchPixabay.IWAContracts;
using System.Net.Http;
//using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Linq;

namespace SearchPixabay.WebAccessor
{
    public class PixabayAccessor : IWebAccessorContracts
    {
        readonly string  keyAPI;
        string[] usedImages;
        public PixabayAccessor()
        {
           usedImages = File.ReadAllLines("usedImages.txt");
            AppSettingsReader reader = new AppSettingsReader();
         //   keyAPI = reader.GetValue("accessorKey", typeof(string)).ToString();
            keyAPI = ConfigurationSettings.AppSettings["accessorKey"];
            if (string.IsNullOrEmpty(keyAPI))
            {
                keyAPI = "19700975-5439f8c319c1140f2fdb338b5";
            }
        }
        

        public PixabayAccessor(string key)
        {
            keyAPI = key;
            usedImages = File.ReadAllLines("usedImages.txt");
        }

        public IEnumerable<WebImage> GetImagePages(IEnumerable<string> tags)
        {
            string pattern = string.Join("+", tags);
            if(pattern.Length>100)
            {
                pattern = pattern.Substring(1, pattern.LastIndexOf('+', 100));
            }

            Uri uri = new Uri($"https://pixabay.com/api/?key={keyAPI}&q={pattern}&image_type=photo");
            return GetImageLinks(uri);
        }

        private IEnumerable<WebImage> GetImageLinks(Uri uri)
        {
            IList<WebImage> images = new List<WebImage>();
            try
            {
                 
                /*    using (HttpClient client = new HttpClient() { BaseAddress =uri })
                    {
                        response = client.GetFromJsonAsync<PixabayResponse>("").Result;


                    }
                */
                HttpClient client = new HttpClient();
                
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + iamToken); 

                HttpResponseMessage response = client.GetAsync(uri).Result;
                    byte[] responseBytes = response.Content.ReadAsByteArrayAsync().Result;
                    string responseString = Encoding.UTF8.GetString(responseBytes);

               PixabayResponse pixabayResponse=JsonConvert.DeserializeObject<PixabayResponse>(responseString);

                foreach (PixabayImage pixabayImage in pixabayResponse.hits)
                {
                    WebImage webImage = new WebImage()
                    {
                        WebId = pixabayImage.id,
                        Url = pixabayImage.largeImageURL,
                        Tags = pixabayImage.tags.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries),
                    };
                    if (!usedImages.Contains(webImage.ToString()))
                    {
                        images.Add(webImage);
                    }
                }
            }
            catch (Exception e)
            {
                images.Add(new WebImage()
                {
                    WebId = -1,
                    Url = e.Message,
                });
            }

            return images;
        }


        public IEnumerable<WebImage> GetImagePages(PixabayRequest request)
        {
            throw new NotImplementedException();
        }

        public bool AddUsedImage(WebImage webImage)
        {
            int c = usedImages.Length;
            try
            {
            File.AppendAllText("usedImages.txt", $"{Environment.NewLine}{webImage}");
            usedImages = File.ReadAllLines("usedImages.txt");
            }
            catch (Exception)
            {
            }

            return c == usedImages.Length - 1;
        }
    }
}
