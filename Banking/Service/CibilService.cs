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

        public void AddNewCibil(CibilNoId cibil)
        {
            Log.Information("Inside Add-New-Cibil-Details:{@Controller}", GetType().Name);
            var NewCibil = new Cibil()
            {
               
             Aadhar_Number=cibil.Aadhar_Number,
               CIBIL_year=cibil.CIBIL_year,
               CIBIL_Score=cibil.CIBIL_Score


            };
            Context.cibil.Add(NewCibil);
            Context.SaveChanges();
        }

        public List<CibilNoId> GetAllCibil()
        {
            Log.Information("Inside Get-all-Cibil-Details:{@Controller}", GetType().Name);
            var GetCibil = Context.cibil.Select(x => new CibilNoId()
            {

               
                Aadhar_Number=x.Aadhar_Number,
                CIBIL_year = x.CIBIL_year,
                CIBIL_Score = x.CIBIL_Score,

            }).ToList();
            Context.SaveChanges();
            return GetCibil;
        }

        public List<CibilVM> GetCibilbyCustomerAadhar(string Aadhar)
        {
            Log.Information("Inside Get-Cibil-Details-by-Aadhar:{@Controller}", GetType().Name);
            var GetCibil = Context.cibil.Where(x => x.Aadhar_Number == Aadhar ).Select(x => new CibilVM()
            {
                
                 Id=x.Id,
               Aadhar_Number=x.Aadhar_Number,
               CIBIL_year = x.CIBIL_year,
               CIBIL_Score = x.CIBIL_Score,

            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input for Get-Cibil-Details-by-id is {JsonConvert.SerializeObject(Aadhar)}");
            return GetCibil;

        }

        public Cibil UpdateCibilDetails(string Aadhar, CibilNoId cibil)
        {
            Log.Information("Inside update-Cibil-Details-By-id:{@Controller}", GetType().Name);
            var updateCibil = Context.cibil.FirstOrDefault(x => x.Aadhar_Number == Aadhar);
            if (updateCibil != null)
            {
               
                updateCibil.CIBIL_year = cibil.CIBIL_year;
                updateCibil.CIBIL_Score = cibil.CIBIL_Score;
            }
            Context.SaveChanges();
            Log.Information($"The user input for  update-Cibil-Details-By-id is {JsonConvert.SerializeObject(Aadhar)}");
            return updateCibil;
        }

        public Cibil DeleteCibil(string Aadhar,int  id)
        {
            Log.Information("Inside Delete-Cibil-Details-By-Customer-Id:{@Controller}", GetType().Name);
            var DeleteCibil = Context.cibil.FirstOrDefault(x => x.Aadhar_Number == Aadhar && x.Id==id);
            Log.Information($"The user input for Delete-Cibil-Details-By-Customer-Id is {JsonConvert.SerializeObject(Aadhar)}");
            if (DeleteCibil != null)
            {
                Context.cibil.RemoveRange(DeleteCibil);
                Context.SaveChanges();
            }
            return DeleteCibil;
        }
    }
}
