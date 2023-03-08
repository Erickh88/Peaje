using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClsTransacciones
{
    // Constantes de precios
    const int PRECIO_MOTO = 500;
    const int PRECIO_VEHICULO_LIVIANO = 700;
    const int PRECIO_CAMION_O_PESADO = 2700;
    const int PRECIO_AUTOBUS = 3700;

    //  Variables de vectores
    string[] numFactura = new string[100];
    string[] numPlaca = new string[100];
    DateTime[] fecha = new DateTime[100];
    TimeSpan[] hora = new TimeSpan[100];
    int[] tipoVehiculo = new int[100];
    int[] numCaseta = new int[100];
    int[] montoPagar = new int[100];
    int[] pagaCon = new int[100];
    int[] vuelto = new int[100];
    int cantidadVehiculos = 0;

    // Métodos de la clase
    public void InicializarVectores()
    {
        for (int i = 0; i < numFactura.Length; i++)
        {
            numFactura[i] = "";
            numPlaca[i] = "";
            fecha[i] = DateTime.MinValue;
            hora[i] = TimeSpan.Zero;
            tipoVehiculo[i] = 0;
            numCaseta[i] = 0;
            montoPagar[i] = 0;
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }

        cantidadVehiculos = 0;
    }

    public void IngresarDatos()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("REGISTRAR FLUJO VEHICULAR\n");

            // Lectura de datos
            Console.Write("Numero Factura: ");
            numFactura[cantidadVehiculos] = Console.ReadLine();

            Console.Write("Numero PLACA: ");
            numPlaca[cantidadVehiculos] = Console.ReadLine();

            Console.Write("Fecha (dd/mm/aaaa): ");
            fecha[cantidadVehiculos] = DateTime.Parse(Console.ReadLine());

            Console.Write("Hora (hh:mm): ");
            hora[cantidadVehiculos] = TimeSpan.Parse(Console.ReadLine());

            Console.WriteLine("Tipo de vehículo:");
            Console.WriteLine("[1= Moto\t2= Vehículo Liviano\t3=Camión o Pesado\t4=Autobús]");
            Console.Write("Selección: ");
            tipoVehiculo[cantidadVehiculos] = int.Parse(Console.ReadLine());

            Console.WriteLine("Numero caseta:");
            Console.WriteLine("[1= caseta 1\t2=caseta 2\t3=caseta 3]");
            Console.Write("Selección: ");
            numCaseta[cantidadVehiculos] = int.Parse(Console.ReadLine());

            switch (tipoVehiculo[cantidadVehiculos])
            {
                case 1:
                    montoPagar[cantidadVehiculos] = PRECIO_MOTO;
                    break;
                case 2:
                    montoPagar[cantidadVehiculos] = PRECIO_VEHICULO_LIVIANO;
                    break;
                case 3:
                    montoPagar[cantidadVehiculos] = PRECIO_CAMION_O_PESADO;
                    break;
                case 4:
                    montoPagar[cantidadVehiculos] = PRECIO_VEHICULO_LIVIANO;
                    break;

            }
        }
    }

    public void ConsultaPorPlaca()
    {
        Console.Clear();
        Console.WriteLine("-----Consulta de vehículo por número de placa-----");

        // Pedir al usuario que ingrese el número de placa del vehículo
        Console.Write("Ingrese el número de placa del vehículo que desea consultar: ");
        string numPlaca = Console.ReadLine();

        // Buscar la posición donde se encuentra la placa en el vector de placas
        int posicion = Array.IndexOf(transacciones.placas, numPlaca);
        // Si la placa no se encuentra en el vector, mostrar un mensaje y dar la opción de volver al menú o hacer una nueva consulta
        if (posicion == -1) 
        {
            Console.WriteLine("No se encontró ningún vehículo con el número de placa ingresado.");
            Console.WriteLine("Presione 1 para volver al menú principal o 2 para hacer una nueva consulta.");
            Console.Write("Seleccione una opción: ");
            int opcion;
            bool esNumero = int.TryParse(Console.ReadLine(), out opcion);
            if (esNumero && opcion == 2)
            {
                ConsultaPorPlaca();
            }
        }
        else // Si la placa se encuentra en el vector, mostrar los datos correspondientes al vehículo en un formato de tabla
        {
            Console.WriteLine("-----Reporte de vehículo-----");
            Console.WriteLine("N factura    Placa           tipo de vehículo          caseta        monto Pagar   paga con     vuelto");
            Console.WriteLine("=============================================================================");

            // Obtener los datos del vehículo en las posiciones correspondientes de los vectores
            int nFactura = transacciones.nFacturas[posicion];
            int tipoVehiculo = transacciones.tiposVehiculo[posicion];
            int caseta = transacciones.casetas[posicion];
            int montoPagar = transacciones.CalcularMontoAPagar(posicion); // Calcular el monto a pagar usando el método CalcularMontoAPagar()
            int pagaCon = transacciones.pagaCon[posicion];
            int vuelto = pagaCon - montoPagar;

            // Mostrar los datos del vehículo en la tabla
            Console.WriteLine("{0,-12}{1,-16}{2,-24}{3,-16}{4,-16}{5,-16}{6,-16}", nFactura, numPlaca, tipoVehiculo, caseta, montoPagar, pagaCon, vuelto);

            Console.WriteLine("=============================================================================");

            Console.WriteLine("Cantidad de vehículos:" );
            Console.WriteLine("=============================================================================");
            Console.WriteLine("                        <<<Pulse tecla para regresar >>>                     ");
        }
    
    }

    public void ModificarPorPlaca()
    {
        Console.Clear();
        Console.WriteLine("-----Modificar datos de vehículo por número de placa-----");
        Console.Write("Ingrese el número de placa del vehículo que desea modificar: ");
        string placa = Console.ReadLine();

        // Busca el vehículo correspondiente en los vectores
        int index = -1;
        for (int i = 0; i < transacciones.n; i++)
        {
            if (transacciones.vPlaca[i] == placa)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("No se encontró ningún vehículo con ese número de placa. Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Muestra los datos actuales del vehículo
        Console.WriteLine("\nDatos actuales del vehículo:");
        Console.WriteLine("Número de factura: " + transacciones.vFactura[index]);
        Console.WriteLine("Tipo de vehículo: " + transacciones.vTipo[index]);
        Console.WriteLine("Caseta: " + transacciones.vCaseta[index]);
        Console.WriteLine("Monto a pagar: " + transacciones.vMontoPagar[index]);

        // Pide al usuario que ingrese los nuevos datos para el vehículo
        Console.WriteLine("\nIngrese los nuevos datos para el vehículo:");
        Console.Write("Número de factura: ");
        int factura = int.Parse(Console.ReadLine());
        Console.Write("Tipo de vehículo (1: moto, 2: carro, 3: camión): ");
        int tipo = int.Parse(Console.ReadLine());
        Console.Write("Caseta: ");
        int caseta = int.Parse(Console.ReadLine());
        Console.Write("Monto a pagar: ");
        double monto = double.Parse(Console.ReadLine());

        // Actualiza los vectores con los nuevos datos
        transacciones.vFactura[index] = factura;
        transacciones.vTipo[index] = tipo;
        transacciones.vCaseta[index] = caseta;
        transacciones.vMontoPagar[index] = monto;

        Console.WriteLine("\nDatos modificados con éxito. Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

}


