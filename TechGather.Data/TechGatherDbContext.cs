namespace TechGather.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Models;
    using Configurations;


    public class TechGatherDbContext : IdentityDbContext
    {
        private readonly bool seedDb;
        public TechGatherDbContext(DbContextOptions<TechGatherDbContext> options, bool seedDb = true)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventEntityConfiguration());

            //if (this.seedDb)
            //{
                builder.ApplyConfiguration(new CategorySeederEntityConfiguration());
            //}

            base.OnModelCreating(builder);
        }
    }
}
