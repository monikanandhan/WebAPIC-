using Banking.ViewModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Banking.Model
{
    public class Customer
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        [Required(ErrorMessage = "First Mobile Number is required")]  
        public long Mobile_Number { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Aadhar is required")]
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string pincode { get; set; }
        public string Account_Number { get; set; }
        public string Account_Type { get; set; }

        //Navigation properties
       
        public List<LoanDetails> loanDetailsCus { get; set; }      
        public List<Customer_LoanDetails> loanDetailsCusList { get; set; }       
        public List<Bank> banks { get; set; }      
        public List<Customer_Bank> Customer_Banks { get; set; }

    }
}
