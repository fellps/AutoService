using AutoService.Models;
using System;

namespace AutoService.Repository
{
    public class ConfigurationRepository : RepositoryBase<ConfigurationModel>
    {
        public static ConfigurationModel GetByIdConfiguration(Guid IdConfiguration)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                return conn.Table<ConfigurationModel>().Where(c => c.IdConfiguration == IdConfiguration).FirstOrDefault();
            }
        }
    }
}
