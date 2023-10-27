using Microsoft.AspNetCore.Http;
using Npgsql;
using System.Net;
using TeenHackAPI.Models;
namespace TeenHackAPI.Data
{
    public class User
    {
        public static HttpStatusCode CreateUser(string firstname, string lastname, string email, string password, int weight, int height, DateTime dateofbirth, DateTime dateofregistration)
        {
            var cs = "Host=localhost;Username=postgres;Password=mityo1234;Database=teenhack";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            try
            {
                var sql = "INSERT INTO users(firstname,lastname,email,password,weight,height,dateofbirth,dateofregistration) VALUES('" + firstname + "','" + lastname + "','" + email + "','" + password + "'," + weight + "," + height + ",'" + dateofbirth + "','" + dateofregistration + "');";
                using var cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteScalar();
                return HttpStatusCode.Created;
            }
            catch
            {
                return HttpStatusCode.UnprocessableEntity;
            }
        }
        public static Models.Result getIdOrError(string email, string password)
        {
            var cs = "Host=localhost;Username=postgres;Password=mityo1234;Database=teenhack";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            Models.User user = new Models.User();
            try
            {
                using (var command = new NpgsqlCommand("SELECT * FROM users WHERE email = '" + email + "';", con))
                {
                    command.Parameters.AddWithValue("email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.id = reader.GetInt32(8);
                            user.password = reader.GetString(2);
                            user.email = reader.GetString(3);
                        }
                    }
                }
                if (user.password == password)
                {
                    return new Result { Id = user.id, StatusCode = HttpStatusCode.Accepted };
                }
                else
                {
                    return new Result { StatusCode = HttpStatusCode.Forbidden };
                }
            }
            catch
            {
                return new Result { StatusCode = HttpStatusCode.UnprocessableEntity };
            }
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
                        user.firstname = reader.GetString(0);
                        user.lastname = reader.GetString(1);
                        user.password = reader.GetString(2);
                        user.email = reader.GetString(3);
                        user.weight = reader.GetInt32(4);
                        user.height = reader.GetDouble(5);
                        user.dateofregistration = reader.GetDateTime(6);
                        user.dateofbirth = reader.GetDateTime(7);
                        user.id = reader.GetInt32(8);
                    }
                }
                return user;
            }
        }
    }
}
