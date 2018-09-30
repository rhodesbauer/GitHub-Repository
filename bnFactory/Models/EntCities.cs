using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntCities : BasicModel
    {
        public EntCities()
        {
            EntAddresses = new HashSet<EntAddresses>();
        }
        [Key]
        public string CitId { get; set; }
        [Required]
        public string CitName { get; set; }
        public string CitState { get; set; }
        [Required]
        public string CitCountry { get; set; }

        public ICollection<EntAddresses> EntAddresses { get; set; }
    }
}
