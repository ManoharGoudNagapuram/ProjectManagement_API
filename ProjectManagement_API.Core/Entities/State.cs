using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class State:BaseEntity
    {
        public string Name {  get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
