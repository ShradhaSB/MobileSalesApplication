using Microsoft.EntityFrameworkCore;
using MobileSalesApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleTestProj
{
    public static class DbContextMocker
    {
        public static MobileSaleContext GetDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<MobileSaleContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new MobileSaleContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
