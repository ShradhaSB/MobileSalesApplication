using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileSalesApplication.Data
{
    public class MobileSaleContext : DbContext
    {
        public MobileSaleContext(DbContextOptions<MobileSaleContext> options)
            : base(options)
        {
        }
        public DbSet<MonthlySale> MonthlySale { get; set; }
        public DbSet<MonthlyBrandSpecificSale> MonthlyBrandSpecificSale { get; set; }
        public DbSet<MobileSaleComparison> MobileSaleComparison { get; set; }
    }
}
