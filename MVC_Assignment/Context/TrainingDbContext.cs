using MVC_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_Assignment.Context
{
    public class TrainingDbContext: DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Request> Requests { get; set; }
        
    }
}
