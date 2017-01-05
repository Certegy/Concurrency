using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    public class DatabaseConfiguration : System.Data.Entity.DbConfiguration
    {
        /// <summary>
        /// Disables DB Migration.  Without this EF will constantly query nonexistant __MigrationHistory table
        /// How does it get called? Follows namespace convention - must be in the same namespace as the Context class
        /// </summary>
        public DatabaseConfiguration()
        {
            SetDatabaseInitializer<DatabaseContext>(null);
        }
    }
}
