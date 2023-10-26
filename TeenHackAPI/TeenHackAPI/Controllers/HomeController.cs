using Microsoft.AspNetCore.Mvc;

namespace TeenHackAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
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
}
