using System;

namespace Likvido.Invoice.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
