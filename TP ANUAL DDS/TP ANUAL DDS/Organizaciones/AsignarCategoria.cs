using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS
{
    class AsignarCategoria
    {
        static List<Empresa> categorias = new List<Empresa>()
        {
            new Micro(),
            new Pequenha(),
            new MedianaTramo1(),
            new MedianaTramo2()
        };

        public static TipoOrganizacion Asignar(string tipo, int cantidadPersonal, 
            string actividad, float promedioVentasAnuales, char comisionista)
        {
            if(tipo == "Empresa")
            {
                Empresa categoria;
                if (comisionista == 'S')
                {
                    categoria = categoriaSegunPersonal(actividad, cantidadPersonal);
                } 
                else
                {
                    categoria = mayorCategoriaEntrePersonalVenta(actividad, cantidadPersonal, promedioVentasAnuales);
                }

                switch (categoria.GetType().Name)
                {
                    case nameof(Micro):
                        return new Micro();
                    case nameof(Pequenha):
                        return new Pequenha();
                    case nameof(MedianaTramo1):
                        return new MedianaTramo1();
                    case nameof(MedianaTramo2):
                        return new MedianaTramo2();
                    default:
                        break;
                    case null:
                        throw new ArgumentNullException(nameof(categoria));
                }
            }
            return new OSC();
        }



        
        private static Empresa categoriaSegunPersonal(string actividad, int cantidadPersonal)
        {
            foreach(Empresa categoria in categorias)
            {
                if(categoria.TopePersonalPorActividad(actividad) >= cantidadPersonal)
                {
                    return categoria;
                }
            }
            return categorias[categorias.Count - 1];
        }
        private static Empresa categoriaSegunPromedioVentasAnuales(string actividad, float promedioVentasAnuales)
        {
            foreach(Empresa categoria in categorias)
            {
                if(categoria.TopeVentasPorActividad(actividad) >= promedioVentasAnuales)
                {
                    return categoria;
                }
            }
            return categorias[categorias.Count - 1];
        }
        private static Empresa mayorCategoriaEntrePersonalVenta(string actividad, int cantidadPersonal, float promedioVentas)
        {
            Empresa categoriaPersonal, categoriaVenta;
            categoriaPersonal = categoriaSegunPersonal(actividad, cantidadPersonal);
            categoriaVenta = categoriaSegunPromedioVentasAnuales(actividad, promedioVentas);

            int iPersonal, iVenta;
            iPersonal = categorias.FindIndex(categoria => categoria.Tipo == categoriaPersonal.Tipo);
            iVenta = categorias.FindIndex(categoria => categoria.Tipo == categoriaVenta.Tipo);

            if(iVenta > iPersonal)
            {
                return categoriaVenta;
            }
            else
            {
                return categoriaPersonal;
            }
        }
        
    }
}
/*
 * en el caso de comisionista se calcula categoría según personal,

 * sino la mayor categoría entre personal y valor.
 * 
 */
