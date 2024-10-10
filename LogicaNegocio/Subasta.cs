using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    internal class Subasta : Publicacion
    {
        private List<Oferta> _ofertas;

        public Subasta(string nombre, string estado, List<Articulo> articulos, List<Oferta> ofertas)
            : base (nombre, estado, articulos)
        {
            _ofertas = ofertas;
        }

        public override string ToString()
        {
            //string texto = "";
            //if (Estado.Trim().ToUpper() == "ABIERTA")
            //{
            //    texto = $"({Id}) - {Nombre} - Abierta\n{ListarArticulos}{ListarOfertas}";
            //} else if (Estado.Trim().ToUpper() == "CERRADA")
            //{
            //    texto = $"({Id}) - {Nombre} - {Estado} - {FechaFinalizacion}\n{ListarArticulos}Ganador: {Cliente} - Cerrado por: {Usuario}{ListarOfertas}";
            //}
            //return texto;
            return $"({Id}) - {Nombre} - {Estado} - {FechaPublicacion.ToShortDateString()}";
        }

        //private void ListarArticulos() 
        //{
        //    Console.WriteLine("Articulos:");
        //    foreach(Articulo a in Articulos)
        //    {
        //        Console.WriteLine("\t" + a.ToString());
        //    }
        //}

        //private void ListarOfertas()
        //{
        //    Console.WriteLine("Ofertas:");
        //    foreach (Oferta o in _ofertas)
        //    {
        //        Console.WriteLine("\t" + o.ToString());
        //    }
        //}
    }
}
