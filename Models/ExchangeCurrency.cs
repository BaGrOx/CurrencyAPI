using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPIWPF.Models
{
    public class ExchangeCurrency
    {
        public string?  table { get; set; }
        public DateTime effectiveDate { get; set; }
        public List<Currency>? rates { get; set; }
     
    }
}
