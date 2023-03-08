using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ClsMenu
{
    public ClsTransacciones transacciones;

    public ClsMenu()
    {
        transacciones = new ClsTransacciones();
    }

    public void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("-----Menú Principal del Sistema-----");
        Console.WriteLine("1. Inicializar Vectores");
        Console.WriteLine("2. Ingresar Paso Vehicular");
        Console.WriteLine("3. Consulta de vehículos por Número de Placa");
        Console.WriteLine("4. Modificar Datos de vehículos por Número de Placa");
        Console.WriteLine("5. Reporte Todos los Datos de los vectores");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");

        int opcion;
        bool esNumero = int.TryParse(Console.ReadLine(), out opcion);

        if (!esNumero || opcion < 1 || opcion > 6)
        {
            Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MostrarMenu();
        }
        else
        {
            switch (opcion)
            {
                case 1:
                    transacciones.InicializarVectores();
                    Console.WriteLine("\nVectores inicializados con éxito. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    MostrarMenu();
                    break;
                case 2:
                    transacciones.IngresarDatos();
                    Console.WriteLine("\nTransacciones registradas. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    MostrarMenu();
                    break;
                case 3:
                    transacciones.ConsultaPorPlaca();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    MostrarMenu();
                    break;
                case 4:
                    transacciones.ModificarPorPlaca();
                    Console.WriteLine("\nModificaciones realizadas con éxito. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    MostrarMenu();
                    break;
                //case 5:
                //    transacciones.ReporteCompleto();
                //    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                //    Console.ReadKey();
                //    MostrarMenu();
                //    break;
                case 6:
                    Console.WriteLine("Gracias por utilizar nuestro servicio. Presione cualquier tecla para salir...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}