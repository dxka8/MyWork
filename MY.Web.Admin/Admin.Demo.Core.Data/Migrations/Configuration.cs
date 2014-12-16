using System.Collections.Generic;
using Admin.Demo.Core.Data.Context;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EfDbContext context)
        {
            var members = new List<Member>()
            {
                new Member(){Email = "258065584@qq.com",Password = "123456",NickName = "‘¯∑≤”Í",UserName = "dxka8zfy"},
                new Member(){Email = "258065584@qq.com",Password = "123456",NickName = "π‹¿Ì‘±",UserName = "admin"}
            };
            var memberSet = context.Set<Member>();
            memberSet.AddOrUpdate(m => m.UserName, members.ToArray());

        }
    }
}
