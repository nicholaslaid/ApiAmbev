using ApiAmbev.DataBase;
using ApiAmbev.Global;
using ApiAmbev.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ApiAmbev.Global.Config;

namespace ApiAmbev.Controllers
{
    [ApiController]
    [Route("api/Ambev")]
    public class VendasController : Controller
    {
        [HttpGet]
        [Route("ListaVendas")]

        public JsonResult ListaVendas(string token)
        {
            Result result = new Result();
            Security security = new Security();
            Methods methods = new Methods();
            Cripto cripto = new Cripto();

            try
            {
                token = token.Replace(" ", "+");
                string tk = cripto.DecryptTrypleDES(token);
                if (security.ValidateToken(tk))
                {
                    List<Vendas> vendas = new List<Vendas>();
                    vendas = methods.GetAllVendas();

                    if (vendas.Count > 0)
                    {
                        result.success = true;

                        result.data = cripto.EncryptTripleDES(JsonConvert.SerializeObject(vendas));
                        result.errorCode = Convert.ToInt32(ErrorCode.NoError);
                        result.errorMessage = ErrorCode.NoError.ToString() + "ListaVendas feito com successo";
                        Log.Add(LogType.success, "ListaVendas Realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                        result.errorMessage = ErrorCode.ProductGetError.ToString() + "ListaVendas Não foi realizado";
                        Log.Add(LogType.error, "ListaVendas Não foi realizado");
                    }
                }
                else
                {
                    result.success = false;
                    result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                    result.errorMessage = ErrorCode.ProductGetError.ToString() + "Token invalido";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                result.errorMessage = ErrorCode.ProductGetError.ToString() + " - " + ex.Message;

            }
            return new JsonResult(result);

        }

        [HttpGet]
        [Route("ListaProdutos")]

        public JsonResult ListaProdutos(string token)
        {
            Result result = new Result();
            Security security = new Security();
            Methods methods = new Methods();
            Cripto cripto = new Cripto();

            try
            {
                token = token.Replace(" ", "+");
                string tk = cripto.DecryptTrypleDES(token);
                if (security.ValidateToken(tk))
                {
                    List<info> Info = new List<info>();
                    Info = methods.VendasProdutos();

                    if (Info.Count > 0)
                    {
                        result.success = true;

                        result.data = cripto.EncryptTripleDES(JsonConvert.SerializeObject(Info));
                        result.errorCode = Convert.ToInt32(ErrorCode.NoError);
                        result.errorMessage = ErrorCode.NoError.ToString() + "Info feito com successo";
                        Log.Add(LogType.success, "Info Realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                        result.errorMessage = ErrorCode.ProductGetError.ToString() + "Info Não foi realizado";
                        Log.Add(LogType.error, "Info Não foi realizado");
                    }
                }
                else
                {
                    result.success = false;
                    result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                    result.errorMessage = ErrorCode.ProductGetError.ToString() + "Token invalido";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                result.errorMessage = ErrorCode.ProductGetError.ToString() + " - " + ex.Message;

            }
            return new JsonResult(result);

        }


    }
}
