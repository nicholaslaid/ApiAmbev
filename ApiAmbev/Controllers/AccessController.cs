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
            Cripto cripto = new Cripto();
            try
            {
                string usuario = string.Empty;

                string senha = string.Empty;
                try
                {
                     usuario = cripto.DecryptTrypleDES(user);
                     senha = cripto.DecryptTrypleDES(password);
                    Log.Add(LogType.success, "descriptografado");
                }
                catch(Exception e)
                {
                    Log.Add(LogType.error, "Erro ao descriptografar");
                }
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
                {
                    string token = security.GenerateToken(usuario, senha);

                    if (!string.IsNullOrEmpty(token))
                    {
                        result.success = true;
                        result.data = cripto.EncryptTripleDES(token);
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
