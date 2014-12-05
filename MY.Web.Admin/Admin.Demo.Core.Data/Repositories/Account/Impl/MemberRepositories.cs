using System;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Repositories.Account.Impl
{
    public class MemberRepositories:EfRepositoryBase<Member,Int32>,IMemberRepository
    {
    }
}
