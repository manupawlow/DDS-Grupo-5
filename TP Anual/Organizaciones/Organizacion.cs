using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_Anual.Egresos;
using TP_Anual.ProcesoDeVinculacion;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace TP_Anual.Organizaciones
{
    public class Organizacion
    {
        public string actividad { get; set; }
        public int cantidadPersonal { get; set; }
        public string nombreFicticio { get; set; }
        public float promedioVentasAnuales { get; set; }
        
        [Column("id_tipo_organizacion")]
        public int id_tipo_organizacion { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }


        public char comisionista;
        public string tipo;
        public List<Egreso> egresos = new List<Egreso>();
        public List<Ingreso> ingresos = new List<Ingreso>();
        public List<Egreso> egresosPrueba = new List<Egreso>();
        public List<Ingreso> ingresosPrueba = new List<Ingreso>();
        public Vinculacion procesoDeVinculacion;
        public int criterio;
        public List<Condicion> condiciones = new List<Condicion>();
        public List<Vinculacion> vinculaciones = new List<Vinculacion>();

        public Organizacion()
        {
            //OrganizacionInterfaz();
            //AsignarTipoOrganizacion();
        }

        public void AsignarTipoOrganizacion()
        {

            using( var context = new BaseDeDatos() ){
                tipoOrganizacion = AsignarCategoria.Asignar(this);               
                context.tipos_organizacion.Add(tipoOrganizacion);
                context.SaveChanges();
            }
            
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

        public void vincular()
        {
            int i = 1;
            while (i == 1)
            {
                Console.Out.WriteLine("Elija una condicion: \n");
                Console.Out.WriteLine("1)Periodo de aceptabilidad    2)Ninguna\n");
                int condicionElegida = int.Parse(Console.ReadLine());
                switch (condicionElegida)
                {
                    case 1:
                        condiciones.Add(new PeriodoDeAceptabilidad());
                        break;

                    case 2:

                        break;


                }
                Console.Out.WriteLine("Si desea seguir agregando condiciones presione 1. Para dejar de agregar presione 0: \n");
                i = int.Parse(Console.ReadLine());
            }


            Console.Out.WriteLine("Elija un criterio: \n");
            Console.Out.WriteLine("1)Valor-Primer egreso \n");
            Console.Out.WriteLine("2)Valor-Primer ingreso \n");
            Console.Out.WriteLine("3)Fecha-Primer egreso \n");
            Console.Out.WriteLine("4)Mix \n");

            criterio = int.Parse(Console.ReadLine());
            switch (criterio)
            {
                case 1:
                    procesoDeVinculacion = new ValorPrimerEgreso();
                    procesoDeVinculacion.vincular(ingresosPrueba, egresosPrueba);
                    break;
                case 2:
                    procesoDeVinculacion = new ValorPrimerIngreso();
                    procesoDeVinculacion.vincular(ingresosPrueba, egresosPrueba);
                    break;
                case 3:
                    procesoDeVinculacion = new FechaPrimerEgreso();
                    procesoDeVinculacion.vincular(ingresosPrueba, egresosPrueba);
                    break;
                case 4:
                    int continuar = 1;
                    while (continuar != 2)
                    {
                        Console.Out.WriteLine("Elegir criterio:");
                        Console.Out.WriteLine("1)Valor-primer egreso \n");
                        Console.Out.WriteLine("2)Valor-primer ingreso \n");
                        Console.Out.WriteLine("3)Fecha-primer egreso \n");
                        criterio = int.Parse(Console.ReadLine());
                        switch (criterio)
                        {
                            case 1:
                                vinculaciones.Add(new ValorPrimerEgreso());
                                break;
                            case 2:
                                vinculaciones.Add(new ValorPrimerIngreso());
                                break;
                            case 3:
                                vinculaciones.Add(new FechaPrimerEgreso());
                                break;
                        }
                        Console.Out.WriteLine("1)Agregar Criterio\n");
                        Console.Out.WriteLine("2)Realizar vinculacion\n");
                        continuar = int.Parse(Console.ReadLine());
                    }
                    foreach (Vinculacion vinculacion in vinculaciones)
                    {
                        vinculacion.vincular(ingresos, egresos);
                    }

                    break;
            }
        }


        }
}
