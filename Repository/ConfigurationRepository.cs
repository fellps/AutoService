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
                Guid idConfiguration = Guid.Empty;
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
