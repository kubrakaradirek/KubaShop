using Amazon.Runtime;
using AutoMapper;
using KubaShop.Catalog.Dtos.CategoryDtos;
using KubaShop.Catalog.Dtos.ProductDetailDtos;
using KubaShop.Catalog.Dtos.ProductDtos;
using KubaShop.Catalog.Dtos.ProductImageDtos;
using KubaShop.Catalog.Entities;

namespace KubaShop.Catalog.Mapping
{
    public class GeneralMapping:Profile //Profile AutoMapper kütüphanesini kullanır.
    {
        //Mappleme işleminde AutoMapper kullanmamızın amacı Entityler ile Dtoların etkileşimi için kullanılır. Const metodunda mappleme işlemi yapılır. Mappleme işleminin amacı entitylerinden nesne örnekleri oluşturmak yerine entitieslerin propertylerini dto daki propertylerle eşleştirecektir.
        public GeneralMapping()
        {
            //---------------   Category Mapping İşlemleri --------------

            CreateMap<Category,ResultCategoryDto>().ReverseMap(); //ReverseMap:ResultCategoryDto ile Category ile mapleme de olabilir ondan kullanıldı.
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

            //---------------   Product Mapping İşlemleri --------------

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            //---------------   ProductDetail Mapping İşlemleri --------------

            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            //---------------  ProductImage Mapping İşlemleri --------------

            CreateMap<ProductImage,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            


        }
    }
}
