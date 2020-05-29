using API.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace API.Models
{
    public class CentroEducativoDB
    {
        MySqlConnectionStringBuilder builder;
        MySqlConnection miconexion;
        MySqlCommand micomando;
        MySqlDataAdapter adapter;
        //MySqlDataReader reader;
        DataTable dt;

        public Respuesta<T> ObtenerCentroEducativos<T>(string sentencia, Respuesta<T> respuesta)
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
                        adapter = new MySqlDataAdapter(micomando);
                        //reader = micomando.ExecuteReader(); 
                        dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count < 1)
                        {
                            respuesta.Log = "No se encontraron resultados";
                            return respuesta;
                        }
                        else
                        {
                            MapObj mapObj = new MapObj();

                            list = new List<T>();
                            list = mapObj.DataTableMapToList<T>(dt);
                            if (list.Count < 1)
                            {
                                respuesta.Log = "Error al realizar el mapeo";
                                return respuesta;
                            }
                            else
                            {
                                respuesta.MyListGen = list;
                                respuesta.Log = "Consulta de " + obj.GetType().ToString().Split('.').Last() + " ejecutada correctamente";
                                return respuesta;
                            }

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