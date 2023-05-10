using Banking.Model;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Banking.ViewModel
{
    public class CustomerVM
    {

        public int Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        [Required]
        public long Mobile_Number { get; set; }
        public string Email { get; set; }
        [Required]
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }
        public string Account_Number { get; set; }
        public string Account_Type { get; set; }
        public List<int> loanDetailsId { get; set; }
        public List<int> BankId { get; set; }
    }
    public class CustomerWithLoanDetailsVM
    {
        public int Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        [Required]
        public long Mobile_Number { get; set; }
        public string Email { get; set; }
        [Required]
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }

        public string Account_Number { get; set; }
        public string Account_Type { get; set; }
        
        public List<int> loanDetails { get; set; }
        public List<string> Bank_Details{get; set; }

    }

    public class CustomerDetailsVM
    {

       
        [Required]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        [Required]
        public long Mobile_Number { get; set; }
        public string Email { get; set; }
        [Required]
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }
        public string Account_Number { get; set; }
        public string Account_Type { get; set; }
       

    }
}
