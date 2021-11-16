using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagemenrSystem.Service.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Customer_FirstName { get; set; }

        public string Customer_LastName { get; set; }
    }
}
