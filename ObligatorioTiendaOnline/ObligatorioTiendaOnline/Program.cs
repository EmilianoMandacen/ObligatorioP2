namespace ObligatorioTiendaOnline
{
    internal class Program
    {
        private static LogicaVentas.Sistema sistema = new LogicaVentas.Sistema();
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void Menu()
        {
            int opcion = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Bienvenido al Menu ===\n");

                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Listar articulos de una categoria");
                Console.WriteLine("3. Dar de alta un nuevo articulo");
                Console.WriteLine("4. Listar publicaciones entre dos fechas");
                Console.WriteLine("0. Salir");

                Console.Write("\nSeleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("\nOpcion no valida.");
                    opcion = -1;
                    Console.ReadKey();
                }
                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine(sistema.ListarClientes());
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Write("Ingrese la categoria: ");
                            string categoria = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(categoria) && sistema.ExisteCategoria(categoria))
                            {
                                Console.WriteLine(sistema.ListarArticulosPorCategoria(categoria));
                            }
                            else
                            {
                                Console.WriteLine("La categoria ingresada no existe.");
                            }
                            Console.ReadKey();
                            break;
                        case 3:
                            MenuAltaArticulo();
                            break;
                        case 4:
                            Console.Write("Ingrese la primer fecha (dd/mm/yyyy): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha1))
                            {
                                throw new Exception("La fecha ingresada no es valida");
                            }
                            Console.Write("Ingrese la segunda fecha (dd/mm/yyyy): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha2))
                            {
                                throw new Exception("La fecha ingresada no es valida");
                            }
                            Console.WriteLine(sistema.ListarPublicacionesEntre(fecha1, fecha2));
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }


            } while (opcion != 0);
        }

        public static void MenuAltaArticulo()
        {
            Console.Clear();
            Console.WriteLine("=== Alta de Articulo ===\n");

            Console.Write("Ingrese el nombre del articulo: ");
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre no puede estar vacio.");
            }

            Console.Write("Ingrese la categoria del articulo: ");
            string categoria = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(categoria))
            {
                throw new Exception("La categoria no puede estar vacio.");
            }

            Console.Write("Ingrese el precio del articulo: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                throw new Exception("El precio ingresado para el articulo no es valido.");
            }

            if (!sistema.AltaArticulo(nombre, categoria, precio))
            {
                throw new Exception("No se pudo registrar el articulo.");
            }
        }

    }
}