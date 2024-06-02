using BigonApp.Infrastructure.Commons.Concretes;

namespace BigonApp.Infrastructure.Entities
{
    public class Manufacture : BaseEntity<int>
    {
        public string BrandOne { get; set; }
        public string BrandTwo { get; set; }
        public string BrandThree { get; set; }
        public string BrandFour { get; set; }
        public string BrandFive { get; set; }
    }
}
