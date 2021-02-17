using System;
using System.Collections.Generic;
using System.Text;

namespace MobileSalesApplication.Data
{
    public class MobileSaleComparison
    {
        public int Id { get; set; }
        public int MobileID { get; set; }
        public string MobileBrand { get; set; }
        public string MobileName { get; set; }
        public int CurrentSaleCount { get; set; }
        public int PrevSaleCount { get; set; }
        public decimal CurrentProfitLoss { get; set; }
        public decimal PrevProfitLoss { get; set; }
        public decimal CurrentProfitLossPercent { get; set; }
        public decimal PrevProfitLossPercent { get; set; }
        public decimal CurrentDiscountPercent { get; set; }
        public decimal PrevDiscountPercent { get; set; }
    }
}
