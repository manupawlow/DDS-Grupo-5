using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual.Egresos
{
    public class Log
    {
        [BsonElement("fecha")]
        public DateTime fecha { get; set; }

        [BsonElement("accion")]
        public string accion { get; set; }

        public Log(string accion, DateTime fecha)
        {
            this.accion = accion;
            this.fecha = fecha;
        }
    }
}