using API.Classes;
using API.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace API.Models
{
    public class GrupoUsuarioDB
    {
        MySqlConnectionStringBuilder builder;
        MySqlConnection miconexion;
        MySqlCommand micomando;
        MySqlDataAdapter adapter;
        //MySqlDataReader reader;
        DataTable dt;

        /// <summary>
        /// Mantenimiento Carrera
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sentencia"></param>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        public Respuesta<T> ObtenerGrupos<T>(string sentencia, Respuesta<T> respuesta)
        {
            try
            {
                List<T> list;
                T obj = Activator.CreateInstance<T>();
                List<GrupoUsuario> grupoList;
                //miconexion = new SqlConnection(@"Data source=localhost; Initial Catalog=localdb; User ID=root; Password=");
                //builder = new MySqlConnectionStringBuilder(@"server = localhost; database = localdb; user id = root; password =; port = 3306");
                //builder = new MySqlConnectionStringBuilder()
                //{
                //    Server = "sql3.freemysqlhosting.net",
                //    Port = 3306,
                //    Database = "sql3337198",
                //    UserID = "sql3337198",
                //    Password = "uWxLDhrXM1",
                //};

                //using (miconexion = new MySqlConnection(builder.ConnectionString))
                using (miconexion = new MySqlConnection(WebConfigurationManager.AppSettings["CadenaConexion"]))
                {
                    miconexion.Open();
                    micomando = new MySqlCommand(string.Format(sentencia), miconexion);
                    if (miconexion.State != ConnectionState.Open)
                    {
                        respuesta.Log = "Error al conectar con la base de datos";
                        return respuesta;
                    }
                    else
                    {
                        micomando.ExecuteNonQuery();
                        adapter = new MySqlDataAdapter(micomando);
                        //reader = micomando.ExecuteReader(); 
                        //dt = new DataTable();
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        grupoList = new List<GrupoUsuario>();

                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow data in dataSet.Tables[0].Rows)
                            {
                                grupoList.Add(new GrupoUsuario()
                                {
                                    IdGrupo = data.Field<int>("CodigoGrupo"),
                                    CentroE = new CentroEducativo()
                                    {
                                        IdCentro = data.Field<int>("IdCentro"),
                                        NombreCentro = data.Field<string>("NombreCentro"),
                                    },
                                    NombreGrupo = data.Field<string>("NombreGrupo"),

                                });
                            };

                            //Response.Response = uow.GetPropertyValue<int>(data["__ROWCOUNT"]) > 0;
                            //Response.Message = uow.GetPropertyValue<string>(data["RespMessage"]);

                        }


                        if (grupoList.Count < 1)
                        {
                            respuesta.Log = "No se encontraron resultados";
                            return respuesta;
                        }
                        else
                        {
                            respuesta.MyObj = grupoList;
                            respuesta.Log = "Consulta de " + obj.GetType().ToString().Split('.').Last() + " ejecutada correctamente";
                            return respuesta;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Log = "-- Excepxion econtrada: --  " + ex;
                return respuesta;
                //MessageBox.Show("Este es su error" + Ex.ToString(), "JESUCRISTO te ama", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

            }

        }
    }
}