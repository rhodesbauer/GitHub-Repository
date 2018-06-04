using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntCities
    {
        public EntCities()
        {
            EntAddresses = new HashSet<EntAddresses>();
        }

        public string CitId { get; set; }
        public string CitName { get; set; }
        public string CitState { get; set; }
        public string CitCountry { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<EntAddresses> EntAddresses { get; set; }
    }
}
