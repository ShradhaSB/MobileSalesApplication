using System;
using System.Collections.Generic;
using System.Text;

namespace MobileSalesApplication.Data
{
    public class MonthlyBrandSpecificSale
    {
        public int Id { get; set; }
        public string MobileBrand { get; set; }
        public int ProfitLoss { get; set; }
        public decimal? ProfitLossPercent { get; set; }
        public int SalesMonth { get; set; }
    }
}
