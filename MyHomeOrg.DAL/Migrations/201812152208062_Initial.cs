namespace MyHomeOrg.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        account_id = c.Long(nullable: false, identity: true),
                        account_username = c.String(nullable: false),
                        account_email = c.String(nullable: false),
                        account_password = c.String(nullable: false),
                        account_permissions = c.Int(nullable: false),
                        account_created_date = c.DateTime(nullable: false),
                        account_creator_id = c.Long(nullable: false),
                        account_last_updated = c.DateTime(),
                        account_updater_id = c.Long(),
                    })
                .PrimaryKey(t => t.account_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.accounts");
        }
    }
}
