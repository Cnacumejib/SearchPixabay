using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPixabay.Entities
{
    public class PixabayResponse
    {
        public int total { get; set; }
        public int totalHits { get; set; }
        public IEnumerable<PixabayImage> hits { get; set; }
    }
}
