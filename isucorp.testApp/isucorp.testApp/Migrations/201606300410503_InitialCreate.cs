namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContacName = c.String(),
                        Phone = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        ContactType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactType_Id)
                .Index(t => t.ContactType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ContactType_Id", "dbo.ContactTypes");
            DropIndex("dbo.Reservations", new[] { "ContactType_Id" });
            DropTable("dbo.Reservations");
            DropTable("dbo.ContactTypes");
        }
    }
}
