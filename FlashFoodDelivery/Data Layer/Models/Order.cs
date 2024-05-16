using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ShipperId { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string Address { get; set; }
        public Decimal TotalPrice { get; set; }
        public string StatusOrder { get; set; }

    }
}
