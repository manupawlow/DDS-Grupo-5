using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace Transportes
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        class Cliente
        {
            public int codigoCliente;
            public List<Envio> envios;

        }

        class Envio
        {
            public int codigoEnvio;
            public TipoEnvio tipoEnvio;
            public Transportista transportista;
            public double peso;


        }

        class Transportista
        {
            public int codigoTransportista;

        }

        class TipoEnvio
        {
            public double getPrecio(Envio envio)
            {

                return this.getPrecio(envio);
            }

        }

        class TarifaEstandar : TipoEnvio
        {
            public double tarifaXKilo;//como ejemplo de forma de calcular el precio uso la variable tarifaXKilo
            public double getPrecio(Envio envio)
            {
                return tarifaXKilo * envio.peso;
            }
        }

        class TransportistaPeso : TipoEnvio
        {
            public double distancia;//como ejemplo de forma de calcular el precio uso la variable distancia
            double getPrecio(Envio envio)
            {
                return envio.peso * distancia;
            }
        }
    }
}

