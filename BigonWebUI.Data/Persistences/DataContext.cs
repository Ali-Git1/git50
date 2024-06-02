using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Services.Abstracts;
using BigonApp.Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;



namespace BigonApp.Models
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions options;
        private readonly IDateTimeService _dateTimeService;
        private readonly IUserService _identityService;

        public DataContext(DbContextOptions options,IDateTimeService dateTimeService, IUserService identityService) : base(options)
        {
            this.options = options;
            _dateTimeService = dateTimeService;
            _identityService = identityService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //modelBuilder.ApplyConfiguration<Color>(new ColorEntityConfiguration());    //her defe elave model olduqca bu kod tekrarlanacaq ve bunuda qisaltmaq mumkundur
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);  //bu datacontexde bunun oldugu assemblyde ne qeder configuration varsa islet

        }

        public override int SaveChanges()
        {
            

            var changes=  this.ChangeTracker.Entries<Infrastructure.Commons.Abstracts.IAuditableEntity>();

            if(changes!=null)
            {
                foreach (var entity in changes
                    .Where(ch=>ch.State==EntityState.Added ||
                    ch.State==EntityState.Deleted || 
                    ch.State==EntityState.Modified))

                {
                    switch (entity.State)
                    {
                       
                        case EntityState.Added:
                            entity.Entity.CreatedAt = _dateTimeService.Executingtime;
                            entity.Entity.CreatedBy = _identityService.GetPrincipialId();
                            break;

                        case EntityState.Modified:
                            entity.Entity.ModifiedAt = _dateTimeService.Executingtime;
                            entity.Entity.ModifiedBy = _identityService.GetPrincipialId();
                            break;

                        case EntityState.Deleted:
                            entity.State = EntityState.Modified;
                            entity.Entity.DeletedAt = _dateTimeService.Executingtime;
                            entity.Entity.DeletedBy = _identityService.GetPrincipialId();
                            break;

                        default:
                            break;
                    }
                }
            }


            return base.SaveChanges();
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

    }
}
