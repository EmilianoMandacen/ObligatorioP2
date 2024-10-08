using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    internal class Venta : Publicacion
    {
        private bool _ofertaRelampago;

        public Venta(string nombre, string estado, DateTime fechaFinalizacion, List<Articulo> articulos, Cliente cliente, Usuario usuario, bool ofertaRelampago)
            : base(nombre, estado, fechaFinalizacion, articulos, cliente, usuario)
        {
            _ofertaRelampago = ofertaRelampago;
        }

        public override string ToString()
        {
            return $"({Id}) - {Nombre} - {Estado} - {FechaPublicacion.ToShortDateString()}";
        }
    }
}
