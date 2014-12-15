using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using Admin.Demo.Core.Data.Configrations.Account;
using Admin.Demo.Core.Data.Configrations.security;
using Admin.Demo.Core.Models.Account;


namespace Admin.Demo.Core.Data.Context
{
    
        /// <summary>
        ///     Demo项目数据访问上下文
        /// </summary>      
        public class DemoDbContext : DbContext
        {
            #region 构造函数

            /// <summary>
            ///     初始化一个 使用连接名称为“default”的数据访问上下文类 的新实例
            /// </summary>
            public DemoDbContext()
                : base("default") { }

            /// <summary>
            /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
            /// </summary>
            public DemoDbContext(string nameOrConnectionString)
                : base(nameOrConnectionString) { }

            #endregion

            #region 属性

            public DbSet<Member> Members { get; set; }

         
 
            public DbSet<LoginLog> LoginLogs { get; set; }

            public DbSet<Asd> Asd { get; set; }

            #endregion

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new MemberConfiguraction());
                modelBuilder.Configurations.Add(new MemberExtendConfigraction());
                modelBuilder.Configurations.Add(new LoginLogConfiguration());
                modelBuilder.Configurations.Add(new MemberAddressConfiguration());
                modelBuilder.Configurations.Add(new RoleConfiguration());

                //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
                //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            }
        }
    }

