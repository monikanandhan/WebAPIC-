namespace Banking.Model
{
    public class Cibil
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get;set; }
        public string CIBIL_year { get; set; }
        public float CIBIL_Score { get; set; }  
    }
}
