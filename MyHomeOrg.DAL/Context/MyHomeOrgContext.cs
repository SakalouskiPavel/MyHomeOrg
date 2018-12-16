using System.Data.Entity;
using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.DAL.Configuration.User;

namespace MyHomeOrg.DAL.Context
{
    public class MyHomeOrgContext : DbContext
    {
        public MyHomeOrgContext(): base("MyHomeOrgDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyHomeOrgContext, Migrations.Configuration>());
        }

        public IDbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}