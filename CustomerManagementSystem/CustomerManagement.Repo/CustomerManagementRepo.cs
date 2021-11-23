using CustomerManagement.Repo.Entities.Context;
using CustomerManagement.Repo.Entities.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Repo
{
    public class CustomerManagementRepo : ICustomerManagementRepo
    {
        private readonly CustomerManagementContext _context;
        public CustomerManagementRepo()
        {
            
            //_context = new CustomerManagementContext(_connectionStrings.Value.DB);
            _context = new CustomerManagementContext("Data Source=VSSqlKibana\\SQLEXPRESS;Initial Catalog=CustomerManagement;Integrated Security=True");
        }
        public IEnumerable<TblCustomer> GetCustomers()
        {
            return _context.TblCustomer;
        }
    }
}
