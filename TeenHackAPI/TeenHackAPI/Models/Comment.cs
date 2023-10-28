namespace TeenHackAPI.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int id_creater { get; set; }
        public int id_post { get; set; }
        public string comment { get; set; }

    }
}
