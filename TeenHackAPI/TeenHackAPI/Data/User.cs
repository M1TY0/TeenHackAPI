using Npgsql;

namespace TeenHackAPI.Data
{
    public class User
    {
        public string CreateUsername()
        {
            return "200";
        }
        public static Models.User GetUserById(int id)
        {

            var cs = "Host=localhost;Username=postgres;Password=mityo1234;Database=teenhack";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            Models.User user = new Models.User();

            using (var command = new NpgsqlCommand("SELECT * FROM users WHERE id = " + id, con))
            {
                command.Parameters.AddWithValue("id", id);
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        user.id = reader.GetInt32(0);
                        user.firstname = reader.GetString(1);
                        user.lastname = reader.GetString(2);
                        user.password = reader.GetString(3);
                        user.email = reader.GetString(4);
                        user.weight = reader.GetInt32(5);
                        user.height = reader.GetDouble(6);
                        user.dateofregistration = reader.GetDateTime(7);
                        user.dateofbirth = reader.GetDateTime(8);
                    }

                }
            }
            return user;
        }
    }
}
