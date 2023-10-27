using Microsoft.AspNetCore.Mvc;

namespace TeenHackAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Exercises : Controller
    {
        [HttpGet]
        public Models.ExerciseResponse GetExercisesById()
        {

            var response = new Models.ExerciseResponse
            {
                result = Data.Get.GetExercises()
            };
            return response;

        }
    }
    [ApiController]
    [Route("[controller]")]
    public class Users : Controller
    {
        [HttpGet]
        public Models.User GetUserById(int id)
        {
            return Data.User.GetUserById(id);
        }
}

}
