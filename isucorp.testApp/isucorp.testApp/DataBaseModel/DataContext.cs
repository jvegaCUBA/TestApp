namespace isucorp.testApp.DataBaseModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        // Your context has been configured to use a 'test_db' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'isucorp.testApp.DataBaseModel.test_db' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'test_db' 
        // connection string in the application configuration file.
        public DataContext()
            : base("name=test_db")
        {
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ContactType>().MapToStoredProcedures(s =>
                {
                    s.Insert(i => i.HasName("ContactTypeInsert"));
                    s.Update(u => u.HasName("ContactTypeUpdate"));
                    s.Delete(d => d.HasName("ContactTypeDelete"));
                });
            modelBuilder.Entity<Reservation>().MapToStoredProcedures(s =>
                {
                    s.Insert(i => i.HasName("ReservationInsert"));
                    s.Update(u => u.HasName("ReservationUpdate"));
                    s.Delete(d => d.HasName("ReservationDelete"));
                });

            //modelBuilder.Entity<ContactType>().MapToStoredProcedures();
            //modelBuilder.Entity<Reservation>().MapToStoredProcedures();
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

        }
    }
}