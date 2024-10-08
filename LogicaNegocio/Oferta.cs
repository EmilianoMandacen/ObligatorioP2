using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    internal class Oferta
    {
        private int _id;
        private static int s_ultId = 1;
        private Usuario _usuario;
        private decimal _monto;
        private DateTime _fecha;

        public Oferta(Usuario usuario, decimal monto)
        {
            _id = s_ultId++;
            _usuario = usuario;
            _monto = monto;
            _fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"({_id}) - {_usuario} - ${_monto} - {_fecha.ToShortDateString}";
        }
    }


}
