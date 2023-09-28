using ApiAmbev.Global;
using ApiAmbev.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAmbev.Controllers
{
    [Route("api/Ambev")]
    [ApiController]
    public class AmbevController : ControllerBase
    {

        [HttpGet]
        [Route("Handshake")]

        public JsonResult Handshake()
        {
            Result result = new Result();
            bool resultado = result.success = true;

            return new JsonResult(resultado);
        }

        [HttpGet]
        [Route("AccessTest")]

        public JsonResult AccessTest(string token)
        {
            Result result = new Result();
            Security security = new Security();

            try
            {
                bool resultado = security.ValidateToken(token);

                if (resultado)
                {
                    result.success = true;
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