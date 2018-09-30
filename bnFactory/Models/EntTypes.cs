using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntTypes : BasicModel
    {
        public EntTypes()
        {
            EntAccounts = new HashSet<EntAccounts>();
            EntCategories = new HashSet<EntCategories>();
        }
        [Key]
        public string TypId { get; set; }
        [Required]
        public bool? TypAllowChange { get; set; }
        public int TypCode { get; }
        [Required]
        [MaxLength(50)]
        public string TypName { get; set; }

        public ICollection<EntAccounts> EntAccounts { get; set; }
        public ICollection<EntCategories> EntCategories { get; set; }
    }
}
