using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //"ControllerBase" gives your controller useful methods and properties for
        //handling HTTP requests and generating HTTP responses.
        // Ex: Ok(data),Unauthorized(), so we can return like "return OK(data)" from our
        // controller action methods 

        //"IActionResult" return type can support different type of htp responses like 
        //Ok(employee), NotFound() and we can't return like that if we just use Employee as return type

       
    }
}
