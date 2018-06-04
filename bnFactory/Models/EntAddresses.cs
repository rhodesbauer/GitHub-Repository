using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntAddresses
    {
        public EntAddresses()
        {
            RelContactsAddresses = new HashSet<RelContactsAddresses>();
        }

        public string AddId { get; set; }
        public string AddName { get; set; }
        public string AddStreet { get; set; }
        public string AddNumber { get; set; }
        public string AddComplement { get; set; }
        public string AddZipCode { get; set; }
        public string CitId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntCities Cit { get; set; }
        public ICollection<RelContactsAddresses> RelContactsAddresses { get; set; }
    }
}
