using Newtonsoft.Json;
using SITIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;

namespace SITIO.Controllers
{
    public class CarreraController : Controller
    {
        // GET: Carrera
        [HttpGet]
        public async Task<ActionResult> Inicio()
        {
            //   FORMA 1
            //https://localhost:44354/api/Carrera/GetCarreras
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarreras");

            var carreraList = JsonConvert.DeserializeObject<List<Carrera>>(json);

            //var carreraList = JsonConvert.DeserializeObject<List<Carrera>>(json);

            return View(carreraList);
        }

        // GET: Carrera/id
        [HttpPost]
        public async Task<ActionResult> Inicio(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarrera?id=" + id );

            var carrera = JsonConvert.DeserializeObject<List<Carrera>>(json).First();

            return View(carrera);
        }

        // GET: Carrera/Details/5
        public async Task<ActionResult> Detalles(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarrera?id=" + id);

            var carrera = JsonConvert.DeserializeObject<Carrera>(json);

            return View(carrera);
        }

        // GET: Carrera/Create
        public async Task<ActionResult> Agregar()
        {

            #region Centro Educativo
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/CentroE/GetCentrosEducativos");

            var centroEList = JsonConvert.DeserializeObject<List<CentroEducativo>>(json);

            SelectList centroSelectList = new SelectList(centroEList, "IdCentro", "NombreCentro");

            ViewBag.CentrosE = centroSelectList;
            #endregion

            #region Cordinador
            var http = new HttpClient();
            var jsonJs = await http.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Cordinador/GetCordinadores");

            var cordinadorList = JsonConvert.DeserializeObject<List<Cordinador>>(jsonJs);

            SelectList cordinadorSelectList = new SelectList(cordinadorList, "IdCordinador", "NombreCordinador");

            ViewBag.Cordinadores = cordinadorSelectList;
            #endregion

            return View();
        }

        // POST: Carrera/Create
        [HttpPost]
        public async Task<ActionResult> Agregar(Carrera carrera)
        {



            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(carrera), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/AgregarCarrera", content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Edit/5
        [HttpGet]
        public async Task<ActionResult> Modificar(int id)
        {
            #region Centro Educativo
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/CentroE/GetCentrosEducativos");

            var centroEList = JsonConvert.DeserializeObject<List<CentroEducativo>>(json);

            SelectList centroSelectList = new SelectList(centroEList, "IdCentro", "NombreCentro");

            ViewBag.CentrosE = centroSelectList;
            #endregion

            #region Cordinador
            httpClient = new HttpClient();
            var jsonJs = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Cordinador/GetCordinadores");

            var cordinadorList = JsonConvert.DeserializeObject<List<Cordinador>>(jsonJs);

            SelectList cordinadorSelectList = new SelectList(cordinadorList, "IdCordinador", "NombreCordinador");

            ViewBag.Cordinadores = cordinadorSelectList;
            #endregion


            httpClient = new HttpClient();
            var jsonN = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarrera?id=" + id);

            var carrera = JsonConvert.DeserializeObject<List<Carrera>>(jsonN).First();

            return View(carrera);
        }

        // POST: Carrera/Edit/5
        [HttpPost]
        public async Task<ActionResult> Modificar(int id, Carrera carrera)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(carrera), Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/ModificarCarrera?id=" + id, content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarrera?id=" + id);

            var carrera = JsonConvert.DeserializeObject<List<Carrera>>(json).First();

            return View(carrera);
        }

        // POST: Carrera/Delete/5
        public ActionResult Delete(int id)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());

            var response = httpClient.DeleteAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/EliminarCarrera?id=" + id).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }


        public async Task ExporttoExcel()
        {
            
            List<Carrera> carreraList;

            try
            {
                var httpClient = new HttpClient();
                //valoresCierreDetalle = httpClient.Get<List<Carrera>>("api/GetCierreDetalle/" + CierreID, Session["Token"] as Token, out oError);
                var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Carrera/GetCarreras");

                carreraList = JsonConvert.DeserializeObject<List<Carrera>>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reporte");
            ws.Cells["A1"].Value = "Reporte de Carreras";
            //ws.Cells["B1"].Value = datos.Cierre_Descripcion;
            ws.Cells["A2"].Value = "Fecha: "+ DateTime.Now.Date.ToString("dd/MM/yyyy");
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


            ws.Cells["A5"].Value = "Codigo";
            ws.Cells["B5"].Value = "Centro Educativo";
            ws.Cells["C5"].Value = "Coordinador";
            ws.Cells["D5"].Value = "Carrera";
            ws.Cells["E5"].Value = "Duración";

            int rowStart = 6;
            foreach (var item in carreraList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.CodigoCarrera;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.CentroE.NombreCentro;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Cordinador.NombreCordinador;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.NombreCarrera;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Duracion;

                rowStart++;
            }

            //FORMATOS
            //ws.Cells[6, 3, rowStart - 1, 3].Style.Numberformat.Format = "[$" + Utilites.PaisActivo().ISOMoneda + "] ###,###,##0.00";
            //ws.Cells[6, 5, rowStart - 1, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
            for (int i = 5; i <= carreraList.Count + 5; i++)
            {
                ws.Row(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            string tableName = "Reporte";
            ExcelRange rg = ws.Cells[5, 1, rowStart - 1, 5];
            ExcelTable tab = ws.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Medium2;



            string FileName = "Reporte_Carreras_" + "_" + DateTime.Today.ToString("dd/MM/yyyy") + ".xlsx";
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
