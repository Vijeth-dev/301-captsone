using CustomerManagement.Repo;
using CustomerManagement.Repo.Entities.Models;
using CustomerManagement.Service.Abstractions;
using CustomerManagement.Service.Models;
using System.Collections.Generic;

namespace CustomerManagemenrSystem.Service.Business
{
    public class CustomerService : ICustomerService
    {
        public ICustomerManagementRepo _customerManagementRepo;
        public CustomerService(ICustomerManagementRepo customerRepository)
        {
            _customerManagementRepo = customerRepository;
        }

        public IEnumerable<TblCustomer> GetCustomerDetails()
        {
           return _customerManagementRepo.GetCustomers();
        }
    }
}
