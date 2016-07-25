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
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ContacName = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(maxLength: 12),
                        BirthDay = c.DateTime(nullable: false),
                        Text = c.String(),
                        Ranking = c.Int(),
                        IsFavourite = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .Index(t => t.ContactTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Reservations", new[] { "ContactTypeId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.ContactTypes");
        }
    }
}
