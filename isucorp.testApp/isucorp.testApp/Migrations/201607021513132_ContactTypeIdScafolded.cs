namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactTypeIdScafolded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reservations", name: "ContactType_Id", newName: "ContactTypeId");
            RenameIndex(table: "dbo.Reservations", name: "IX_ContactType_Id", newName: "IX_ContactTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reservations", name: "IX_ContactTypeId", newName: "IX_ContactType_Id");
            RenameColumn(table: "dbo.Reservations", name: "ContactTypeId", newName: "ContactType_Id");
        }
    }
}
