//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////namespace Peaje
//////{
//////    internal class Program
//////    {
//////        static void Main(string[] args)
//////        {
//////        }
//////    }
////////}


//class Program
//{
//    static void Main(string[] args)
//    {
//        ClsMenu menu = new ClsMenu();
//        ClsTransacciones transacciones = new ClsTransacciones();

//        int opcion = 0;

//        do
//        {
//            menu.MostrarMenu();
//            opcion = menu.LeerOpcion();

//            switch (opcion)
//            {
//                case 1:
//                    transacciones.InicializarVectores();
//                    Console.WriteLine("Vectores inicializados.");
//                    break;
//                case 2:
//                    transacciones.IngresarPasoVehicular();
//                    break;
//                case 3:
//                    transacciones.ConsultarVehiculosPorPlaca();
//                    break;
//                case 4:
//                    transacciones.ModificarDatosVehiculosPorPlaca();
//                    break;
//                case 5:
//                    transacciones.ReporteTodosLosDatos();
//                    break;
//                case 6:
//                    Console.WriteLine("Saliendo del programa...");
//                    break;
//                default:
//                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
//                    break;
//            }

//            Console.WriteLine();
//        } while (opcion != 6);
//    }
//}
