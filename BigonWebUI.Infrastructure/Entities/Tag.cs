using BigonApp.Infrastructure.Commons.Concretes;

namespace BigonApp.Infrastructure.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Title { get; set; }

    }
}
