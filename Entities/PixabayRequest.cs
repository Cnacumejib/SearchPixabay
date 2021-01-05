using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPixabay.Entities
{
    public class PixabayRequest
    {
        string[] languages = new string[] { "ru", "en", "cs", "da", "de", "es", "fr", "id", "it", "hu", "nl", "no", "pl", "pt", "ro", "sk", "fi", "sv", "tr", "vi", "th", "bg", "el", "ja", "ko", "zh" };
        string[] image_types = new string[] { "all", "photo", "illustration", "vector" };
        string[] orientations = new string[] { "all", "horizontal", "vertical" };
        string[] categories = new string[] {"", "backgrounds", "fashion", "nature", "science", "education", "feelings", "health", "people", "religion", "places", "animals", "industry", "computer", "food", "sports", "transportation", "travel", "buildings", "business", "music"};
        string[] colorNames = new string[] { "", "grayscale", "transparent", "red", "orange", "yellow", "green", "turquoise", "blue", "lilac", "pink", "white", "gray", "black", "brown" };

        public PixabayRequest(IEnumerable<string> tags, pi_lang language = pi_lang.ru, string image_id = "", pi_image_type image_type_filter = pi_image_type.all,
            pi_orientation orientation_filter = pi_orientation.all, pi_category category_filter = 0, pi_color color_filter = 0, int min_width = 0, int min_height = 0, bool editors_choice = false, bool safesearch = false, pi_order order = pi_order.popular, int page = 1, int per_page = 20)
        {
            string pattern = string.Join("+", tags);
            if (pattern.Length > 100)
            {
                pattern = pattern.Substring(1, pattern.LastIndexOf('+', 100));
            }

            if (!string.IsNullOrWhiteSpace(image_id))
            {
                this.id = image_id;
            }

            q = pattern;
            this.orientation = orientations[(int)orientation_filter];
            this.image_type = image_types[(int)image_type_filter];
            this.lang = languages[(int)language];
            this.min_height = min_height;
            this.min_width = min_width;
            this.editors_choice = editors_choice;
            this.safesearch = safesearch;

            if (order == pi_order.latest)
            {
                this.order = "latest";
            }
            else
            {
                this.order = "popular";
            }

            if (per_page > 200)
            {
                this.per_page = 200;
            }
            else
            if (per_page < 3)
            {
                this.per_page = 3;
            }
            else
            {
                this.per_page = per_page;
            }
        }

        public PixabayRequest(IEnumerable<string> tags)
        {
            string pattern = string.Join("+", tags);
            if (pattern.Length > 100)
            {
                pattern = pattern.Substring(1, pattern.LastIndexOf('+', 100));
            }

            q = pattern;
        }

        public PixabayRequest(string q)
        {
            this.q = q;
        }

        public bool editors_choice { get; set; }
        public bool safesearch { get; set; }
        public int min_width { get; set; }
        public int min_height { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public string key { get; set; }
        public string q { get; set; }
        public string lang { get; set; }
        public string id { get; set; }
        public string image_type { get; set; }
        public string orientation { get; set; }
        public string category { get; set; }
        public string colors { get; set; }
        public string order { get; set; }

        //public string callback { get; set; }
        //public bool pretty { get; set; }
    }
}
