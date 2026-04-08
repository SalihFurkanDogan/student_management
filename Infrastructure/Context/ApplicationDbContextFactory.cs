using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var conString = "Server=localhost;Port=3306;Database=scs;Uid=root;Pwd=Furkan123;";
            optionsBuilder.UseMySql(conString, ServerVersion.AutoDetect(conString));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}