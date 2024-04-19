using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        //KubaShop.Catalog ==> CategoriesController ==> ICategoryService ==> ResultCategoryDto'daki kullandığımız propertylerden taşınmıştır
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
