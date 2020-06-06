using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SportShop.WebUI.ViewModel
{
    public class OrderViewModel
    {
        
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public decimal Total { get; set; }
        
    }
}