using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likvido.Invoice.App.Models
{
    public class InvoiceListRootViewModel
    {
        public List<InvoiceListViewModel> Data { get; set; }
    }

    public class InvoiceListViewModel 
    {
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        public DateTime DateCreated { get; set; }
        public string Currency { get; set; }
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string InvoiceComments { get; set; }
    }
}
