using System.Collections.Generic;
using Admin.Component.Data;
using Admin.Demo.Core.Data.Configurations.Account;
using Admin.Demo.Core.Data.Configurations.Security;

namespace Admin.Demo.Core.Data.Configurations
{
    public class ConfigruationFactory
    {
        public List<IEntityMapper> CreatInstance()
        {
            var entityMappers = new List<IEntityMapper>();
            //Type classType = typeof (IEntityMapper);
            
            entityMappers.Add(new LoginLogConfiguration());
            entityMappers.Add(new MemberAddressConfiguration());
            entityMappers.Add(new MemberConfiguration());
            entityMappers.Add(new MemberExtendConfiguration());
            entityMappers.Add(new RoleConfiguration());
           
            return entityMappers;
        }
    }
}
