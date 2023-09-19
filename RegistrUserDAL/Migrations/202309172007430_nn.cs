namespace RegistrUserDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
          CreateTable(
          name: "ModulesS",
          c => new
          {
              Id = c.Guid(nullable: false, identity: true),
              Name = c.String(nullable: false)
          })
          .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("Modules");
        }
    }
}
