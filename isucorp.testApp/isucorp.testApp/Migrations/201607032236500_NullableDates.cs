namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ModifiedDate");
        }
    }
}
