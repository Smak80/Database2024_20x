using MySqlConnector;

namespace Database2024
{
    public static class DbHelper
    {
        private static readonly string ConnStr = "Server=localhost;DataBase=2k2024;port=3306;User Id=root;password=";
        private static readonly MySqlConnection Conn = new(ConnStr);

        static DbHelper()
        {
            Conn.Open();
        }

        public static long AddUser(User u)
        {
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `full_users` (name, age, position, salary) VALUES (@n, @a, @p, @s)";
                cmd.Parameters.Add(new MySqlParameter("@n", u.Name));
                cmd.Parameters.Add(new MySqlParameter("@a", u.Age));
                cmd.Parameters.Add(new MySqlParameter("@p", u.Position));
                cmd.Parameters.Add(new MySqlParameter("@s", u.Salary));
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch
            {
                return -1;
            }
        }

        public static IEnumerable<User> LoadAll()
        {
            List<User> users = new ();
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM `full_users`";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Name = reader.GetString("name"),
                                Age = reader.GetUInt32("age"),
                                Position = reader.GetString("position"),
                                Salary = reader.GetFloat("salary")
                            });
                        }
                    }
                }
            }
            catch
            {
            }
            return users;
        }
    }
}
