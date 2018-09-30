using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntContacts : BasicModel
    {
        public EntContacts()
        {
            EntArticles = new HashSet<EntArticles>();
            EntBill = new HashSet<EntBill>();
            EntContactDetails = new HashSet<EntContactDetails>();
            RelContactsAddresses = new HashSet<RelContactsAddresses>();
            RelPhoneNumbersContacts = new HashSet<RelPhoneNumbersContacts>();
            RelUserContact = new HashSet<RelUserContact>();
        }
        [Key]
        public string ConId { get; set; }
        public int ConCode { get; }
        [Required]
        public string ConFirstName { get; set; }
        public string ConMidleName { get; set; }
        public string ConLastname { get; set; }
        public string ConObservation { get; set; }
        [Required]
        public bool IsUser { get; set; }

        public ICollection<EntArticles> EntArticles { get; set; }
        public ICollection<EntBill> EntBill { get; set; }
        public ICollection<EntContactDetails> EntContactDetails { get; set; }
        public ICollection<RelContactsAddresses> RelContactsAddresses { get; set; }
        public ICollection<RelPhoneNumbersContacts> RelPhoneNumbersContacts { get; set; }
        public ICollection<RelUserContact> RelUserContact { get; set; }
    }
}
