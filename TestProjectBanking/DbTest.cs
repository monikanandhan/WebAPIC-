using Banking.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBanking
{
    public class DbTest:CustomerTest
    {
        public DbTest()
            : base(
                new DbContextOptionsBuilder<BankingDbContext>()
                    .UseMySQL("server=localhost;port=3306;database=Banking;user=root;password=")
                    .Options)
        {
        }
    }
}
