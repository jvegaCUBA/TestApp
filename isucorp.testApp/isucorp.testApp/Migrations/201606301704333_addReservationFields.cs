namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReservationFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Ranking", c => c.Int());
            AddColumn("dbo.Reservations", "IsFavourite", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "IsFavourite");
            DropColumn("dbo.Reservations", "Ranking");
        }
    }
}
