using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business_Layer.Configuration
{
    public class TransactionBillConfiguration : IEntityTypeConfiguration<TransactionBill>
    {
        public void Configure(EntityTypeBuilder<TransactionBill> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.TractionId);
            builder.HasOne(x => x.Order).WithMany(x => x.TransactionBills).HasForeignKey(x => x.OrderId);
        }
    }
}
