using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Demo.Core.Data.Context;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Initialize
{
    public class SampleData : CreateDatabaseIfNotExists<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            var members = new List<Member>()
            {
                new Member(){UserName = "Admin",Password ="123456",NickName = "曾凡雨",Email = "258065584@qq.com"},
                new Member(){UserName = "zfy",Password ="123456",NickName = "曾凡雨",Email = "258065584@qq.com"}
            };
            DbSet<Member> memberSet = context.Set<Member>();
            members.ForEach(m => memberSet.Add(m));
            context.SaveChanges();          
        }
    }
}
