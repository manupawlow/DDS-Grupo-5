using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DDS_AlgoritmoValidador
{
    static class Validador
    {
        private static bool caracteresRepetidos(string palabra)
        {
            for (int i = 1; i < palabra.Length; i++)
            {
                if (palabra[i] == palabra[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool esPeroresContrasenias(string palabra)
        {
            using (StreamReader archivo = new StreamReader("Peores_Contrasenias.txt"))
            {
                while (!archivo.EndOfStream)
                {
                    string line = archivo.ReadLine();
                    if (line == palabra)
                    {
                        archivo.Close();
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool tieneConsecutivos(string palabra)
        {
            for (int i = 0; i < palabra.Length - 1; i++)
            {
                if (Convert.ToChar(palabra[i] + 1) == palabra[i + 1] && Convert.ToChar(palabra[i + 1] + 1) == palabra[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool validarContrasenia(string contrasenia)
        {
            return contrasenia.Length > 8 && contrasenia.Length <= 64 && !(caracteresRepetidos(contrasenia)) && !(esPeroresContrasenias(contrasenia)) && !(tieneConsecutivos(contrasenia));
        }

    }
}