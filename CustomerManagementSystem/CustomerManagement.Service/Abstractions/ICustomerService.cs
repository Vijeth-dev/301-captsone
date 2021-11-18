using CustomerManagement.Repo.Entities.Models;
using CustomerManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Service.Abstractions
{
    public interface ICustomerService
    {
        public IEnumerable<TblCustomer> GetCustomerDetails();
        public IEnumerable<TblCustomer> CustomerDetails(int id);
    }
}
