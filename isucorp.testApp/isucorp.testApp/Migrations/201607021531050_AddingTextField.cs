namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTextField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Text");
        }
    }
}
