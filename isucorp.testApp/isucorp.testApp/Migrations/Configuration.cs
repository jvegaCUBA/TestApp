namespace isucorp.testApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using isucorp.testApp.DataBaseModel;

    internal sealed class Configuration : DbMigrationsConfiguration<isucorp.testApp.DataBaseModel.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(isucorp.testApp.DataBaseModel.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.ContactTypes.AddOrUpdate(
              p => p.Name, 
              new ContactType() { Name = "Type 1" },
              new ContactType() { Name = "Type 2" },
              new ContactType() { Name = "Type 3" }
            );

        }
    }
}
