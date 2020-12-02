using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_Anual.Egresos
{
	public class BitacoraDeOperaciones
	{
		[BsonId]
		public ObjectId ID { get; set; }

		[BsonElement("bitacora")]
		private static BitacoraDeOperaciones bitacora;

		[BsonElement("logs")]
		public List<Log> logs = new List<Log>();

		public static BitacoraDeOperaciones GetInstance
		{
			get
			{
				if (bitacora == null) bitacora = new BitacoraDeOperaciones();

				return bitacora;
			}
		}


	}
}
