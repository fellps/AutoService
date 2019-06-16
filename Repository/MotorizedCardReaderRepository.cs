using AutoService.Models;
using System;
using System.Collections.Generic;

namespace AutoService.Repository
{
    public class MotorizedCardReaderRepository : RepositoryBase<MotorizedCardReaderModel>
    {
        public static MotorizedCardReaderModel GetByIdMotorizedCardReader(Guid? idMotorizedCardReader)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                return conn.Table<MotorizedCardReaderModel>().Where(m => m.IdMotorizedCardReader == idMotorizedCardReader).FirstOrDefault();
            }
        }

        public static List<MotorizedCardReaderModel> GetAll()
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                return conn.Table<MotorizedCardReaderModel>().ToList();
            }
        }
    }
}
