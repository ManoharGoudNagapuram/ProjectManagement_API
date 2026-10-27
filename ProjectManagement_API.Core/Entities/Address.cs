using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Address:BaseEntity
    {
        public string AddressLine1 {  get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public int StateId { get; private set; }
        public string PostalCode { get; private set; }
        public int CountryId { get; private set; }

        public State State { get; private set; }
        public Country Country { get; private set; }

        private Address()
        {

        }
        private Address(string addrLine1, string addrLine2, string city,
            int stateId, string postalCode, int countryId) {
            AddressLine1=addrLine1;
            AddressLine2=addrLine2;
            City=city;
            StateId=stateId;
            PostalCode=postalCode;
            CountryId=countryId;
        }

        public static Address Create(string addrLine1, string addrLine2, string city,
            int stateId,string postalCode, int countryId)
        {
            if(string.IsNullOrWhiteSpace(addrLine1))
                throw new ArgumentNullException("AddressLine1 is required.");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException("City is required.");

            if (stateId<=0)
                throw new ArgumentNullException("State is required.");

            if (countryId <= 0)
                throw new ArgumentNullException("COuntry is required.");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentNullException("PostalCode is required.");

            return new Address(addrLine1, addrLine2, city, stateId, postalCode, countryId);
        }
    }
}
