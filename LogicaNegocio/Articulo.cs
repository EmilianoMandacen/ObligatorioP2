using LogicaVentas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{

        internal class Articulo : IValidate
        {
            private int _id;
            private static int s_ultId = 1;
            private string _nombre;
            private string _categoria;
            private decimal _precio;

            public Articulo(string nombre, string categoria, decimal precio)
            {
                _id = s_ultId++;
                _nombre = nombre;
                _categoria = categoria;
                _precio = precio;
                Validar();
            }

            public void Validar()
            {
                if (_precio < 0)
                {
                    throw new Exception("El precio no puede ser negativo");
                }
                if (_nombre == null)
                {
                    throw new Exception("El nombre no puede ser nulo");
                }
                if (_categoria == null)
                {
                    throw new Exception("La categoria no puede ser nula");
                }

            }

            public string Categoria 
            {  
                get { return _categoria; } 
            }

            public override string ToString()
            {
                return $"({_id}) - {_nombre} - {_categoria} - ${_precio}";
            }

            
    }
}
