using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;
namespace Admin.Demo.Core.Data.Repositories.Account
{
    /// <summary>
    ///   仓储操作层接口——用户信息
    /// </summary>
    public interface IMemberRepository : IRepository<Member, Int32>
    {

    }

}
