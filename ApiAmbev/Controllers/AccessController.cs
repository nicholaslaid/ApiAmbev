using ApiAmbev.Global;
using ApiAmbev.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAmbev.Controllers
{

    [ApiController]
    [Route("api/Ambev")]
    public class AccessController : Controller
    {
        [HttpGet]
        [Route("GetToken")]

        public JsonResult GetToken(string user, string password)
        {
            Security security = new Security();
            Result result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                {
                    string token = security.GenerateToken(user, password);

                    if (!string.IsNullOrEmpty(token))
                    {
                        result.success = true;
                        result.data = token;
                    }
                    else
                    {
                        result.success = false;
                    }

                }
                else
                {
                    result.success = false;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
            }
            return new JsonResult(result);
        }
    }
}
