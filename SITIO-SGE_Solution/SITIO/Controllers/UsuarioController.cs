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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public async Task<ActionResult> Inicio()
        {
            //   FORMA 1
            //https://localhost:44354/api/Usuario/GetUsuarios
            var httpClient = new HttpClient();
            List<Usuario> usuarioList = null;

            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuarios");

            if (json.ToString().Contains("{"))
            {
                usuarioList = JsonConvert.DeserializeObject<List<Usuario>>(json);

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
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuario?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Usuario>>(json).First();

            return View(usuario);
        }

        // GET: Carrera/Details/5
        public async Task<ActionResult> Detalles(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuario?id=" + id);

            var usuario = JsonConvert.DeserializeObject<Usuario>(json);

            return View(usuario);
        }

        // GET: Carrera/Create
        public async Task<ActionResult> Agregar()
        {

            #region Grupo
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Grupo/GetGrupos");

            var grupoList = JsonConvert.DeserializeObject<List<GrupoUsuario>>(json);

            SelectList grupoSelectList = new SelectList(grupoList, "IdGrupo", "NombreGrupo");

            ViewBag.Grupos = grupoSelectList;
            #endregion

            #region Privilegio
            var http = new HttpClient();
            var jsonJs = await http.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Privilegio/GetPrivilegios");

            var privilegioList = JsonConvert.DeserializeObject<List<Privilegio>>(jsonJs);

            SelectList privilegioSelectList = new SelectList(privilegioList, "IdPrivilegio", "NombrePrivilegio");

            ViewBag.Privilegios = privilegioSelectList;
            #endregion

            return View();
        }

        // POST: Carrera/Create
        [HttpPost]
        public async Task<ActionResult> Agregar(Usuario usuario)
        {



            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/AgregarUsuario", content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Edit/5
        [HttpGet]
        public async Task<ActionResult> Modificar(int id)
        {
            #region Grupo
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Grupo/GetGrupos");

            var grupoList = JsonConvert.DeserializeObject<List<GrupoUsuario>>(json);

            SelectList grupoSelectList = new SelectList(grupoList, "IdGrupo", "NombreGrupo");

            ViewBag.Grupos = grupoSelectList;
            #endregion

            #region Privilegio
            var http = new HttpClient();
            var jsonJs = await http.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Privilegio/GetPrivilegios");

            var privilegioList = JsonConvert.DeserializeObject<List<Privilegio>>(jsonJs);

            SelectList privilegioSelectList = new SelectList(privilegioList, "IdPrivilegio", "NombrePrivilegio");

            ViewBag.Privilegios = privilegioSelectList;
            #endregion


            httpClient = new HttpClient();
            var jsonN = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuario?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Usuario>>(jsonN).First();

            return View(usuario);
        }

        // POST: Carrera/Edit/5
        [HttpPost]
        public async Task<ActionResult> Modificar(int id, Usuario usuario)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/ModificarUsuario?id=" + id, content).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }

        // GET: Carrera/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuario?id=" + id);

            var usuario = JsonConvert.DeserializeObject<List<Usuario>>(json).First();

            return View(usuario);
        }

        // POST: Carrera/Delete/5
        public ActionResult Delete(int id)
        {
            var httpClient = new HttpClient();
            //var json =  await httpClient.PostAsync("https://localhost:44354/", carrera, new JsonMediaTypeFormatter());

            var response = httpClient.DeleteAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/EliminarUsuario?id=" + id).Result;

            ViewBag.Message = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Inicio");
        }


        public async Task ExporttoExcel()
        {

            List<Usuario> usuarioList;

            try
            {
                var httpClient = new HttpClient();
                //valoresCierreDetalle = httpClient.Get<List<Carrera>>("api/GetCierreDetalle/" + CierreID, Session["Token"] as Token, out oError);
                var json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["dirAPI"] + "api/Usuario/GetUsuarios");

                usuarioList = JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reporte");
            ws.Cells["A1"].Value = "Reporte de Usuarios";
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


            ws.Cells["A5"].Value = "Codigo";
            ws.Cells["B5"].Value = "Grupo";
            ws.Cells["C5"].Value = "Privilegio";
            ws.Cells["D5"].Value = "Fecha Creacion";
            ws.Cells["E5"].Value = "Usuario";
            ws.Cells["F5"].Value = "Contraseña";

            int rowStart = 6;
            foreach (var item in usuarioList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.IdUsuario;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Grupo.NombreGrupo;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Privilegio.NombrePrivilegio;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.FechaCreacion.ToString("dd/MM/yyyy");
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.UsuarioEmail;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Contrasena;

                rowStart++;
            }

            //FORMATOS
            //ws.Cells[6, 3, rowStart - 1, 3].Style.Numberformat.Format = "[$" + Utilites.PaisActivo().ISOMoneda + "] ###,###,##0.00";
            //ws.Cells[6, 5, rowStart - 1, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
            for (int i = 5; i <= usuarioList.Count + 5; i++)
            {
                ws.Row(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            string tableName = "Reporte";
            ExcelRange rg = ws.Cells[5, 1, rowStart - 1, 6];
            ExcelTable tab = ws.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Medium2;



            string FileName = "Reporte_Usuarios_" + "_" + DateTime.Today.ToString("dd/MM/yyyy") + ".xlsx";
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
