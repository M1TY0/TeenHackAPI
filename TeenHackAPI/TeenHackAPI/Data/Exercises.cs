using Npgsql;
namespace TeenHackAPI.Data
{
    public class Get
    {
        public static Models.Exercises[] GetExercises()
        {
            var cs = "Host=localhost;Username=postgres;Password=mityo1234;Database=teenhack";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            Models.Exercises[] exerciseArray = new Models.Exercises[NumOfExercises.ExercisesNum()];
            for (int i = 1; i <= exerciseArray.Length; i++)
            {
                Models.Exercises exercise = new Models.Exercises();
                using (var command = new NpgsqlCommand("SELECT * FROM exercises WHERE id = " + i, con))
                {
                    command.Parameters.AddWithValue("id", i);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exercise.id = reader.GetInt32(0);
                            exercise.name = reader.GetString(1);
                            exercise.description = reader.GetString(2);
                            exercise.videoLink = reader.GetString(3);
                            exercise.photoLink = reader.GetString(4);
                            exercise.partOfTheDay = (Models.PartOfTheDay)Enum.Parse(typeof(Models.PartOfTheDay), reader.GetString(5));
                            exercise.type = ((Models.Type)Enum.Parse(typeof(Models.Type), reader.GetString(6)));
                            exercise.purpose = ((Models.Purpose)Enum.Parse(typeof(Models.Purpose ), reader.GetString(7)));
                            exercise.moreinfo = reader.GetString(8);
                            exerciseArray[i-1] =exercise;
                        }
                    }
                }
            }
            return exerciseArray;
        }
    }
}