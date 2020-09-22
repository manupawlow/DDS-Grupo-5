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
        public List<Provincia> provincias = new List<Provincia>();
        public List<Pais> paises = new List<Pais>();
        public List<Ciudad> ciudades = new List<Ciudad>();
        public List<Moneda> monedas = new List<Moneda>();

        
        public void obtenerProvincias()
        {

            Console.Out.WriteLine("PROVINCIAS SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLprovincias = new RestRequest("classified_locations/countries/AR");
            var responseMLprovincias = clientML.Get(requestMLprovincias).Content;
            dynamic listadoMLprovincias = JsonConvert.DeserializeObject(responseMLprovincias);
            dynamic provinciasSegunML = listadoMLprovincias["states"];
            JArray arrayProvinciasML = provinciasSegunML;
            List<Provincia> provinciasML = arrayProvinciasML.Select(x => new Provincia
            {
                nombreProvincia = (string)x["name"],
                idProvincia = (string)x["id"]

            }).ToList();

            provincias = provinciasML;
           
            Console.Out.WriteLine(provinciasML[0].nombreProvincia);
        }

        public void obtenerPaises()
        {
            Console.Out.WriteLine("PAISES SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLpaises = new RestRequest("classified_locations/countries");
            var responseMLpaises = clientML.Get(requestMLpaises).Content;
            dynamic listadoMLpaises = JsonConvert.DeserializeObject(responseMLpaises);
            JArray arrayPaisesML = listadoMLpaises;
            List<Pais> paisesML = arrayPaisesML.Select(x => new Pais
            {
                nombre = (string)x["name"],
                id = (string)x["id"],
                locale = (string)x["locale"],
                currency_id = (string)x["currency_id"]

            }).ToList();
           
            paises = paisesML;
            
        }

        public void ObtenerCiudades()
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


            JArray arrayCiudadesML = new JArray();
            for (int j = 0; j < idProvinciasML.Count; j++)
            {
                var requestMLciudades = new RestRequest("classified_locations/states/" + idProvinciasML[j]);
                var responseMLciudades = clientML.Get(requestMLciudades).Content;
                dynamic listadoMLciudades = JsonConvert.DeserializeObject(responseMLciudades);
                arrayCiudadesML.Add(listadoMLciudades["cities"]);
            }
            List<Ciudad> ciudadesML = arrayCiudadesML.Select(x => new Ciudad
            {
                id = (string)x["id"],
                nombre = (string)x["name"]

            }).ToList();
            ciudades = ciudadesML;

        }

        public void ObtenerMonedas()
        {
            Console.Out.WriteLine("MONEDAS SEGUN API DE MERCADO LIBRE\n");
            var clientML = new RestClient("https://api.mercadolibre.com/");
            var requestMLmonedas = new RestRequest("currencies/");
            var responseMLmonedas = clientML.Get(requestMLmonedas).Content;
            dynamic listadoMLmonedas = JsonConvert.DeserializeObject(responseMLmonedas);
            JArray arrayMonedasML = new JArray();
            List<Moneda> monedasML = arrayMonedasML.Select(x => new Moneda
            {
                id = (string)x["id"],
                descripcion = (string)x["description"],
                simbolo = (string)x["symbol"],
                decimales = (string)x["decimal_places"]

            }).ToList();
            monedas = monedasML;
        }


    }
}
