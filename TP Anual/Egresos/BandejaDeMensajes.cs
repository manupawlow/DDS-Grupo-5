using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public class BandejaDeMensajes
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("mensajes")]
        string mensajes { get; set; }

        [BsonElement("revisor")]
        public string revisor { get; set; }

        [BsonElement("logs")]
        public List<Log> logs = new List<Log>();


        public BandejaDeMensajes(string Revisor)
        {
            revisor = Revisor;
            this.logs.Add(new Log("Se ha creado una nueva bandeja de mensajes", DateTime.UtcNow));
        }



        public void agregarMensaje(string msg)
        {/*
            StreamWriter archivo = File.AppendText("BandejaDeMensajes.txt");
            archivo.WriteLine(msg + "\n");
            archivo.Close();*/
            mensajes = mensajes + "\n" + msg;
            this.logs.Add(new Log($"Se ha agregado el mensaje: '{msg}' ", DateTime.UtcNow));
        }


        public void mostrarMensajes(string usuario)
        {
            /*
            using (StreamReader archivo = new StreamReader("BandejaDeMensajes.txt"))
            {
                while (!archivo.EndOfStream)
                {
                    string line = archivo.ReadLine();
                    Console.WriteLine(line);
                }
            }
            */

            if (usuario == revisor)
            {
                if (mensajes == null)
                {
                    Console.WriteLine("No se realizo ninguna validacion a la compra");
                    this.logs.Add(new Log($"{usuario} ha checkiado los mensajes aunque esten vacios", DateTime.UtcNow));
                }
                else
                {
                    Console.WriteLine(mensajes);
                    this.logs.Add(new Log($"{usuario} ha checkiado los mensajes correctamente", DateTime.UtcNow));
                }
            }
            else
            {
                Console.WriteLine("Usuario no apto para revisar la compra.");
                this.logs.Add(new Log($"Hubo un intento de checkear los mensajes, {usuario} no era apto para ver los mismos", DateTime.UtcNow));
            }
        }



    }

}