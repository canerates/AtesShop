using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Resources
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);

        object GetPriceValue(string name, string culture, string role, bool isPrev);
    }
}
