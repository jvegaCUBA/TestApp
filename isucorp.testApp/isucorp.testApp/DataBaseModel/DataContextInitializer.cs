using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.DataBaseModel
{
    using System.Data.Entity;

    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var contactTypeList = new List<ContactType>()
                                      {
                                          new ContactType {Name = "Contact1"},
                                          new ContactType {Name = "Contact2"},
                                          new ContactType {Name = "Contact3"},
                                          new ContactType {Name = "Contact4"},
                                      };
            contactTypeList.ForEach(m => context.ContactTypes.Add(m));
            context.SaveChangesAsync();
        }
    }
}
