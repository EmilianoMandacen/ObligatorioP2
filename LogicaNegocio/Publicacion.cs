using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    public abstract class Publicacion : IValidate
    {
        private int _id;
        private static int s_ultId = 1;
        private string _nombre;
        private string _estado;
        private DateTime _fechaPublicacion;
        private DateTime _fechaFinalizacion;
        private List<Articulo> _articulos;
        private Cliente _cliente;
        private Usuario _usuario;

        public Publicacion(string nombre, string estado, List<Articulo> articulos)
        {
            _id = s_ultId++;
            _nombre = nombre;
            _estado = estado;
            _fechaPublicacion = DateTime.Now;
            _articulos = articulos;
            Validar();
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre { get { return _nombre; } }
        public string Estado { get { return _estado; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion;} }
        public List<Articulo> Articulos {  get { return _articulos; } }
        public Cliente Cliente { get {  return _cliente; } }
        public Usuario Usuario { get {  return _usuario; } }
        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
        }

        public void Validar()
        {
            if (_nombre == null)
            {
                throw new Exception("El nombre no puede ser nulo");
            }
            if (_estado.Trim().ToUpper() != "ABIERTA" && _estado.Trim().ToUpper() != "CERRADA" && _estado.Trim().ToUpper() != "CANCELADA")
            {
                throw new Exception("El estado no puede ser diferente a: abierta, cerrada o cancelada");
            }
            if (_articulos == null)
            {
                throw new Exception("La lista de articulos no puede ser nula");
            }
        }

        public override string ToString()
        {
            return $"({_id}) - {_nombre} - {_estado} - {_fechaPublicacion.ToShortDateString}";
        }
    }
}
