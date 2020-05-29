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
    public class CarreraDB
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
        public Respuesta<T> ObtenerCarreras<T>(string sentencia, Respuesta<T> respuesta)
        {
            try
            {
                List<T> list;
                T obj = Activator.CreateInstance<T>();
                List<Carrera> carreraList;
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

                        carreraList = new List<Carrera>();

                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow data in dataSet.Tables[0].Rows)
                            {
                                carreraList.Add(new Carrera()
                                {
                                    CodigoCarrera = data.Field<int>("CodigoCarrera"),
                                    CentroE = new CentroEducativo()
                                    {
                                        IdCentro = data.Field<int>("IdCentro"),
                                        NombreCentro = data.Field<string>("NombreCentro"),
                                    },
                                    Cordinador = new Cordinador()
                                    {
                                        IdCordinador = data.Field<int>("IdCordinador"),
                                        NombreCordinador = data.Field<string>("NombreCordinador"),
                                    },
                                    NombreCarrera = data.Field<string>("NombreCarrera"),
                                    Duracion = data.Field<string>("Duracion"),

                                });
                            };

                            //Response.Response = uow.GetPropertyValue<int>(data["__ROWCOUNT"]) > 0;
                            //Response.Message = uow.GetPropertyValue<string>(data["RespMessage"]);

                        }


                        if (carreraList.Count < 1)
                        {
                            respuesta.Log = "No se encontraron resultados";
                            return respuesta;
                        }
                        else
                        {
                            respuesta.MyObj = carreraList;
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


        public Respuesta<T> AgregarCarrera<T>(string sentencia, Respuesta<T> respuesta)
        {
            try
            {
                List<T> list;
                T obj = obj = Activator.CreateInstance<T>();

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

                        respuesta.Log = "Insercion de " + obj.GetType().ToString().Split('.').Last() + " ejecutada correctamente";
                        return respuesta;
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.Log = "-- Excepxion econtrada: --  " + ex;
                return respuesta;
            }
            finally
            {

            }
        }

        public Respuesta<T> ModificarCarrera<T>(string sentencia, Respuesta<T> respuesta)
        {
            try
            {
                List<T> list;
                T obj = obj = Activator.CreateInstance<T>();

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

                        respuesta.Log = "Modificacion de " + obj.GetType().ToString().Split('.').Last() + " ejecutada correctamente";
                        return respuesta;
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.Log = "-- Excepxion econtrada: --  " + ex;
                return respuesta;
            }
            finally
            {

            }

        }

        public Respuesta<T> EliminarCarrera<T>(string sentencia, Respuesta<T> respuesta)
        {
            try
            {
                List<T> list;
                T obj = obj = Activator.CreateInstance<T>();

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

                        respuesta.Log = "Eliminacion de " + obj.GetType().ToString().Split('.').Last() + " ejecutada correctamente";
                        return respuesta;
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.Log = "-- Excepxion econtrada: --  " + ex;
                return respuesta;
            }
            finally
            {

            }

        }


    }
}