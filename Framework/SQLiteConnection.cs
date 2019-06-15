namespace AutoService.Framework
{
    public class SQLiteConnection
    {
        private static SQLiteConnection instance;
        private SQLite.SQLiteConnection connection;
        private SQLite.SQLiteAsyncConnection asyncConnection;
        private static readonly object thisLock = new object();

        public static SQLiteConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteConnection();
                }

                return instance;
            }
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            lock (thisLock)
            {
                if (instance.connection == null)
                {
                    SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create 
                        | SQLite.SQLiteOpenFlags.FullMutex | SQLite.SQLiteOpenFlags.SharedCache;
                    instance.connection = new SQLite.SQLiteConnection(Database.DbPath, flags);
                }

                return instance.connection;
            }
        }

        public SQLite.SQLiteAsyncConnection GetAsyncConnection()
        {
            lock (thisLock)
            {
                if (instance.asyncConnection == null)
                {
                    SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create 
                        | SQLite.SQLiteOpenFlags.FullMutex | SQLite.SQLiteOpenFlags.SharedCache;
                    instance.asyncConnection = new SQLite.SQLiteAsyncConnection(Database.DbPath, flags);
                }

                return instance.asyncConnection;
            }
        }
    }
}
