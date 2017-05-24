using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tp3_AspNet.Data.EntitiesConfig;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspaceVS17\Tp3-AspNet\Tp3-AspNet.Data\DataBase\Tp3-AspNet-Database.mdf;Integrated Security=True")
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Conventions.Remove<PluralizingTableNameConvention>();
            mb.Properties<String>().Configure(p => p.HasColumnType("varchar").HasMaxLength(100));
            mb.Configurations.Add(new AuthorConfig());
            mb.Configurations.Add(new BookConfig());
            base.OnModelCreating(mb);
        }
    }
}
