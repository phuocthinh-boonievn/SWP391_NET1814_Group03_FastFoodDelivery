using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Transaction
    {
        public Guid TractionId { get; set; }
        public Guid OrderId { get; set; }
    }
}
