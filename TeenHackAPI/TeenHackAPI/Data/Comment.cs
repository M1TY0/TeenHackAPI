using System.Reflection.PortableExecutable;
using Npgsql;
namespace TeenHackAPI.Data
{
    public class Comment
    {
        public static List< Models.Comment> GetComment(int id_post)
        {

            var cs = File.ReadAllText(@"Connections\ConnectionString.txt");
            using var con = new NpgsqlConnection(cs);
            con.Open();
            List<Models.Comment> commentList = new List<Models.Comment>();
            for (int i = 1; i <= 10; i++)
            {
                Models.Comment comment = new Models.Comment();
                using (var command = new NpgsqlCommand("SELECT * FROM comments WHERE id = " + i, con))
                {
                    command.Parameters.AddWithValue("id", i);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            comment.id_creater = reader.GetInt32(0);
                            comment.id_post = reader.GetInt32(1);
                            comment.comment = reader.GetString(2);
                            comment.id = reader.GetInt32(4);
                            if (id_post == comment.id_post)
                            {
                                commentList.Add(comment);
                            }
                        }
                    }
                }
            }
            return commentList;
        }
    }
}
