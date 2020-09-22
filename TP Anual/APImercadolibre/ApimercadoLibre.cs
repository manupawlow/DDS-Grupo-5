using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace TP_Anual.APImercadolibre
{
    class ApimercadoLibre
    {
        public void provincias()
        {
            Console.Out.WriteLine("PROVINCIAS SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLprovincias = new RestRequest("classified_locations/countries/AR");
            var responseMLprovincias = clientML.Get(requestMLprovincias).Content;
            dynamic listadoMLprovincias = JsonConvert.DeserializeObject(responseMLprovincias);
            dynamic provinciasSegunML = listadoMLprovincias["states"];
            JArray nombresProvinciasML = new JArray();
            for (int i = 0; i < provinciasSegunML.Count; i++)
            {
                nombresProvinciasML.Add(provinciasSegunML[i]["name"]);
            }

            Console.Out.WriteLine(listadoMLprovincias);
        }

        public void paises()
        {
            Console.Out.WriteLine("PAISES SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLpaises = new RestRequest("classified_locations/countries");
            var responseMLpaises = clientML.Get(requestMLpaises).Content;
            dynamic listadoMLpaises = JsonConvert.DeserializeObject(responseMLpaises);
            JArray nombresPaisesML = new JArray();
            for (int i = 0; i < listadoMLpaises.Count; i++)
            {
                nombresPaisesML.Add(listadoMLpaises[i]["name"]);
            }

            Console.Out.WriteLine(listadoMLpaises);
        }

        public void ciudades()
        {
            Console.Out.WriteLine("CIUDADES SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLprovincias = new RestRequest("classified_locations/countries/AR");
            var responseMLprovincias = clientML.Get(requestMLprovincias).Content;
            dynamic listadoMLprovincias = JsonConvert.DeserializeObject(responseMLprovincias);
            dynamic provinciasSegunML = listadoMLprovincias["states"];
            JArray idProvinciasML = new JArray();
            for (int i = 0; i < provinciasSegunML.Count; i++)
            {
                idProvinciasML.Add(provinciasSegunML[i]["id"]);
            }


            JArray ciudadesML = new JArray();
            for (int j = 0; j < idProvinciasML.Count; j++)
            {
                var requestMLciudades = new RestRequest("classified_locations/states/" + idProvinciasML[j]);
                var responseMLciudades = clientML.Get(requestMLciudades).Content;
                dynamic listadoMLciudades = JsonConvert.DeserializeObject(responseMLciudades);
                ciudadesML.Add(listadoMLciudades["cities"]);
            }

            Console.Out.WriteLine(ciudadesML);
        }

        public void monedas()
        {
            Console.Out.WriteLine("MONEDAS SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLmonedas = new RestRequest("currencies/");
            var responseMLmonedas = clientML.Get(requestMLmonedas).Content;
            dynamic listadoMLmonedas = JsonConvert.DeserializeObject(responseMLmonedas);
            JArray nombresmonedasML = new JArray();
            for (int i = 0; i < listadoMLmonedas.Count; i++)
            {
                nombresmonedasML.Add(listadoMLmonedas[i]["name"]);
            }

            Console.Out.WriteLine(listadoMLmonedas);
        }


    }
}
