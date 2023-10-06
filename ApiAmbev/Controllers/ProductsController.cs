using Microsoft.AspNetCore.Mvc;
using ApiAmbev.Models;
using ApiAmbev.Global;
using ApiAmbev.DataBase;
using Newtonsoft.Json;
using static ApiAmbev.Global.Config;
using Microsoft.Extensions.Primitives;

namespace ApiAmbev.Controllers
{
    [ApiController]
    [Route("api/Ambev")]

    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("GetAll")]

        public JsonResult GetAll(string token)
        {
            Result result = new Result();
            Security security = new Security();
            Methods methods = new Methods();
            Cripto cripto = new Cripto();

            try
            {
                if (security.ValidateToken(token))
                {
                    List<Products> produtos = new List<Products>();
                    produtos = methods.GetAll();

                    if (produtos.Count > 0)
                    {
                        result.success = true;
                       
                        result.data = cripto.EncryptTripleDES(JsonConvert.SerializeObject(produtos));
                        
                        Log.Add(LogType.success, "GetAll Realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                        result.errorMessage = ErrorCode.JobNotFoundError.ToString();
                        Log.Add(LogType.error, "GetAll Não foi realizado");
                    }
               }
               else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
               
            }
            return new JsonResult(result);
        }
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(string desktop_data)
        {
            Security security = new Security();
            Result result = new Result();
            Methods methods = new Methods();
            Cripto cripto = new Cripto();

            desktop_data = cripto.DecryptTrypleDES(desktop_data);

            Request request = JsonConvert.DeserializeObject<Request>(desktop_data);


            try
            {
                if (security.ValidateToken(request.token))
                {
                    request.produtos.id = methods.GetAll().Count + 1;

                    try
                    {

                    }
                    catch (Exception e)
                    {

                    }

                    bool a = methods.Add(request.produtos);

                    if (a)
                    {
                        result.success = true;
                        Log.Add(LogType.success, "Add realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        Log.Add(LogType.error, "Add não foi realizado");
                    }
               }
               else
                {
                   result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
               }

            }

            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
               
            }
            return new JsonResult(result);
        }
        [HttpDelete]
        [Route("Delete")]

        public JsonResult Delete(string token, int id)
        {
            Security security = new Security();
            Methods methods = new Methods();
            Result result = new Result();
            try
            {
                if (security.ValidateToken(token))
                {
                    bool a = methods.Delete(id);
                    if (a)
                    {
                        Log.Add(LogType.success, "Delete realizado com successo");
                        result.success = true;

                    }
                    else
                    {
                        result.success = false;
                        Log.Add(LogType.error, "Delete não foi realizado");
                    }
                }
                else
               {
                  result.success = false;
                  result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }
            }

            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
                Log.Add(LogType.error, "Delete não foi realizado");
            }
            return new JsonResult(result);
        }
            
        }
    }



