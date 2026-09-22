using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Address:BaseEntity
    {
        public string AddressLine1 {  get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }

        public State State { get; set; }
        public Country Country { get; set; }
    }
}
