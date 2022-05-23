using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion
{
    public class PresentacionCliente
    {
        Logica.ServicioClientes servicio = new Logica.ServicioClientes();
        public void MenuClientes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO - MENU CLIENTES********************************");
                Console.WriteLine("*                                                                                   *");
                Console.WriteLine("*        1. Agregar Cliente                                                         *");
                Console.WriteLine("*        2. Consultar Cliente                                                       *");
                Console.WriteLine("*        3. Modificar                                                               *");
                Console.WriteLine("*        4. Eliminar                                                                *");
                Console.WriteLine("*        5. volver ...                                                              *");
                Console.WriteLine("*                                                                                   *");
                Console.WriteLine("*************************************************************************************");
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
                        EjecutarModificar();
                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcion != 5);
        }
        void MenuAgregar()
        {
            Cliente cliente = new Cliente();
            Console.Clear();
            Console.Write("id Cliente : "); cliente.IdCliente = Console.ReadLine();
            Console.Write("nombre cliente : "); cliente.Nombre = Console.ReadLine();
            Console.WriteLine(servicio.Guardar(cliente));
            Console.ReadKey();
        }
        void MenuElmininar()
        {



        }
        int MenuModificar()
        {
            Console.Clear();
            Console.WriteLine("Que desea modificar");
            Console.WriteLine("1. Identificacion");
            Console.WriteLine("2. Nombre");
            int opc = int.Parse(Console.ReadLine());
            return opc;
        }
        public void EjecutarModificar()
        {
            Console.Clear();
            Logica.ServicioCuentas serviciocuentas = new Logica.ServicioCuentas();
            List<Cuenta> ListaCuentas = serviciocuentas.Consultar();
            //serviciocuentas
            Cliente cliente = new Cliente();
            Cliente clienteEncontrado = new Cliente();
            Console.WriteLine("Digite la identificacion");
            String id = Console.ReadLine();

            foreach (var item in servicio.Consultar())
            {
                if (item.IdCliente.Equals(id))
                {
                    clienteEncontrado=item; cliente = item;  
                }
            }
            if (cliente.IdCliente==null)
            {
                Console.WriteLine("Cliente no encontrado");
            }
            else
            {
                Console.Clear();
                int modo = MenuModificar();
                switch (modo)
                {
                    case 1:
                        Console.WriteLine("Digite la nueva identificacion: ");
                        string nuevaId = Console.ReadLine();
                        cliente.IdCliente = nuevaId;
                        break;
                    case 2:
                        Console.WriteLine("Digite el nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine();
                        cliente.Nombre = nuevoNombre;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                foreach(var item in ListaCuentas)
                {
                    if (item.Cliente.IdCliente == clienteEncontrado.IdCliente)
                    {
                        if(modo==1)
                            item.Cliente.Nombre = cliente.Nombre;
                        if(modo==2)
                            item.Cliente.IdCliente = cliente.IdCliente;
                    }
                }
                Console.WriteLine(servicio.Modificar());
                serviciocuentas.Modificar();
                
                
            }
            Console.ReadKey();

        }
        public void MenuConsultar()
        {
            Cliente cliente = new Cliente();
            
            Console.Clear();
            Console.WriteLine("id Cliente - nombre cliente  ");
            foreach (var item in servicio.Consultar())
            {
                Console.WriteLine(item.IdCliente + " --> " + item.Nombre);
            }

            Console.ReadKey();
        }
    }
}
