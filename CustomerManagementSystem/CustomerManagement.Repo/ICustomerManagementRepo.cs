using CustomerManagement.Repo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Repo
{
    public interface ICustomerManagementRepo
    {
        public IEnumerable<TblCustomer> GetCustomers();
    }
}
