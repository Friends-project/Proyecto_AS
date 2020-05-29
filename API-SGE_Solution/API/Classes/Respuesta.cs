using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Classes
{
    public class Respuesta<T>
    {
        public string Message { get; set; }
        public bool Response { get; set; }
        public string Log { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<T> MyListGen { get; set; }
        public T MyObjGen { get; set; }
        public List<object> MyLIst { get; set; }
        public object MyObj { get; set; }

        public Respuesta()
        {
            this.Message = string.Empty;
            this.Response = false;
            this.Log = string.Empty;
            this.Type = string.Empty;
            this.Id = 0;
            this.Title = string.Empty;
            this.MyListGen = null;
            this.MyObjGen = default;
            this.MyLIst = null;
            this.MyObj = null;
        }
    }
}