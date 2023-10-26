using Npgsql;
namespace TeenHackAPI.Data
{
    public class NumOfExercises
    {
        public static int ExercisesNum()
        {
            var cs = "Host=localhost;Username=postgres;Password=mityo1234;Database=teenhack";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT COUNT(*) FROM exercises;";

            using var cmd = new NpgsqlCommand(sql, con);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }
    }
}
