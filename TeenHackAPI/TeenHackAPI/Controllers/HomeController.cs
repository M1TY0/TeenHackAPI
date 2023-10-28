using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    public class GetMeditations : Controller
    {
        [HttpGet]
        public Models.ExerciseResponseMed GetExerciseByPurpose(Models.Purpose purpose,int id)
        {
            var response = new Models.ExerciseResponseMed
            {
                result = Data.Get.GetExercisesByPurpose(purpose,id)
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
        [HttpPost]
        public HttpStatusCode CreateNewUser(string firstname, string lastname, string email, string password, int weight, int height, DateTime dateofbirth, DateTime dateofregistration)
        {
            return Data.User.CreateUser(firstname, lastname, email, password, weight, height, dateofbirth, dateofregistration);
        }
        
    }
   
        [ApiController]
    [Route("[controller]")]
    public class Checking : Controller
    {
        [HttpPost]
        public Models.Result GetUserIdByEmailAndPassword(string email, string password)
        {
            return Data.User.getIdOrError(email, password);
        }
    }
}
