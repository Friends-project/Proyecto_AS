using API.Entidades;
using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Carrera")]
    public class CarreraController : ApiController
    {
        object carreraList;
        CarreraLogic carreraLogic = new CarreraLogic();
        string message;

        // GET: api/Carrera/GetCarreras
        [HttpGet]
        [Route("GetCarreras")]
        public object GetCarreras()
        {
            carreraList = null;
            if (carreraLogic.ObtenerCarreras().MyObj == null)
            {
                return carreraLogic.ObtenerCarreras().Message;
            }
            else
            {
                carreraList = carreraLogic.ObtenerCarreras().MyObj;
                return carreraList;
            }
        }

        // GET: api/Carrera/GetCarrera/{id}
        [HttpGet]
        [Route("GetCarrera")]
        public object GetCarrera(int id)
        {
            object carrera = new Carrera();
            if (carreraLogic.ObtenerCarreraPorId(id).MyObj == null)
            {
                return carreraLogic.ObtenerCarreraPorId(id).Message;
            }
            else
            {
                carrera = carreraLogic.ObtenerCarreraPorId(id).MyObj;
                return carrera;
            }
        }

        // POST: api/Carrera/AgregarCarrera
        [HttpPost]
        [Route("AgregarCarrera")]
        public string PostCarrera(Carrera carrera)
        {
            message = null;
            message = carreraLogic.AgregarCarrera(carrera).Message;

            return message;
        }

        // PUT: api/Carrera/PutCarrera/{id}
        [HttpPut]
        [Route("ModificarCarrera")]
        public string PutCarrera(Carrera user, int id)
        {
            message = null;
            message = carreraLogic.ModificarCarrera(user, id).Message;

            return message;
        }

        // DELETE: api/Carrera/DeleteCarrera/{id}
        [HttpDelete]
        [Route("EliminarCarrera")]
        public string DeleteCarrera(int id)
        {
            message = null;
            message = carreraLogic.EliminarCarrera(id).Message;

            return message;
        }
    }
}
