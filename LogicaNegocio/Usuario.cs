using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    public abstract class Usuario : IValidate
    {
        private int _id;
        private static int s_ultId = 1;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;

        public Usuario(string nombre, string apellido, string mail, string password)
        {
            _id = s_ultId++;
            _nombre = nombre;
            _apellido = apellido;
            _email = mail;
            _password = password;
            Validar();
        }

        internal int Id 
        { 
            get { return _id; } 
        }

        internal string Nombre
        {
            get { return _nombre; }
        }

        internal string Apellido
        {
            get { return _apellido; }
        }

        internal string Mail
        {
            get { return _email; }
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(_nombre))
            {
                throw new Exception("El nombre ingresado no es valido.");
            }
            if (string.IsNullOrWhiteSpace(_apellido))
            {
                throw new Exception("El apellido ingresado no es valido.");
            }
            if (string.IsNullOrWhiteSpace(_email))
            {
                throw new Exception("El email ingresado no es valido.");
            }
            if (string.IsNullOrWhiteSpace(_password))
            {
                throw new Exception("El password ingresado no es valido.");
            }
        }
    }
}
