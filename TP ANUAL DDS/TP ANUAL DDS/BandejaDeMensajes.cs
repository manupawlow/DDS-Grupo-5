using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TP_ANUAL_DDS
{
    static class BandejaDeMensajes
    {
        static public void agregarMensaje(string msg)
        {
            StreamWriter archivo = File.AppendText("BandejaDeMensajes.txt");
            archivo.WriteLine(msg + "\n");
            archivo.Close();
        }


        static public void mostrarMensajes()
        {
            using (StreamReader archivo = new StreamReader("BandejaDeMensajes.txt"))
            {
                while (!archivo.EndOfStream)
                {
                    string line = archivo.ReadLine();
                    Console.WriteLine(line);
                }
            }

        }



    }







}
