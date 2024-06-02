using BigonApp.Infrastructure.Commons.Concretes;

namespace BigonApp.Infrastructure.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public int ParentId { get; set; }


    }
}
