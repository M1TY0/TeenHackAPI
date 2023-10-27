namespace TeenHackAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int weight { get; set; }
        public double height { get; set; }
        public DateTime dateofbirth { get; set; }
        public DateTime dateofregistration { get; set; }
    }
}