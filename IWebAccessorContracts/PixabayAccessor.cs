using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchPixabay.Entities;

namespace SearchPixabay.IWAContracts
{
    public interface IWebAccessorContracts
    {
        IEnumerable<WebImage> GetImagePages(IEnumerable<string> tags);
        IEnumerable<WebImage> GetImagePages(PixabayRequest request);

        string GetImageUrl(string pagelink);
    }
}
