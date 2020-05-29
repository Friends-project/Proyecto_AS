using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using SITIO.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SITIO.Controllers
{
    public class EstudianteController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Inicio()
        {
            //   FORMA 1
            //https://localhost:44354/api/Usuario/GetUsuarios
            var httpClient = new HttpClient();
            List<Estudiante> usuarioList = null;

            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiantes");

            if (json.ToString().Contains("{"))
            {
                usuarioList = JsonConvert.DeserializeObject<List<Estudiante>>(json);

                return View(usuarioList);
            }
            else
            {
                return View(usuarioList);
            }


        }

        // GET: Carrera/id
        [HttpPost]
        public async Task<ActionResult> Inicio(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiante?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Estudiante>>(json).First();

            return View(usuario);
        }

        // GET: Carrera/Details/5
        public async Task<ActionResult> Detalles(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiante?id=" + id);

            var usuario = JsonConvert.DeserializeObject<Estudiante>(json);

            return View(usuario);
        }

        // GET: Carrera/Create
        public async Task<ActionResult> Agregar()
        {

            #region Usuario
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuarios");

            var usuarioList = JsonConvert.DeserializeObject<List<Usuario>>(json);

            SelectList usuarioSelectList = new SelectList(usuarioList, "IdUsuario", "UsuarioEmail");

            ViewBag.Usuarios = usuarioSelectList;
            #endregion

            #region Carrera
            var http = new HttpClient();
            var jsonJs = await http.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarreras");

            var carreraList = JsonConvert.DeserializeObject<List<Carrera>>(jsonJs);

            SelectList carreraSelectList = new SelectList(carreraList, "CodigoCarrera", "NombreCarrera");

            ViewBag.Carreras = carreraSelectList;
            #endregion

            return View();
        }

        // POST: Carrera/Create
        [HttpPost]
        public async Task<ActionResult> Agregar(Estudiante usuario)
        {



            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/AgregarEstudiante", content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Edit/5
        [HttpGet]
        public async Task<ActionResult> Modificar(int id)
        {
            #region Usuario
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuarios");

            var usuarioList = JsonConvert.DeserializeObject<List<Usuario>>(json);

            SelectList usuarioSelectList = new SelectList(usuarioList, "IdUsuario", "UsuarioEmail");

            ViewBag.Usuarios = usuarioSelectList;
            #endregion

            #region Carrera
            var http = new HttpClient();
            var jsonJs = await http.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarreras");

            var carreraList = JsonConvert.DeserializeObject<List<Carrera>>(jsonJs);

            SelectList carreraSelectList = new SelectList(carreraList, "CodigoCarrera", "NombreCarrera");

            ViewBag.Carreras = carreraSelectList;
            #endregion


            httpClient = new HttpClient();
            var jsonN = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiante?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Estudiante>>(jsonN).First();

            return View(usuario);
        }

        // POST: Carrera/Edit/5
        [HttpPost]
        public async Task<ActionResult> Modificar(int id, Estudiante usuario)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/ModificarEstudiante?id=" + id, content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiante?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Usuario>>(json).First();

            return View(usuario);
        }

        // POST: Carrera/Delete/5
        public ActionResult Delete(int id)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());

            var response = httpClient.DeleteAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/EliminarEstudiante?id=" + id).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }


        public async Task ExporttoExcel()
        {

            List<Estudiante> usuarioList;

            try
            {
                var httpClient = new HttpClient();
                //valoresCierreDetalle = httpClient.Get<List<Carrera>>("api/GetCierreDetalle/" + CierreID, Session["Token"] as Token, out oError);
                var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Estudiante/GetEstudiantes");

                usuarioList = JsonConvert.DeserializeObject<List<Estudiante>>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reporte");
            ws.Cells["A1"].Value = "Reporte de Estudiantes";
            //ws.Cells["B1"].Value = datos.Cierre_Descripcion;
            ws.Cells["A2"].Value = "Fecha: " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            //ws.Cells["B2"].Value = datos.Tipo_Cierre;

            ws.Cells[1, 1].Style.Font.Bold = true;
            ws.Cells[2, 1].Style.Font.Bold = true;
            //ws.Cells[3, 1].Style.Font.Bold = true;
            //ws.Cells[1, 1].Style.Font.Size = 18;


            ws.Cells["A5"].Style.Font.Bold = true;
            ws.Cells["B5"].Style.Font.Bold = true;
            ws.Cells["C5"].Style.Font.Bold = true;
            ws.Cells["D5"].Style.Font.Bold = true;
            ws.Cells["E5"].Style.Font.Bold = true;
            ws.Cells["F5"].Style.Font.Bold = true;
            ws.Cells["G5"].Style.Font.Bold = true;
            ws.Cells["H5"].Style.Font.Bold = true;
            ws.Cells["I5"].Style.Font.Bold = true;


            ws.Cells["A5"].Value = "Codigo";
            ws.Cells["B5"].Value = "Usuario";
            ws.Cells["C5"].Value = "carrera";
            ws.Cells["D5"].Value = "Nombre Estudiante";
            ws.Cells["E5"].Value = "DPI";
            ws.Cells["F5"].Value = "Fecha Ingreso";
            ws.Cells["G5"].Value = "Telefono";
            ws.Cells["H5"].Value = "Direccion";
            ws.Cells["I5"].Value = "Edad";

            int rowStart = 6;
            foreach (var item in usuarioList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.IdEstudiante;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Usuario.UsuarioEmail;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Carrera.NombreCarrera;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.NombreEstudiante;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.DPI;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.FechaIngreso;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Telefono;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Direccion;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Edad;


                rowStart++;
            }

            //FORMATOS
            //ws.Cells[6, 3, rowStart - 1, 3].Style.Numberformat.Format = "[$" + Utilites.PaisActivo().ISOMoneda + "] ###,###,##0.00";
            //ws.Cells[6, 5, rowStart - 1, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
            for (int i = 5; i <= usuarioList.Count + 9; i++)
            {
                ws.Row(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            string tableName = "Reporte";
            ExcelRange rg = ws.Cells[5, 1, rowStart - 1, 9];
            ExcelTable tab = ws.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Medium2;



            string FileName = "Reporte_Estudiantes_" + "_" + DateTime.Today.ToString("dd/MM/yyyy") + ".xlsx";
            ws.Cells["A:AZ"].AutoFitColumns();
            ws.Column(1).Width = 12;  //Ancho COlumna codigo
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", FileName));
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }
}
