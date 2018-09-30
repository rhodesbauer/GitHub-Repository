using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntAddresses : BasicModel
    {
        public EntAddresses()
        {
            RelContactsAddresses = new HashSet<RelContactsAddresses>();
        }
        [Key]
        public string AddId { get; set; }
        [Required]
        public string AddName { get; set; }
        public string AddStreet { get; set; }
        public string AddNumber { get; set; }
        public string AddComplement { get; set; }
        public string AddZipCode { get; set; }
        [ForeignKey("Cit")]
        public string CitId { get; set; }

        public EntCities Cit { get; set; }
        public ICollection<RelContactsAddresses> RelContactsAddresses { get; set; }
    }
}
