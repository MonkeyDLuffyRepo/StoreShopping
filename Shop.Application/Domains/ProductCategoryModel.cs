using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Domains
{
    public  class ProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasSubCategory { get; set; }
        public int ParentId { get; set; }
     
    }
}
