namespace Admin.Demo.Core.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hahaha = c.String(),
                        Abcddddd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IpAddress = c.String(nullable: false, maxLength: 15),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 32),
                        NickName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberExtends",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Tel = c.String(),
                        Province = c.String(maxLength: 10),
                        City = c.String(maxLength: 20),
                        County = c.String(maxLength: 20),
                        Street = c.String(maxLength: 60),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 100),
                        RoleTypeNum = c.Int(nullable: false),
                        RoleType = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleMembers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Member_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginLogs", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.RoleMembers", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.RoleMembers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.MemberExtends", "Id", "dbo.Members");
            DropIndex("dbo.RoleMembers", new[] { "Member_Id" });
            DropIndex("dbo.RoleMembers", new[] { "Role_Id" });
            DropIndex("dbo.MemberExtends", new[] { "Id" });
            DropIndex("dbo.LoginLogs", new[] { "Member_Id" });
            DropTable("dbo.RoleMembers");
            DropTable("dbo.Roles");
            DropTable("dbo.MemberExtends");
            DropTable("dbo.Members");
            DropTable("dbo.LoginLogs");
            DropTable("dbo.Asds");
        }
    }
}
