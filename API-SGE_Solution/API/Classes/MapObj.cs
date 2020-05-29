using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace API.Classes
{
    public class MapObj
    {
        public List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public List<T> DataTableMapToList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            foreach (DataRow row in dt.Rows)
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(row[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, row[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}