namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ContacName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Reservations", "Phone", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Phone", c => c.String());
            AlterColumn("dbo.Reservations", "ContacName", c => c.String(nullable: false));
        }
    }
}
