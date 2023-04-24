using Domain;
using EFcDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;

namespace EFcDataAccess;

public class ForumContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Forum> Forums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Forum.db");
    }
}