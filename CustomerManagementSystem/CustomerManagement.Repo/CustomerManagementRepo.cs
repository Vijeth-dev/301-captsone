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
        public int UserRegisteration(TblCustomer user, byte[] passwordSalt)
        {
            _context.TblCustomer.Add(new TblCustomer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PasswordKey = passwordSalt.ToString(),
                Email = user.Email,
                MobileNumber = user.MobileNumber,
                Address = user.Address,
                UserCreated = 2,
                CreatedDate = DateTime.Now,
                Active = true
            });
            return _context.SaveChanges();

        }
    }
}
