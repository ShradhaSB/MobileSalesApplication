using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileSalesApplication.Data;
using MobileSalesApplication.Repository.MobileRepository;

namespace MobileSalesApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyBrandSpecificSalesController : ControllerBase
    {
        private readonly MobileSaleContext _context;
        public IMobileRepository mobileRepository;
        public MonthlyBrandSpecificSalesController(MobileSaleContext context, IMobileRepository mobileRepository)
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
        [HttpGet("MonthlyBrandWiseMobileSales")]
        public async Task<ActionResult<IEnumerable<MonthlyBrandSpecificSale>>> GetMonthlyBrandSpecificSales(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var monthlyBrandSpecifics = await Task.FromResult(mobileRepository.GetBrandWiseMobileSalesDetailsData(FromDate, ToDate));
                return Ok(monthlyBrandSpecifics);
            }
            catch (Exception e)
            {
                return BadRequest("Could not fetch test data");
            }
        }
    }
}
