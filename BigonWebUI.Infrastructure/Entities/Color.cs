using BigonApp.Infrastructure.Commons.Concretes;
using BigonApp.Infrastructure.Entities;

namespace BigonApp.Infrastructure.Entities
{
    public class Color : BaseEntity<int>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }


    }
}
