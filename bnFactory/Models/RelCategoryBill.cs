using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelCategoryBill : BasicModel
    {
        [ForeignKey("Bil")]
        public string BilId { get; set; }
        [ForeignKey("Cat")]
        public string CatId { get; set; }

        public EntBill Bil { get; set; }
        public EntCategories Cat { get; set; }
    }
}
