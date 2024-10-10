using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaVentas
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Articulo> _articulos;
        private List<Publicacion> _publicaciones;
        private List<Oferta> _ofertas;
        private List<Administrador> _administradores;

        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _articulos = new List<Articulo>();
            _publicaciones = new List<Publicacion>();
            _ofertas = new List<Oferta>();
            _administradores = new List<Administrador>();

            PrecargarClientes();
            PrecargarAdministradores();
            PrecargarArticulos();
            PrecargarVentas();
            PrecargarSubastas();

        }


        private void PrecargarClientes()
        {
            string[] nombresClientes = ["Juan", "Ana", "Carlos", "Laura", "Luis", "Marta", "Jorge", "Sofía", "Pablo", "Clara"];
            string[] apellidosClientes = ["García", "Pérez", "López", "Martínez", "Hernández", "Díaz", "González", "Sánchez", "Romero", "Torres"];

            for (int i = 0; i < 10; i++)
            {
                AltaCliente(nombresClientes[i], apellidosClientes[i], $"{nombresClientes[i].ToLower()}@gmail.com", $"password{i + 1}", 100m);
            }
        }

        private void PrecargarAdministradores()
        {
            AltaAdministrador("Roberto", "Martínez", "roberto@gmail.com", "passwordAdmin1");
            AltaAdministrador("Helena", "González", "helena@gmail.com", "passwordAdmin2");
        }

        private void PrecargarArticulos()
        {
            string[] nombresArticulos =
            [
                "Smartphone X1", "Laptop Pro", "Auriculares Bluetooth", "Camara DSLR", "Reloj Inteligente",
                "Tablet Ultra", "Parlante Portatil", "Teclado Mecanico", "Monitor 4K", "Cargador Solar",
                "Camara de Seguridad", "Impresora Inalambrica", "Consola de Videojuegos", "Gafas de Realidad Virtual",
                "Mochila Antirrobo", "Bateria Externa", "Drone FPV", "Accesorios para Videojuegos", "Funda para Laptop",
                "Hub USB", "Mouse Ergonomico", "Proyector Mini", "Silla Gaming", "Auriculares Gaming",
                "Estacion de Acoplamiento", "Camara Web HD", "Pantalla Portatil", "Soporte para Laptop",
                "Lampara LED", "Funda de Telefono", "Camara Instantanea", "Altavoz Inteligente", "Enfriador de Aire",
                "Sistemas de Sonido", "Camaras de Accion", "Cables de Carga", "Kit de Herramientas", "Funda para Camara",
                "Bolsa para Portatil", "Soporte de Telefono", "Accesorios de Fotografia", "Soporte de Pared",
                "Mando a Distancia", "Luces LED", "Repetidor de Señal", "Disco Duro Externo", "Adaptador de Viaje",
                "Camara Instantanea 2.0", "Smartphone X2", "Laptop ProMax Plus"
            ];

            string[] categorias = ["Electronica", "Hogar", "Ropa", "Deportes", "Libros", "Juguetes"];

            for (int i = 0; i < 50; i++)
            {
                AltaArticulo(nombresArticulos[i], categorias[i % categorias.Length], 50 + i * 10);
            }
        }

        private void PrecargarVentas()
        {
            for (int i = 1; i <= 10; i++)
            {
                List<Articulo> articulosVenta = new List<Articulo> { _articulos[(i - 1) * 2], _articulos[(i - 1) * 2 + 1] };
                AltaVenta($"Venta {i}", "ABIERTA", articulosVenta, i == 1 || i == 2);
            }
        }

        private void PrecargarSubastas()
        {
            for (int i = 11; i <= 20; i++)
            {
                List<Articulo> articulosSubasta = new List<Articulo> { _articulos[(i - 11) * 2], _articulos[(i - 11) * 2 + 1] };
                List<Oferta> ofertas = new List<Oferta>();

                if (i == 11 || i == 12)
                {
                    AltaOferta((Cliente)_usuarios[0], 200m);
                    AltaOferta((Cliente)_usuarios[1], 220m);
                    ofertas.Add(_ofertas[0]);
                    ofertas.Add(_ofertas[1]);
                }

                AltaSubasta($"Subasta {i - 10}", "ABIERTA", articulosSubasta, ofertas);
            }
        }



        public string ListarClientes()
        {
            string lista = "";
            bool hayClientes = false;
            foreach (Usuario u in _usuarios)
            {
                if (u.GetType() == typeof(Cliente))
                {
                    hayClientes = true;
                    Cliente clie = (Cliente)u;
                    lista += clie.ToString() + "\n";
                }
            }
            if (!hayClientes)
            {
                throw new Exception("No se encontraron usuarios de tipo cliente.");
            }
            return lista;
        }

        public string ListarArticulosPorCategoria(string categoria)
        {
            string lista = "";
            foreach (Articulo a in _articulos)
            {
                if (a.Categoria.Trim().ToUpper() == categoria.Trim().ToUpper())
                {
                    lista += a.ToString() + "\n";
                }
            }
            return lista;
        }

        public bool AltaArticulo(string nombre, string categoria, decimal precio)
        {
            try
            {
                Articulo art = new Articulo(nombre, categoria, precio);
                _articulos.Add(art);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AltaCliente(string nombre, string apellido, string mail, string password, decimal saldo)
        {
            try
            {
                Cliente cli = new Cliente(nombre, apellido, mail, password, saldo);
                _usuarios.Add(cli);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AltaAdministrador(string nombre, string apellido, string mail, string password)
        {
            try
            {
                Administrador ad = new Administrador(nombre, apellido, mail, password);
                _administradores.Add(ad);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AltaVenta(string nombre, string estado, List<Articulo> articulos, bool oferta)
        {
            try
            {
                Venta ven = new Venta(nombre, estado, articulos, oferta);
                _publicaciones.Add(ven);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AltaOferta(Cliente cliente, decimal monto)
        {
            try
            {
                Oferta offer = new Oferta(cliente, monto);
                _ofertas.Add(offer);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AltaSubasta(string nombre, string estado, List<Articulo> articulos, List<Oferta> ofertas)
        {
            try
            {
                Subasta subasta = new Subasta(nombre, estado, articulos, ofertas);
                _publicaciones.Add(subasta);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public string ListarPublicacionesEntre(DateTime fecha1, DateTime fecha2)
        {
            string lista = "";
            bool hayPublicaciones = false;
            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion > fecha1 && p.FechaPublicacion < fecha2)
                {
                    hayPublicaciones = true;
                    lista += p.ToString() + "\n";
                }
            }
            if (!hayPublicaciones)
            {
                throw new Exception("No hay publicaciones registradas entre las fechas ingresadas.");
            }

            return lista;
        }

        public bool ExisteCategoria(string categoria)
        {
            foreach (Articulo a in _articulos)
            {
                if (a.Categoria.Trim().ToUpper() == categoria.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
