namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "CreatedDate");
        }
    }
}
