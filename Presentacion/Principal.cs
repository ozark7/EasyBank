using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
   public class Principal
    {
        public void MenuPrincipal()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("**************************** BANCO - MENU PRINCIPAL********************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. CLIENTES                                                  *");
                Console.WriteLine("*        2. CUENTAS                                                   *");
                Console.WriteLine("*        3. SALIR                                                     *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        new PresentacionCliente().MenuClientes();
                        break;
                    case 2:
                        new PresentacionCuenta().MenuCuentas();
                        break;
                    //case 3:
                    //    Environment.Exit(5);
                    //    break;
                }
            } while (opcion != 3);

        }
    }
}
