using Microsoft.EntityFrameworkCore;

namespace Banking.Model
{
    public class BankingDbContext:DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options):base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_LoanDetails>().HasOne(c => c.customer).WithMany(cl => cl.loanDetailsCusList).
                HasForeignKey(f => f.CsutomerId);

            modelBuilder.Entity<Customer_LoanDetails>().HasOne(c => c.loanDetails).WithMany(cl => cl.loanDetailsCusList).
                HasForeignKey(f => f.LoanDetailsDemoId);

            modelBuilder.Entity<Customer_Bank>().HasOne(c => c.customer).WithMany(cl => cl.Customer_Banks).
                HasForeignKey(f => f.customerId);

            modelBuilder.Entity<Customer_Bank>().HasOne(c => c.Bank).WithMany(cl => cl.Customer_Banks).
                HasForeignKey(f => f.BankId);

            

        }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bank> bank { get; set; }
        public DbSet<LoanDetails> loanDetail { get; set; }
        public DbSet<Loan_Loandetails> loan_loanDetails { get; set; }
        public DbSet<Customer_LoanDetails> customer_LoanDetails { get; set; }
        public DbSet<Customer_Bank> customer_Banks { get; set; }
        public DbSet<BankLoan> bankloan { get; set; }

        public DbSet<Cibil> cibil { get; set; }
       
    }
}
