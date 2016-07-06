namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "ContactType_Id", "dbo.ContactTypes");
            DropIndex("dbo.Reservations", new[] { "ContactType_Id" });
            AlterColumn("dbo.Reservations", "ContacName", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "ContactType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ContactType_Id");
            AddForeignKey("dbo.Reservations", "ContactType_Id", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ContactType_Id", "dbo.ContactTypes");
            DropIndex("dbo.Reservations", new[] { "ContactType_Id" });
            AlterColumn("dbo.Reservations", "ContactType_Id", c => c.Int());
            AlterColumn("dbo.Reservations", "ContacName", c => c.String());
            CreateIndex("dbo.Reservations", "ContactType_Id");
            AddForeignKey("dbo.Reservations", "ContactType_Id", "dbo.ContactTypes", "Id");
        }
    }
}
