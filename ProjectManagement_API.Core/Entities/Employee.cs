using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Employee:BaseEntity
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime DOB {  get; set; }
        public string EmailAddress {  get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId {  get; set; }
        public int DepartmentId {  get; set; }

        public Department Department { get; set; }
        public Address Address { get; set; }

    }
}
