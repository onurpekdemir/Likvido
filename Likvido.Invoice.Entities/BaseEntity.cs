using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.Entities
{
    public class BaseEntity
    {

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = -1; //system
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
