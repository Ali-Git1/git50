using BigonApp.Infrastructure.Services.Abstracts;

namespace BigonApp.Infrastructure.Services.Concretes
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Executingtime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public class UtcDateTimeService : IDateTimeService
    {
        public DateTime Executingtime
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
