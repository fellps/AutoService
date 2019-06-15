using AutoService.DAL;
using System;
using System.IO;

namespace AutoService.Framework
{
    public class Database
    {
        public static string DbName { get; private set; } = DbName = "autoservice.db";
        public static string DbPath { get; private set; } = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), DbName);

        public static void CreateDatabase()
        {
            using (var conn = SQLiteConnection.Instance.GetConnection())
            {
                conn.CreateTable<Configuration>();
            }
        }
    }
}
