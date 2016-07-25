namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStoredProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.ContactTypeInsert",
                p => new
                    {
                        Name = p.String(),
                    },
                body:
                    @"INSERT [dbo].[ContactTypes]([Name])
                      VALUES (@Name)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[ContactTypes]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[ContactTypes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ContactTypeUpdate",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[ContactTypes]
                      SET [Name] = @Name
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ContactTypeDelete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ContactTypes]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ReservationInsert",
                p => new
                    {
                        ContacName = p.String(maxLength: 30),
                        Phone = p.String(maxLength: 12),
                        BirthDay = p.DateTime(),
                        Text = p.String(),
                        Ranking = p.Int(),
                        IsFavourite = p.Boolean(),
                        CreatedDate = p.DateTime(),
                        ModifiedDate = p.DateTime(),
                        ContactTypeId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Reservations]([ContacName], [Phone], [BirthDay], [Text], [Ranking], [IsFavourite], [CreatedDate], [ModifiedDate], [ContactTypeId])
                      VALUES (@ContacName, @Phone, @BirthDay, @Text, @Ranking, @IsFavourite, @CreatedDate, @ModifiedDate, @ContactTypeId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Reservations]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id], t0.[RowVersion]
                      FROM [dbo].[Reservations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ReservationUpdate",
                p => new
                    {
                        Id = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        ContacName = p.String(maxLength: 30),
                        Phone = p.String(maxLength: 12),
                        BirthDay = p.DateTime(),
                        Text = p.String(),
                        Ranking = p.Int(),
                        IsFavourite = p.Boolean(),
                        CreatedDate = p.DateTime(),
                        ModifiedDate = p.DateTime(),
                        ContactTypeId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Reservations]
                      SET [ContacName] = @ContacName, [Phone] = @Phone, [BirthDay] = @BirthDay, [Text] = @Text, [Ranking] = @Ranking, [IsFavourite] = @IsFavourite, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate, [ContactTypeId] = @ContactTypeId
                      WHERE (([Id] = @Id) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [dbo].[Reservations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ReservationDelete",
                p => new
                    {
                        Id = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Reservations]
                      WHERE (([Id] = @Id) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.ReservationDelete");
            DropStoredProcedure("dbo.ReservationUpdate");
            DropStoredProcedure("dbo.ReservationInsert");
            DropStoredProcedure("dbo.ContactTypeDelete");
            DropStoredProcedure("dbo.ContactTypeUpdate");
            DropStoredProcedure("dbo.ContactTypeInsert");
        }
    }
}
