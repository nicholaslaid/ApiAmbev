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
            result.success = true;
             result.data = "true";



            return new JsonResult(result);
        }

        [HttpGet]
        [Route("AccessTest")]

        public JsonResult AccessTest(string token)
        {
            Result result = new Result();
            Security security = new Security();
            Cripto cripto = new Cripto();

            try
            {
                string tk = string.Empty;
                try
                {

                    tk = cripto.DecryptTrypleDES(token);
                    Log.Add(LogType.success, "descriptografado");
                }
                catch(Exception e)
                {
                    Log.Add(LogType.error, "Erro ao descriptografar");
                }
                bool resultado = security.ValidateToken(tk);

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