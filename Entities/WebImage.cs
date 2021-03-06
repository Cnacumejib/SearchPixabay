﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPixabay.Entities
{
    public class WebImage
    {
        public long WebId { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public override string ToString()
        {
            return $"{WebId}\t{Url}";
        }
    }
}
