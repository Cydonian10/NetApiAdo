using App_Tareas.Util;
using App_Tareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;

namespace App_Tareas.Controllers
{
    [ApiController]
    [Route("api")]
    public class TareasController : ControllerBase
    {
        private readonly IDBDatos _dbDatos;

        public TareasController(IDBDatos dbDatos)
        {
            _dbDatos = dbDatos;
        }

        [HttpGet(Name = "GetTareas")]
        public dynamic GetTareas()
        {

            // DataTable tTareas = DBDatos.ListarTabla("sp_ListaTareas");
            DataTable tTareas = _dbDatos.ListarTabla("sp_ListaTareas");

            string jsonTareas = JsonConvert.SerializeObject(tTareas);

            return new
            {
                success = true,
                message = "exito retundo",
                resul = new
                {
                    producto = JsonConvert.DeserializeObject<List<Tarea>>(jsonTareas),
                }
            };

        }
    }
}