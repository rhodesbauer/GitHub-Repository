using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntContacts
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

        public string ConId { get; set; }
        public int ConCode { get; set; }
        public string ConFirstName { get; set; }
        public string ConMidleName { get; set; }
        public string ConLastname { get; set; }
        public string ConObservation { get; set; }
        public bool IsUser { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<EntArticles> EntArticles { get; set; }
        public ICollection<EntBill> EntBill { get; set; }
        public ICollection<EntContactDetails> EntContactDetails { get; set; }
        public ICollection<RelContactsAddresses> RelContactsAddresses { get; set; }
        public ICollection<RelPhoneNumbersContacts> RelPhoneNumbersContacts { get; set; }
        public ICollection<RelUserContact> RelUserContact { get; set; }
    }
}
