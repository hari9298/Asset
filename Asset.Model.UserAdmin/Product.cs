﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Model.UserAdmin
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
