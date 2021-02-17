using Microsoft.EntityFrameworkCore;
using MobileSalesApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileSalesApplication.Repository.MobileRepository
{
    public class MobileRepository : IMobileRepository
    {
        private MobileSaleContext mobileSalesContext;
        public MobileRepository(MobileSaleContext mobileSalesContext)
        {
            this.mobileSalesContext = mobileSalesContext;
        }
        /// <summary>
        /// Get mobile sale data
        /// </summary>
        /// <param name="FromDate">Start date from the selected range</param>
        /// <param name="ToDate">End date from the selected range</param>
        /// <returns>Mobile sale details in json format</returns>
        public IEnumerable<MonthlySale> GetMobileSaleDetailsData(DateTime FromDate, DateTime ToDate)
        {
            var StoredProc = "exec MonthlySalesReport " +
                   "@FromDate = " + "'" + FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ","
                   + "@ToDate =" + "'" + ToDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            var test = mobileSalesContext.MonthlySale.FromSqlRaw(StoredProc).ToList();
            return test;
        }
        /// <summary>
        /// Get Brand Wise Mobile Sales Data
        /// </summary>
        /// <param name="FromDate">Start date from the selected range</param>
        /// <param name="ToDate">End date from the selected range</param>
        /// <returns>Mobile sale details in json format</returns>
        public IEnumerable<MonthlyBrandSpecificSale> GetBrandWiseMobileSalesDetailsData(DateTime FromDate, DateTime ToDate)
        {
            //return mobileSalesContext.MonthlyMobileDetail.ToList();
            var StoredProc = "exec MonthlyBrandWiseSalesReport " +
                    "@FromDate = " + "'" + FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "@ToDate =" + "'" + ToDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            var test = mobileSalesContext.MonthlyBrandSpecificSale.FromSqlRaw(StoredProc).ToList();
            return test;
        }
        /// <summary>
        /// Get compared Mobile Sales Data
        /// </summary>
        /// <param name="FromDate">Start date from the selected range</param>
        /// <param name="ToDate">End date from the selected range</param>
        /// <returns>Mobile sale details in json format</returns>
        public IEnumerable<MobileSaleComparison> GetMobileComparisonSalesDetailsData(DateTime FromDate, DateTime ToDate)
        {
            //return mobileSalesContext.MonthlyMobileDetail.ToList();
            var StoredProc = "exec MonthlySaleComparisonSalesReport " +
                    "@FromDate = " + "'" + FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "@ToDate =" + "'" + ToDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            var test = mobileSalesContext.MobileSaleComparison.FromSqlRaw(StoredProc).ToList();
            return test;
        }
    }
}
