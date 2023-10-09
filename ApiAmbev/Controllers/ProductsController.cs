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
                        result.errorCode = Convert.ToInt32(ErrorCode.NoError);
                        result.errorMessage = ErrorCode.NoError.ToString() + "Get all feito com successo";
                        Log.Add(LogType.success, "GetAll Realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.ProductGetError);
                        result.errorMessage = ErrorCode.ProductGetError.ToString() + "GetAll Não foi realizado";
                        Log.Add(LogType.error, "GetAll Não foi realizado");
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
                        result.errorMessage = ErrorCode.NoError.ToString() + "Produto adicionado com successo";
                        result.errorCode = Convert.ToInt32(ErrorCode.NoError);
                        Log.Add(LogType.success, "Add realizado com successo");
                    }
                    else
                    {
                        result.success = false;
                        result.errorMessage = ErrorCode.ProductAddError.ToString() + " - " + "Não foi possivel adicionar este produto";
                        result.errorCode = Convert.ToInt32(ErrorCode.ProductAddError);
                        Log.Add(LogType.error, "Add não foi realizado");
                    }
               }
               else
                {
                   result.success = false;
                    result.errorMessage = ErrorCode.ProductAddError.ToString() + " - " + "Token invalido";
                    result.errorCode = Convert.ToInt32(ErrorCode.ProductAddError);
                }

            }

            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.ProductAddError);
                result.errorMessage = ErrorCode.ProductAddError.ToString() + " - " + ex.Message;
               
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
                        result.success = true;
                        result.errorMessage = ErrorCode.NoError.ToString() + " - " + "Delete realizado com successo";
                        result.errorCode = Convert.ToInt32(ErrorCode.NoError);
                        Log.Add(LogType.success, "Delete realizado com successo");
                       

                    }
                    else
                    {
                        result.success = false;
                        result.errorMessage = ErrorCode.ProductDeleteError.ToString() + " - " + "Delete não foi realizado";
                        result.errorCode = Convert.ToInt32(ErrorCode.ProductDeleteError);
                        Log.Add(LogType.error, "Delete não foi realizado");
                    }
                }
                else
               {
                  result.success = false;
                  result.errorMessage = ErrorCode.ProductDeleteError.ToString() + " - " + "Token invalido";
                    result.errorCode = Convert.ToInt32(ErrorCode.ProductDeleteError);
                }
            }

            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.ProductDeleteError);
                result.errorMessage = ErrorCode.ProductDeleteError.ToString() + " - " + ex.Message;
                Log.Add(LogType.error, "Delete não foi realizado");
            }
            return new JsonResult(result);
        }
            
        }
    }



