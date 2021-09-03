using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.Services.DomainModels
{
    public class CountryDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
