using Microsoft.EntityFrameworkCore;

namespace sqlite_database
{
    public class SqliteDbContext : DbContext
    {
        public string DbPath { get; }

        public SqliteDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "website.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    internal class SqliteDb
    {
        private static void CreateConnection()
        {

        }
    }
}
