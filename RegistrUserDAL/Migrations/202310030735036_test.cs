namespace RegistrUserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        EditMode = c.Int(nullable: false),
                        ModuleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        MidleName = c.String(),
                        FirsName = c.String(),
                        Birtchday = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Photo = c.Binary(),
                        Gender = c.Int(nullable: false),
                        Blocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Permissions", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Permissions", new[] { "ModuleId" });
            DropIndex("dbo.Permissions", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
            DropTable("dbo.Modules");
        }
    }
}
