using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TProductMaster
    {
        public int Id { get; set; }
        public string ProdId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int Status { get; set; }

        public virtual TProductCategoryMaster Cat { get; set; }
    }
}
