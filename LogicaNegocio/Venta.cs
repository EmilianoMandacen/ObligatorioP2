using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    public class Venta : Publicacion
    {
        private bool _ofertaRelampago;

        public Venta(string nombre, string estado, List<Articulo> articulos , bool ofertaRelampago)
            : base(nombre, estado, articulos)
        {
            _ofertaRelampago = ofertaRelampago;
        }

        public override string ToString()
        {
            return $"({Id}) - {Nombre} - {Estado} - {FechaPublicacion.ToShortDateString()}";
        }
    }
}
