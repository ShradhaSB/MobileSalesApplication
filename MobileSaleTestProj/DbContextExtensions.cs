using MobileSalesApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleTestProj
{
    public static class DbContextExtensions
    {
        public static void Seed(this MobileSaleContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.MonthlySale.Add(new MonthlySale
            {
               ProfitLoss= 62029,
               ProfitLossPercent= Convert.ToDecimal(0.98),
               SalesMonth=1,
               Id=1
            });
            dbContext.MonthlyBrandSpecificSale.Add(new MonthlyBrandSpecificSale
            {
                MobileBrand="Samsung",
                ProfitLoss = 6229,
                ProfitLossPercent = Convert.ToDecimal(1.25),
                SalesMonth = 2,
                Id =2
            });
            dbContext.MobileSaleComparison.Add(new MobileSaleComparison
            {
                MobileBrand = "Samsung",
                MobileID = 1,
                CurrentSaleCount = 19,
                PrevSaleCount = 27,
                CurrentProfitLoss = Convert.ToDecimal(4330.00),
                PrevProfitLoss = Convert.ToDecimal(7419.00),
                CurrentProfitLossPercent = Convert.ToDecimal(0.99),
                PrevProfitLossPercent = Convert.ToDecimal(1.25),
                CurrentDiscountPercent= Convert.ToDecimal(7.09),
                PrevDiscountPercent = Convert.ToDecimal(6.90),
                Id = 2
            });
            dbContext.SaveChanges();
        }
    }
}
