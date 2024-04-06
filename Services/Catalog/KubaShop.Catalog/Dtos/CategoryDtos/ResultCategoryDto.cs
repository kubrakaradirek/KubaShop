namespace KubaShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        //Dtos:Her bir crud işlemi için single responsibility ezmemek adına dtoslar yazılır.

        //Single responsibilirty:Birinci solid prensibi her bir interface ve sınıf ayrı ayrı yazılmalı tek olma prensibi.
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
