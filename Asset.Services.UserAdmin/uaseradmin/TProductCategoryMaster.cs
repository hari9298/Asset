using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TProductCategoryMaster
    {
        public TProductCategoryMaster()
        {
            TProductMaster = new HashSet<TProductMaster>();
        }

        public int Id { get; set; }
        public string CatId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TProductMaster> TProductMaster { get; set; }
    }
}
