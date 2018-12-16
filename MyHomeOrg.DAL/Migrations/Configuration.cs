using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.Common.Enums;

namespace MyHomeOrg.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyHomeOrg.DAL.Context.MyHomeOrgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyHomeOrg.DAL.Context.MyHomeOrgContext context)
        {
            context.Accounts.AddOrUpdate(new Account()
            {
                Id = 1,
                Email = "p.sokolovsky62@gmail.com",
                Username = "admin",
                Password = "admin",
                Permissions = PermissionTypes.Base | PermissionTypes.UserManagement,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                ModifiedBy = null
            });

            context.Accounts.AddOrUpdate(new Account()
            {
                Id = 2,
                Email = "p.sokolovsky62@gmail.com",
                Username = "user",
                Password = "user",
                Permissions = PermissionTypes.Base,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                ModifiedBy = null
            });
            base.Seed(context);
        }
    }
}
