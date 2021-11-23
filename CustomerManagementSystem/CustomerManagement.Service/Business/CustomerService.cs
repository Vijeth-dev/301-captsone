using AutoMapper;
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
        public IMapper _Mapper { get; set; }
        public CustomerService(ICustomerManagementRepo customerRepository, IMapper Mapper)
        {
            _customerManagementRepo = customerRepository;
            _Mapper = Mapper;
        }

        public int UserRegisteration(Customer user)
        {
            var userDetails = _Mapper.Map<TblCustomer>(user);
            int result = -1;
            {
                byte[] passwordHash, passwordSalt;
                Helper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                userDetails.Password = passwordHash.ToString();//change ada
                result = _customerManagementRepo.UserRegisteration(userDetails, passwordSalt);
            }
            return result;
        }
    }
}
