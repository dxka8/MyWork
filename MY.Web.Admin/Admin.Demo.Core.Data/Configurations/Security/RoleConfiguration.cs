using System.Data.Entity.ModelConfiguration;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Security;

namespace Admin.Demo.Core.Data.Configurations.Security
{
    partial class RoleConfiguration : EntityTypeConfiguration<Role>, IEntityMapper
    {
        partial void RoleConfigurationAppend()
        {
            HasMany(m => m.Members).WithMany(n => n.Roles);
        }


        
    }
}
