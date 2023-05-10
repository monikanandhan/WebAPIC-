namespace Banking.ViewModel
{
    public class CibilVM
    {
        public int Id { get; set; }
       
        public string Aadhar_Number { get; set; }
        public string CIBIL_year { get; set; }
        public float CIBIL_Score { get; set; }
    }
    public class CibilNoId
    {
       

        public string Aadhar_Number { get; set; }
        public string CIBIL_year { get; set; }
        public float CIBIL_Score { get; set; }
    }
}
