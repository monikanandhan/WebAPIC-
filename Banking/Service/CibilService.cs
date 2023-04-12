using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Banking.Service
{
    public class CibilService
    {
        public BankingDbContext Context { get; set; }
        public CibilService(BankingDbContext context) 
        { 
            Context = context;
        }

        public void AddNewCibil(CibilVM cibil)
        {
            var NewCibil = new Cibil()
            {
               CustomerId= cibil.CustomerId,
            
               CIBIL_year=cibil.CIBIL_year,
               CIBIL_Score=cibil.CIBIL_Score


            };
            Context.cibil.Add(NewCibil);
            Context.SaveChanges();
        }

        public List<CibilVM> GetAllCibil()
        {

            var GetCibil = Context.cibil.Select(x => new CibilVM()
            {

                CustomerId = x.CustomerId,
                CIBIL_year = x.CIBIL_year,
                CIBIL_Score = x.CIBIL_Score,

            }).ToList();
            Context.SaveChanges();
            return GetCibil;
        }

        public List<CibilVM> GetCibilbyCustomerid(int id)
        {
            var GetCibil = Context.cibil.Where(x => x.CustomerId == id ).Select(x => new CibilVM()
            {
                
               CustomerId = x.CustomerId,
               CIBIL_year = x.CIBIL_year,
               CIBIL_Score = x.CIBIL_Score,

            }).ToList();
            Context.SaveChanges();
            return GetCibil;

        }

        public Cibil UpdateCibilDetails(int id, CibilVM cibil)
        {
            var updateCibil = Context.cibil.FirstOrDefault(x => x.Id == id);
            if (updateCibil != null)
            {
                updateCibil.CustomerId=cibil.CustomerId;
                updateCibil.CIBIL_year = cibil.CIBIL_year;
                updateCibil.CIBIL_Score = cibil.CIBIL_Score;
            }
            Context.SaveChanges();
            return updateCibil;
        }

        public void DeleteCibil(int id)
        {
            var DeleteCibil = Context.cibil.FirstOrDefault(x => x.Id == id);
            if (DeleteCibil != null)
            {
                Context.cibil.Remove(DeleteCibil);
                Context.SaveChanges();
            }
        }
    }
}
