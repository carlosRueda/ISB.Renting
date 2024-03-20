using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB.Renting.Models.DTO
{
    public class PurchaseDTO
    {
        public Guid ContactId { get; set; }
        public Guid PropertyId { get; set; }
        public decimal Price { get; set; }
    }
}
