using DataAccess.Entities;

namespace DataAccess;

//DbContext features are inherited to the DB
public class DB : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<UserResource> UserResources { get; set; }
}
