using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Common;
using GameProtocol;

namespace Server.Manager
{
    public static class DatabaseManager
    {
        private static GameDbContext _context;

        public static void Start()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"localhost\SQLEXPRESS";
                builder.UserID = "sa";
                builder.Password = "123456";
                builder.InitialCatalog = "GameDB";

                _context = new GameDbContext(builder.ConnectionString);

            }
            catch (Exception e)
            {
                Log.Write(e, typeof(DatabaseManager));
            }
        }

        public static void Register(string account, string password)
        {
            var query = _context.Logins.FirstOrDefault(i => i.Account.Equals(account));
            if (query == null)
            {
                Log.Write("加入用户" + account, typeof(DatabaseManager));
                var login = new Login { Account = account, Password = password };
                _context.Logins.Add(login);
                _context.SaveChanges();
            }
            else
            {
                Log.Write("已存在用户名" + account, typeof(DatabaseManager));
            }
        }

        public static NotifyLogin.Types.ResultType Login(string account, string password)
        {
            var query = from t in _context.Logins
                where t.Account.Equals(account)
                select t;
            int count = query.Count();
            if (count == 0)
            {
                Log.Write("不存在此用户" + account, typeof(DatabaseManager));
            }
            else if (count == 1)
            {
                Log.Write("验证用户密码", typeof(DatabaseManager));
                var login = query.First();
                if (login.Password == password)
                {
                    Log.Write("密码验证成功", typeof(DatabaseManager));
                    return NotifyLogin.Types.ResultType.Success;
                }
                Log.Write("密码验证失败", typeof(DatabaseManager));
                return NotifyLogin.Types.ResultType.IncorrectPassword;
            }
            else
            {
                Log.Error("", typeof(DatabaseManager));
            }
            return NotifyLogin.Types.ResultType.Unkonw;
        }
    }

    class GameDbContext : DbContext
    {
        public GameDbContext(string connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GameDbContext>());
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Login> Logins { get; set; }
    }

    public class Login
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}