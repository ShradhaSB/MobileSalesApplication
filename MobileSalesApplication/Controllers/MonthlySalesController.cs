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
    public class MonthlySalesController : ControllerBase
    {
        private readonly MobileSaleContext _context;
        public IMobileRepository mobileRepository;
        public MonthlySalesController(MobileSaleContext context,IMobileRepository mobileRepository)
        {
            _context = context;
            this.mobileRepository = mobileRepository;
        }

        /// <summary>
        /// Get Mobile Sales Data
        /// </summary>
        /// <param name="FromDate">Start date from the selected range</param>
        /// <param name="ToDate">End date from the selected range</param>
        /// <returns>Mobile sale details in json format</returns>
        [HttpGet("MonthlyMobileSales")]
        public async Task<ActionResult<IEnumerable<MonthlySale>>> GetMonthlySales(DateTime FromDate,DateTime ToDate)
        {
            try
            {
                var monthlySaleDetails = await Task.FromResult(mobileRepository.GetMobileSaleDetailsData(FromDate, ToDate));
                return Ok(monthlySaleDetails);
            }
            catch (Exception e)
            {
                return BadRequest("Could not fetch test data");
            }
        }
    }
}
