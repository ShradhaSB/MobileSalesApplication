using Microsoft.AspNetCore.Mvc;
using MobileSalesApplication.Controllers;
using MobileSalesApplication.Data;
using MobileSalesApplication.Repository.MobileRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobileSaleTestProj
{
    public class MobileSaleUnitTest
    {
        [Fact]
        public async Task TestMobileSalesAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(TestMobileSalesAsync));
           var repository = new MobileRepository(dbContext);

            // Act
            var response = (repository.GetMobileSaleDetailsData(DateTime.Now,DateTime.Now));
            var value = response.ToList().Count>0;

            dbContext.Dispose();

            // Assert
            Assert.True(value);
        }
        [Fact]
        public async Task TestBrandSpecificMobileSalesAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(TestBrandSpecificMobileSalesAsync));
            var repository = new MobileRepository(dbContext);

            // Act
            var response = (repository.GetBrandWiseMobileSalesDetailsData(DateTime.Now, DateTime.Now));
            var value = response.ToList().Count > 0;

            dbContext.Dispose();

            // Assert
            Assert.True(value);
        }
        [Fact]
        public async Task TestMobileComparisonSalesAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(TestMobileComparisonSalesAsync));
            var repository = new MobileRepository(dbContext);

            // Act
            var response = (repository.GetMobileComparisonSalesDetailsData(DateTime.Now, DateTime.Now));
            var value = response.ToList().Count > 0;

            dbContext.Dispose();

            // Assert
            Assert.True(value);
        }
    }
}
