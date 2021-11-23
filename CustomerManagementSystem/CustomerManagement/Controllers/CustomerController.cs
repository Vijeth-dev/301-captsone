using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Repo.Entities.Models;
using CustomerManagement.Service.Abstractions;
using CustomerManagement.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegister([Required][FromBody] Customer userDetails)
        {
            CustomerValidator customerValidator = new CustomerValidator();
            FluentValidation.Results.ValidationResult validationResult = customerValidator.Validate(userDetails);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToString("; "));
            }
            var result = await Task<int>.Run(() => _customerService.UserRegisteration(userDetails));
            if (result > 0)
            {
                return Ok("User Added Successfully");
            }
            else
                return BadRequest("User is not added");
        }
        
    }
}
