using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Anual.Administrador_Inicio_Sesion;

namespace TP_Anual.Egresos
{
    public class BandejaDeMensajes
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("mensajes")]
        string mensajes { get; set; }

        [BsonElement("revisor")]
        public Usuario revisor { get; set; }

        [BsonElement("logs")]
        public List<Log> logs = new List<Log>();


        public BandejaDeMensajes(Usuario Revisor)
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

            if (usuario == revisor.nombre)
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