using Backend.Helpers.BranchOffices;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/branch_offices")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        /// <summary>
        /// Obtiene todas las sucursales que han sido creadas
        /// </summary>
        /// <returns></returns>
        [Route("all")]
        [HttpGet]
        public IActionResult GetAllSu()
        {
            try
            {
                var branchOfficeManager = new BranchOfficesManager();
                var branchOffice = branchOfficeManager.GetAllBranchOffices();
                if (branchOffice.Count > 0)
                {
                    var data = new CoreResponse { Result = 1, Message = "Ok", Data = branchOffice };
                    return Ok(data);
                }
                else
                {
                    var data = new CoreResponse { Result = 1, Message = "No se encontraron sucursales creadas" };
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno de la aplicacion");
            }
        }

        /// <summary>
        /// Agrega sucursales de quala
        /// </summary>
        /// <returns></returns>
        [Route("add")]
        [HttpPost]
        public IActionResult AddBranchOffices(DataBranchOffices branchOffice)
        {
            try
            {
                var branchOfficeManager = new BranchOfficesManager();
                var message = branchOfficeManager.CreateBranchOfficeManager(branchOffice);
                if (message.Equals("Ok"))
                {
                    var data = new CoreResponse { Result = 1, Message = "Surcursal creada exitosamente" };
                    return Ok(data);
                }
                else
                {
                    var data = new CoreResponse { Result = 2, Message = message };
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno de la aplicacion");
            }
        }

        /// <summary>
        /// Actualiza la informacion de una sucursal
        /// </summary>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateBranchOffices(DataBranchOffices branchOffice)
        {
            try
            {
                var branchOfficeManager = new BranchOfficesManager();
                var status = branchOfficeManager.UpdateOfficeManager(branchOffice);
                if (status)
                {
                    var response = new CoreResponse { Result = 1, Message = "Ok" };
                    return Ok(response);
                }
                else
                {
                    var response = new CoreResponse { Result = 2, Message = "No se pudo eliminar la sucursal" };
                    return Ok(response);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno de la aplicacion");
            }
        }

        /// <summary>
        /// Elimina sucursales
        /// </summary>
        /// <returns></returns>
        [Route("delete")]
        [HttpGet]
        public IActionResult DeleteBranchOffices(int id)
        {
            try
            {
                var branchOfficeManager = new BranchOfficesManager();
                var status = branchOfficeManager.DeleteOfficeManager(id);
                if (status)
                {
                    var response = new CoreResponse { Result = 1, Message = "Ok" };
                    return Ok(response);
                }
                else
                {
                    var response = new CoreResponse { Result = 2, Message = "No se pudo eliminar la sucursal" };
                    return Ok(response);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno de la aplicacion");
            }
        }
    }
}
