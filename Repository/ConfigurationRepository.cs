using AutoService.Models;
using System;

namespace AutoService.Repository
{
    public class ConfigurationRepository : RepositoryBase<ConfigurationModel>
    {
        public static ConfigurationModel GetByIdConfiguration(Guid idConfiguration)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                return conn.Table<ConfigurationModel>().Where(c => c.IdConfiguration == idConfiguration).FirstOrDefault();
            }
        }

        public static ConfigurationModel GetConfiguration()
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                Guid idConfiguration = Guid.Parse("fe0fd1c8-a760-41dd-8b7d-8916b1337bc8");
                return conn.Table<ConfigurationModel>().Where(c => c.IdConfiguration == idConfiguration).FirstOrDefault();
            }
        }

        public static void InsertOrUpdate(ConfigurationModel configurationModel)
        {
            if (GetByIdConfiguration(configurationModel.IdConfiguration) == null)
                Insert(configurationModel);
            else
                Update(configurationModel);
        }
    }
}
