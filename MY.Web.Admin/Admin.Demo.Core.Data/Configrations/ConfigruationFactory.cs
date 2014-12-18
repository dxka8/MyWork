using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Compoent.Tool.T4;
using Admin.Component.Data;
using Admin.Demo.Core.Data.Configrations.Account;
using Admin.Demo.Core.Data.Configrations.security;

namespace Admin.Demo.Core.Data.Configrations
{
    public class ConfigruationFactory
    {
        public List<IEntityMapper> CreatInstance()
        {
            var entityMappers = new List<IEntityMapper>();
            //Type classType = typeof (IEntityMapper);
            
            entityMappers.Add(new LoginLogConfiguration());
            entityMappers.Add(new MemberAddressConfiguration());
            entityMappers.Add(new MemberConfiguraction());
            entityMappers.Add(new MemberExtendConfigraction());
            entityMappers.Add(new RoleConfiguration());
           
            return entityMappers;
        }
    }
}
