using CourseWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;

// юзал chatGPT, т.к. вообще не работал c InMemoryDb

namespace CourseWarehouse.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {
        }
        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTag>()
                .HasKey(ct => new { ct.CourseId, ct.TagId });
                
            modelBuilder.Entity<UserTag>()
                .HasKey(ut => new { ut.UserId, ut.TagId });
            
            base.OnModelCreating(modelBuilder);
        }

    }
}