using System;

namespace CustomerManagement.Repo.Entities.Models
{
    public class TblCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public int Id { get; set; }
        public int UserCreated { get; set; }
        public int UserModified { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Totalorders { get; set; }

    }
}
