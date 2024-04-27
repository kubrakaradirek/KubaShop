namespace KubaShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        //appsettings bizim bağlantı işlemlerini gerçekleştireceğimiz konfigürasyondur. Ama burda crud işlemleri için her bir isme ihtiyacım olacak.
        public string FeatureSliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string OfferDiscountCollectionName { get; set; }
        public string BrandCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
    }
}
