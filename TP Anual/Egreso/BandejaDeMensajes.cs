using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public class BandejaDeMensajes
    {
        string mensajes;
        string revisor;


        public BandejaDeMensajes(string Revisor)
        {
            revisor = Revisor;
        }



        public void agregarMensaje(string msg)
        {/*
            StreamWriter archivo = File.AppendText("BandejaDeMensajes.txt");
            archivo.WriteLine(msg + "\n");
            archivo.Close();*/
            mensajes = mensajes + "\n" + msg;

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
                    Console.WriteLine("No se realizo ninguna validacion a la compra");
                else
                    Console.WriteLine(mensajes);
            }
            else
                Console.WriteLine("Usuario no apto para revisar la compra.");

        }



    }

}
