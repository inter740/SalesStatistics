namespace SalesStatistics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bestsellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        Cookies = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SimCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operator = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.SimCards");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Insurances");
            DropTable("dbo.Bestsellers");
            DropTable("dbo.Appliances");
        }
    }
}
