using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NietDiscord.Models;

namespace NietDiscord.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
       // public DbSet<User> Users { get; set; }
       // public DbSet<UserMessage> UserMessages {get; set;}
       public DbSet<Friends> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<UserMessage>()
                .HasKey(bc => new { bc.UserID, bc.ID });
            modelBuilder.Entity<UserMessage>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Usermessages)
                .HasForeignKey(bc => bc.UserID);
            modelBuilder.Entity<UserMessage>()
                .HasOne(bc => bc.Message)
                .WithMany(c => c.UsersMessages)
                .HasForeignKey(bc => bc.ID);*/
        }
    }
}
