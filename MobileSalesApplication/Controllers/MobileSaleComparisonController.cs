using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileSalesApplication.Data;
using MobileSalesApplication.Repository.MobileRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileSalesApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSaleComparisonController : ControllerBase
    {
        private readonly MobileSaleContext _context;
        public IMobileRepository mobileRepository;
        public MobileSaleComparisonController(MobileSaleContext context, IMobileRepository mobileRepository)
        {
            _context = context;
            this.mobileRepository = mobileRepository;
        }

        /// <summary>
        /// Get Brand Wise Mobile Sales Data
        /// </summary>
        /// <param name="FromDate">Start date from the selected range</param>
        /// <param name="ToDate">End date from the selected range</param>
        /// <returns>Mobile sale details in json format</returns>
        [HttpGet("MonthlyComparisonMobileSales")]
        public async Task<ActionResult<IEnumerable<MobileSaleComparison>>> GetMobileComparisonSalesDetailsData(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var monthlyComparison = await Task.FromResult(mobileRepository.GetMobileComparisonSalesDetailsData(FromDate, ToDate));
                return Ok(monthlyComparison);
            }
            catch (Exception e)
            {
                return BadRequest("Could not fetch test data");
            }
        }
    }
}
