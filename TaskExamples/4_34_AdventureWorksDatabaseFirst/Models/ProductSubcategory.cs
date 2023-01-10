using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _4_34_AdventureWorksDatabaseFirst.Models
{
    public partial class ProductSubcategory
    {
        public ProductSubcategory()
        {
            Product = new HashSet<Product>();
        }

        public int ProductSubcategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
