using Backend.Helpers.Currency;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCurrency()
        {
            try
            {
                var currencyManager = new CurrencyManager();
                var currency = currencyManager.GetCurrencyActive();
                if (currency.Count > 0)
                {
                    var data = new CoreResponse { Result = 1, Message = "Ok", Data = currency };
                    return Ok(data);
                }
                else
                {
                    var data = new CoreResponse { Result = 1, Message = "No se encontraron monedas activas", Data = null };
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno de la aplicacion");
            }
        }
    }
}
