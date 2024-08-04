using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]

        /*[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]*/

        //[ModelBinder(binderType: typeof(PersonModelBinder))]
        public IActionResult Index(Person person, [FromHeader(Name ="User-Agent")] string UserAgent)
        {
            if (ModelState.IsValid == false)                      //checks if any validation of model class is false (mpdel state checks the status of the validation)
            {
                //List<string> errorList=new List<string>();
                //foreach(var value in ModelState.Values)     //iterating through each property of Person class
                //{
                //    foreach(var error in value.Errors)      //iterating through each error of a property
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorList);


                                  //OR 

                //using LINQ
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }
            return Content($"{person}, {UserAgent}");
        }
    }
}
