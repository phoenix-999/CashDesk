using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models
{
    public class AccountFilter
    {
        public string Number { get; set; }
        public string ProductName { get; set; }
        public DateTime? AccountDate { get; set; }
        public decimal? SumFrom { get; set; }
        public decimal? SumTo { get; set; }
    }
}
