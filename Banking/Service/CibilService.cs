using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using Serilog;

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
            Log.Information("Inside Add-New-Cibil-Details:{@Controller}", GetType().Name);
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
            Log.Information("Inside Get-all-Cibil-Details:{@Controller}", GetType().Name);
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
            Log.Information("Inside Get-Cibil-Details-by-id:{@Controller}", GetType().Name);
            var GetCibil = Context.cibil.Where(x => x.CustomerId == id ).Select(x => new CibilVM()
            {
                
               CustomerId = x.CustomerId,
               CIBIL_year = x.CIBIL_year,
               CIBIL_Score = x.CIBIL_Score,

            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input is {JsonConvert.SerializeObject(id)}");
            return GetCibil;

        }

        public Cibil UpdateCibilDetails(int id, CibilVM cibil)
        {
            Log.Information("Inside update-Cibil-Details-By-id:{@Controller}", GetType().Name);
            var updateCibil = Context.cibil.FirstOrDefault(x => x.Id == id);
            if (updateCibil != null)
            {
                updateCibil.CustomerId=cibil.CustomerId;
                updateCibil.CIBIL_year = cibil.CIBIL_year;
                updateCibil.CIBIL_Score = cibil.CIBIL_Score;
            }
            Context.SaveChanges();
            Log.Information($"The user input is {JsonConvert.SerializeObject(id)}");
            return updateCibil;
        }

        public Cibil DeleteCibil(int id)
        {
            Log.Information("Inside Delet-Cibil-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteCibil = Context.cibil.FirstOrDefault(x => x.Id == id);
            Log.Information($"The user input is {JsonConvert.SerializeObject(id)}");
            if (DeleteCibil != null)
            {
                Context.cibil.Remove(DeleteCibil);
                Context.SaveChanges();
            }
            return DeleteCibil;
        }
    }
}
