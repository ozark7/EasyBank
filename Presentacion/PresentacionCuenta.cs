using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica;
namespace Presentacion
{
    public class PresentacionCuenta
    {
        ServicioCuentas servicio = new ServicioCuentas();
        public void MenuCuentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO - MENU CUENTAS********************************");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("*        1. Agregar Cuenta                                                         *");
                Console.WriteLine("*        2. Consultar Cuenta                                                       *");
                Console.WriteLine("*        3. Consignar                                                              *");
                Console.WriteLine("*        4. Retirar                                                                *");
                Console.WriteLine("*        5. Modificar                                                              *");
                Console.WriteLine("*        6. Eliminar                                                               *");
                Console.WriteLine("*        7. volver ...                                                             *");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("************************************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: // agregar
                        MenuAgregar();
                        break;
                    case 2:
                        MenuConsultar();
                        break;
                    case 3:
                        Consignar();
                        break;
                    case 4:
                        Retirar();
                        break;
                    case 5:
                        EjecutarModificar();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcion != 7);
        }
        void MenuAgregar()
        {
            Cliente cliente;
            double numCuenta, saldo;
            string id;
            Console.Clear();
            Console.Write("id Cliente : "); id= Console.ReadLine();

            cliente = new ServicioClientes().BuscarId(id);  
            
            if (cliente==null)
            {
                Console.Clear();
                Console.WriteLine("cliente no existe ... debe crearlo primero");
                Console.ReadKey();
                return;
            }
            Console.Write("Numero de cuenta : "); numCuenta = double.Parse(Console.ReadLine());
            Console.Write("saldo inicial : "); saldo= double.Parse(Console.ReadLine());
            Cuenta cuenta = new Cuenta(numCuenta, cliente, saldo);

            Console.WriteLine(servicio.Guardar(cuenta));
            Console.ReadKey();
        }
        void MenuConsultar()
        {
            Console.Clear();
            Console.WriteLine("numero de Cuenta - nombre cliente - saldo  ");
            foreach (var item in servicio.Consultar())
            {
                Console.WriteLine(item.NumeroCuenta + " --> " + item.Cliente.Nombre + " --> " + item.getSaldo());
            }
            Console.ReadKey();
        }
        void Consignar()
        {
            Console.Clear();
            ServicioCuentas servicio = new ServicioCuentas();
            Cuenta cuenta = new Cuenta();
            Console.WriteLine("Digite el numero de cuenta");
            double numeroCuenta = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite el monto a consignar");
            double monto = double.Parse(Console.ReadLine());
            foreach (var item in servicio.Consultar())
            {
                if (item.NumeroCuenta == numeroCuenta)
                {
                    item.consignar(monto);
                    cuenta = item;
                }
            }
            if (cuenta==null)
            {
                Console.WriteLine("Cuenta no encontrada");
            }
            else
            {
                Console.WriteLine("El nuevo saldo es $"+cuenta.getSaldo());
                Console.WriteLine(servicio.Modificar());
            }
            Console.ReadKey();
        }
        void Retirar()
        {
            Console.Clear();
            Cuenta cuenta = new Cuenta();
            Console.WriteLine("Digite el numero de cuenta");
            double numeroCuenta = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite el monto a retirar");
            double monto = double.Parse(Console.ReadLine());
            foreach (var item in servicio.Consultar())
            {
                if (item.NumeroCuenta == numeroCuenta)
                {
                    item.Retirar(monto);
                    cuenta = item;
                }
            }
            if (cuenta == null)
            {
                Console.WriteLine("Cuenta no encontrada");
            }
            else
            {
                Console.WriteLine("El nuevo saldo es $" + cuenta.getSaldo());
                Console.WriteLine(servicio.Modificar());
            }
            Console.ReadKey();
        }
        void EjecutarModificar()
        {
            Console.Clear();
            Cuenta cuenta= new Cuenta();
            double NuevoNumero;
            Console.WriteLine("Digite el numero de la cuenta a modificar");
            double numero = double.Parse(Console.ReadLine());

            foreach (var item in servicio.Consultar())
            {
                if (item.NumeroCuenta == numero)
                {

                    Console.WriteLine("Digite el nuevo numero de cuenta");
                    NuevoNumero = double.Parse(Console.ReadLine());
                    item.NumeroCuenta = NuevoNumero;
                    cuenta = item;
                }
            }
            if (cuenta.NumeroCuenta == 0)
            {
                Console.WriteLine("Cuenta no encontrada");
            }
            else
            { 
                Console.WriteLine(servicio.Modificar());
                
            }
            Console.ReadKey();
        }
        void EjecutarEliminar()
        {

            Console.Clear();
            Cuenta cuenta = new Cuenta();
            double NuevoNumero;
            Console.WriteLine("Digite el numero de la cuenta a eliminar");
            double numero = double.Parse(Console.ReadLine());

            foreach (var item in servicio.Consultar())
            {
                if (item.NumeroCuenta == numero)
                {

                    
                    
                    //item.NumeroCuenta = NuevoNumero;
                    cuenta = item;
                }
            }
        }
    }
}
