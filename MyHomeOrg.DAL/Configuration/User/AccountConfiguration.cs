using System.Data.Entity.ModelConfiguration;
using MyHomeOrg.Common.DbModels.User;

namespace MyHomeOrg.DAL.Configuration.User
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("accounts");

            HasKey(account => account.Id);

            Property(account => account.Id).IsRequired().HasColumnName("account_id");
            Property(account => account.Username).IsRequired().HasColumnName("account_username");
            Property(account => account.Password).IsRequired().HasColumnName("account_password");
            Property(account => account.Email).IsRequired().HasColumnName("account_email");
            Property(account => account.Permissions).IsRequired().HasColumnName("account_permissions");
            Property(account => account.CreatedDate).IsRequired().HasColumnName("account_created_date");
            Property(account => account.CreatedBy).IsRequired().HasColumnName("account_creator_id");
            Property(account => account.ModifiedDate).IsOptional().HasColumnName("account_last_updated");
            Property(account => account.ModifiedBy).IsOptional().HasColumnName("account_updater_id");
        }
    }

}