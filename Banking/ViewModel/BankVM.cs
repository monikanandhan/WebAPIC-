using Banking.Model;

namespace Banking.ViewModel
{
    public class BankVM
    {
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string IFSC { get; set; }
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }
        public List<Customer_Bank> Customer_Banks { get; set; }

    }

    public class BankByNameVM
    {
        public int Id { get;set; }
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string IFSC { get; set; }
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }

    }

    public class BankListVM
    {
        
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string IFSC { get; set; }
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }

    }
    public class BankWithCustomerVM
    {
        public int Id { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string IFSC { get; set; }
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }
        public List<string> customers { get; set; }

    }
}
