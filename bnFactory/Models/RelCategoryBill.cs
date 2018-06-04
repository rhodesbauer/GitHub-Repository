using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelCategoryBill
    {
        public string BilId { get; set; }
        public string CatId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntBill Bil { get; set; }
        public EntCategories Cat { get; set; }
    }
}
