using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_Anual.Egresos;

namespace TP_Anual.Organizaciones
{
    public class Organizacion
    {
        private string actividad;
        private int cantidadPersonal;
        private string nombreFicticio;
        private float promedioVentasAnuales;
        private TipoOrganizacion tipoOrganizacion;
        private char comisionista;
        private string tipo;
        private List<Egreso> egresos;

        public Organizacion()
        {
            OrganizacionInterfaz();
            AsignarTipoOrganizacion();
        }

        private void AsignarTipoOrganizacion()
        {
            tipoOrganizacion =
                AsignarCategoria.Asignar(tipo, cantidadPersonal, actividad, promedioVentasAnuales, comisionista);
        }

        private void OrganizacionInterfaz()
        {
            Console.Write("Ingrese nombre ficticio: ");
            nombreFicticio = Console.ReadLine();

            Console.Write("Ingrese actividad: ");
            actividad = Console.ReadLine();

            Console.Write("Es actividad a comisionista o de agencia de viajes? S/N: ");
            comisionista = Console.ReadLine().ToUpper()[0];

            Console.Write("Ingrese promedio de ventas anuales: ");
            string entrada = Console.ReadLine();
            promedioVentasAnuales = float.Parse(entrada);

            Console.Write("Ingrese cantidad de personal: ");
            entrada = Console.ReadLine();
            cantidadPersonal = int.Parse(entrada);

            Console.Write("Ingrese tipo de organizacion: ");
            tipo = Console.ReadLine();
        }
 

    }
}
