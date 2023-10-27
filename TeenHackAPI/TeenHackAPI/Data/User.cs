﻿using Microsoft.AspNetCore.Http;
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
            var sql = "INSERT INTO users(firstname,lastname,email,password,weight,height,dateofbirth,dateofregistration) VALUES('" + firstname + "','" + lastname + "','" + email + "','" + password + "'," + weight + "," + height + ",'" + dateofbirth + "','" + dateofregistration + "');";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteScalar();
            return HttpStatusCode.Created;

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
                    command.Parameters.AddWithValue("email",email );
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            user.id = reader.GetInt32(0);
                            user.password = reader.GetString(3);
                            user.email = reader.GetString(4);
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