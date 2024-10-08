using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVentas
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Articulo> _articulos;
        private List<Publicacion> _publicaciones;
        private List<Oferta> _ofertas;

        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _articulos = new List<Articulo>();
            _publicaciones = new List<Publicacion>();
            _ofertas = new List<Oferta>();

            PrecargarClientes();
            PrecargarAdministradores();
            PrecargarArticulos();
            PrecargarVentas();
            PrecargarSubastas();

        }


        private void PrecargarClientes()
        {
            string[] nombresClientes = { "Juan", "Ana", "Carlos", "Laura", "Luis", "Marta", "Jorge", "Sofía", "Pablo", "Clara" };
            string[] apellidosClientes = { "García", "Pérez", "López", "Martínez", "Hernández", "Díaz", "González", "Sánchez", "Romero", "Torres" };

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente(nombresClientes[i], apellidosClientes[i], $"{nombresClientes[i].ToLower()}@gmail.com", $"password{i + 1}", 100m);
                _usuarios.Add(cliente);
            }
        }

        private void PrecargarAdministradores()
        {
            Administrador admin1 = new Administrador("Roberto", "Martínez", "roberto@ejemplo.com", "passwordAdmin1");
            Administrador admin2 = new Administrador("Elena", "González", "elena@ejemplo.com", "passwordAdmin2");
            _usuarios.Add(admin1);
            _usuarios.Add(admin2);
        }

        private void PrecargarArticulos()
        {
            string[] nombresArticulos =
            {
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
            };

            string[] categorias = { "Electronica", "Hogar", "Ropa", "Deportes", "Libros", "Juguetes" };

            for (int i = 0; i < 50; i++)
            {
                Articulo articulo = new Articulo(nombresArticulos[i], categorias[i % categorias.Length], 50 + i * 10);
                _articulos.Add(articulo);
            }
        }

        private void PrecargarVentas()
        {
            Administrador admin1 = (Administrador)_usuarios.Find(u => u.Nombre == "Roberto");

            for (int i = 1; i <= 10; i++)
            {
                List<Articulo> articulosVenta = new List<Articulo> { _articulos[(i - 1) * 2], _articulos[(i - 1) * 2 + 1] };
                Venta venta = new Venta($"Venta {i}", "ABIERTA", DateTime.Now.AddDays(15), articulosVenta, (Cliente)_usuarios[i - 1], admin1, i == 1 || i == 2);
                _publicaciones.Add(venta);
            }
        }

        private void PrecargarSubastas()
        {
            Administrador admin2 = (Administrador)_usuarios.Find(u => u.Nombre == "Elena");

            for (int i = 11; i <= 20; i++)
            {
                List<Articulo> articulosSubasta = new List<Articulo> { _articulos[(i - 11) * 2], _articulos[(i - 11) * 2 + 1] };
                List<Oferta> ofertas = new List<Oferta>();

                if (i == 11 || i == 12)
                {
                    Oferta oferta1 = new Oferta((Cliente)_usuarios[0], 200m);
                    Oferta oferta2 = new Oferta((Cliente)_usuarios[1], 220m);
                    ofertas.Add(oferta1);
                    ofertas.Add(oferta2);
                    _ofertas.Add(oferta1);
                    _ofertas.Add(oferta2);
                }

                Subasta subasta = new Subasta($"Subasta {i - 10}", "ABIERTA", DateTime.Now.AddDays(7), articulosSubasta, (Cliente)_usuarios[i - 11], admin2, ofertas);
                _publicaciones.Add(subasta);
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
