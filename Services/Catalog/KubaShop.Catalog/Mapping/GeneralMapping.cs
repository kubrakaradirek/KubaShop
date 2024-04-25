using Amazon.Runtime;
using AutoMapper;
using KubaShop.Catalog.Dtos.CategoryDtos;
using KubaShop.Catalog.Dtos.FeatureDtos;
using KubaShop.Catalog.Dtos.FeatureSliderDtos;
using KubaShop.Catalog.Dtos.OfferDiscountDtos;
using KubaShop.Catalog.Dtos.ProductDetailDtos;
using KubaShop.Catalog.Dtos.ProductDtos;
using KubaShop.Catalog.Dtos.ProductImageDtos;
using KubaShop.Catalog.Dtos.SpecialOfferDtos;
using KubaShop.Catalog.Entities;

namespace KubaShop.Catalog.Mapping
{
    public class GeneralMapping:Profile//Profile AutoMapper kütüphanesini kullanır.
    {
        //Mappleme işleminde AutoMapper kullanmamızın amacı Entityler ile Dtoların etkileşimi için kullanılır. Const metodunda mappleme işlemi yapılır. Mappleme işleminin amacı entitylerinden nesne örnekleri oluşturmak yerine entitieslerin propertylerini dto daki propertylerle eşleştirecektir.
        public GeneralMapping()
        {
            //---------------   Category Mapping İşlemleri --------------

            CreateMap<Category,ResultCategoryDto>().ReverseMap();//ReverseMap:ResultCategoryDto ile Category ile mapleme de olabilir ondan kullanıldı.
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

            //---------------  FutureSlider Mapping İşlemleri --------------

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            //---------------  SpecialOffer Mapping İşlemleri --------------

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            //---------------  Feature Mapping İşlemleri --------------

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            //---------------  OfferDiscount Mapping İşlemleri --------------

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
        }
    }
}
