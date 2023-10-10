using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Contexts
{
    public class DbFactory : IDesignTimeDbContextFactory<DB>
    {
        public DB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DB>();
            optionsBuilder.UseMySQL("server=127.0.0.1;database=RMSDB;user id=root; password=;");

            return new DB(optionsBuilder.Options);
        }
    }
}
