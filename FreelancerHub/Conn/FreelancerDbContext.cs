using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FreelancerHub.Models;


namespace FreelancerHub.Conn
{
    public class FreelancerDbContext : DbContext
    {
        public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options) : base(options) { }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freelancer>().HasMany(f => f.Skillsets)
                .WithOne(s => s.Freelancer)
                .HasForeignKey(s => s.F_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Freelancer>().HasMany(f => f.Hobbies)
                .WithOne(h => h.Freelancer)
                .HasForeignKey(h => h.F_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
