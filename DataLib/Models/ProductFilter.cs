using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models
{
    public class ProductFilter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}
