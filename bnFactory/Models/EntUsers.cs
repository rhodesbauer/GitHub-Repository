using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
    public partial class EntUsers : BasicModel
    {
        public EntUsers()
        {
            RelUserContact = new HashSet<RelUserContact>();
            RelUserProfiles = new HashSet<RelUserProfiles>();
        }
        [Key]
        public string UserId { get; set; }
        public int UserCode { get; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserKey { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public ICollection<RelUserContact> RelUserContact { get; set; }
        public ICollection<RelUserProfiles> RelUserProfiles { get; set; }
    }
}
