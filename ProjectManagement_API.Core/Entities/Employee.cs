using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Employee:BaseEntity
    {
        public string FirstName {  get; private set; }
        public string LastName { get; private set; }
        public DateTime DOB {  get; private set; }
        public string EmailAddress {  get; private set; }
        public string PhoneNumber { get; private set; }
        public int AddressId {  get; private set; }
        public int DepartmentId {  get; private set; }

        public Department Department { get; private set; }
        public Address Address { get; private set; }

        private Employee()
        {

        }
        private Employee(string firstName, string lastName,
            DateTime dob, string emailAddress, string phoneNumber, int departmentId,
            Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            DepartmentId = departmentId;
            Address = address;
        }

        //domain entity creation control should be inside domain/core layer only.
        public static Employee Create(string firstName, string lastName,
            DateTime dob, string emailAddress, string phoneNumber,int departmentId,
            Address address )
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName is required.");

            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("EmailAddress is required.");

            if (departmentId <= 0)
                throw new ArgumentException("Department is required.");

            if(address == null)
                throw new ArgumentNullException("Address is required.");

            return new Employee(firstName, lastName, dob, emailAddress, phoneNumber, departmentId, address);
        }
       

    }
}
