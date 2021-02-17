using MobileSalesApplication.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileSalesApplication.Repository.MobileRepository
{
    public interface IMobileRepository
    {
        IEnumerable<MonthlySale> GetMobileSaleDetailsData(DateTime FromDate, DateTime ToDate);
        IEnumerable<MonthlyBrandSpecificSale> GetBrandWiseMobileSalesDetailsData(DateTime FromDate, DateTime ToDate);
        IEnumerable<MobileSaleComparison> GetMobileComparisonSalesDetailsData(DateTime FromDate, DateTime ToDate);
    }
}
