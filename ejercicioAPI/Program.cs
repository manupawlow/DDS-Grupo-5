using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace EjercicioAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("PROVINCIAS SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestML = new RestRequest("classified_locations/countries/AR");
            var responseML = clientML.Get(requestML).Content;
            dynamic listadoML = JsonConvert.DeserializeObject(responseML);
            dynamic provinciasSegunML = listadoML["states"];
            JArray nombresProvinciasML = new JArray();
            for (int i = 0; i < provinciasSegunML.Count; i++)
            {
                nombresProvinciasML.Add(provinciasSegunML[i]["name"]);
            }
            
            Console.Out.WriteLine(provinciasSegunML);
            
                
             
            



            Console.WriteLine("**********************\n\n");

            Console.WriteLine("PROVINCIAS SEGUN API DEL MINISTERIO DE MODERNIZACION DE LA NACION\n");
            var clientGob = new RestClient("https://apis.datos.gob.ar/georef/api/");
            var requestGob = new RestRequest("provincias?campos=id,nombre");
            //requestGob.RequestFormat = DataFormat.Json;
            var response = clientGob.Get(requestGob).Content;
            dynamic listadoGob =(JsonConvert.DeserializeObject<dynamic>(response));
            dynamic provinciasSegunGob = listadoGob["provincias"];

            JArray nombresProvinciasGob = new JArray();

            for (int j = 0; j < provinciasSegunGob.Count; j++)
            {
                nombresProvinciasGob.Add(provinciasSegunGob[j]["nombre"]);
            }

            Console.Out.WriteLine(provinciasSegunGob);

            Console.WriteLine("**********************\n\n");

            Console.WriteLine("DIFERENCIAS DE PROVINCIAS ENTRE AMBAS APIS\n");
            Console.WriteLine("Provincias que estan en la api de ML y no en la api de Gob\n");
            mostrarDiferencias(nombresProvinciasML, nombresProvinciasGob);
            Console.WriteLine("Provincias que estan en la api de Gob y no en la de ML\n");
            mostrarDiferencias(nombresProvinciasGob, nombresProvinciasML);
        }


        private static void mostrarDiferencias(JArray provinciasSegunUnaApi, JArray provinciasSegunOtraApi)
        {
            JArray provinciasDiferentes = new JArray();

            foreach (object nombreProvinciaML in provinciasSegunUnaApi)
            {


                if (!provinciasSegunOtraApi.Contains(nombreProvinciaML))
                {

                    provinciasDiferentes.Add(nombreProvinciaML);
                }

            }
            Console.Out.WriteLine(provinciasDiferentes);
        }

    }

  
}
