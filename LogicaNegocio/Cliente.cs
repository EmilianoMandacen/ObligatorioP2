using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    internal class Cliente : Usuario
    {
        private decimal _saldo;

        public Cliente(string nombre, string apellido, string email, string password, decimal saldo)
            : base (nombre, apellido, email, password)
        {
            _saldo = saldo;
        }

        public void Comprar(Venta venta)
        {

        }

        public void Ofertar(decimal monto) 
        { 
        }

        public override string ToString()
        {
            return $"({Id}) - {Apellido}, {Nombre} - {Mail} - ${_saldo}";
        }
    }
}
