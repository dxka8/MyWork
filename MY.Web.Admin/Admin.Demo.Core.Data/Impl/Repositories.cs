using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Data.Repositories.Account;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Impl
{
    /// <summary>
    ///     仓储操作实现——用户信息
    /// </summary>
    [Export(typeof(IMemberRepository))]
    public class MemberRepository : EfRepositoryBase<Member,int>, IMemberRepository { }
}
