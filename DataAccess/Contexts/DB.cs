using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

//DbContext features are inherited to the DB
public class DB : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<UserResource> UserResources { get; set; }


    public DB(DbContextOptions options): base(options)
    {
        //constructor dependency injection
    }


    //virtual methodları override edebiliriz. Virtual tanımlamadıysak alttaki sınıfta ezemeyiz!!!
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //e delegesi Entity<UserResource> u delege eder
        //delegenin amacı BİR ÖNCEKİ METHODUN ÖZELLİKLERİNİ YAPTIRIR
        modelBuilder.Entity<UserResource>().HasKey(e => new {e.UserId, e.ResourceId} );
    }
}
