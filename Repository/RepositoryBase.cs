using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoService.Repository
{
    public class RepositoryBase<T> where T : new()
    {
        public static void Insert(object obj)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                try
                {
                    conn.Insert(obj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Update(object obj)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                try
                {
                    conn.Update(obj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Delete(object obj)
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                try
                {
                    conn.Delete(obj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static List<P> GetList<P>(Expression<Func<P, bool>> predicate) where P : new()
        {
            using (var conn = Framework.SQLiteConnection.Instance.GetConnection())
            {
                return conn.Table<P>().Where(predicate).ToList();
            }
        }
    }
}
