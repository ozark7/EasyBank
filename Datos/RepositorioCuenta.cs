using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Datos
{
    public class RepositorioCuenta
    {
        string ruta = "Cuentas.txt";// ruta donde se guarda el archivo
        public string Guardar(Entidades.Cuenta cuenta)
        {
            try
            {
                //FileStream archivo = new FileStream(ruta, FileMode.Append);
                //1. instanciar - abre en modo append -  adiciona datos
                StreamWriter escritor = new StreamWriter(ruta, true);

                // 2. operaciones
                escritor.WriteLine(cuenta.ToString());

                //3.  guardar
                escritor.Close();

                return "Se guardaron los datos";
            }
            catch (Exception)
            {
                return "NO Se guardaron los datos";
            }

        }
        public string Modificar(List<Entidades.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                return "Se modificaron los datos";

                //File.Delete(ruta);  // elimina
                //File.Move("tmp", ruta);// renombrar
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public Entidades.Cuenta BuscarCuenta(double numeroCuenta)
        {
            List<Entidades.Cuenta> cuentas = Consultar();
            foreach(Entidades.Cuenta cuenta in cuentas)
            {
                if (cuenta.NumeroCuenta == numeroCuenta)
                {
                    return cuenta;
                }
            }
            return null;
        }
        public string Modificar2(List<Entidades.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt", true);// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                File.Delete(ruta);  // elimina
                File.Move("tmp.txt", ruta);// renombrar

                return "Se modificaron los datos los datos";

            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        
        public List<Entidades.Cuenta> Consultar()
        {
            try
            {
                StreamReader lector = new StreamReader(ruta);
                List<Entidades.Cuenta> cuentas = new List<Entidades.Cuenta>();
                // 2. operaciones
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    double numCuenta =double.Parse( linea.Split(';')[0]);
                    Entidades.Cliente cliente = new RepositorioClientes().buscarId(linea.Split(';')[1]);
                    double saldo = double.Parse(linea.Split(';')[2]);

                 Entidades.Cuenta cuenta = new Entidades.Cuenta(numCuenta,cliente, saldo );
                 cuentas.Add(cuenta);
                }

                //3.  guardar
                lector.Close();

                return cuentas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Entidades.Cuenta> Consultar2()
        {
            try
            {
                StreamReader lector = new StreamReader(ruta);
                List<Entidades.Cuenta> cuentas = new List<Entidades.Cuenta>();
                // 2. operaciones
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    double numCuenta = double.Parse(linea.Split(';')[0]);

                    Entidades.Cliente cliente;// = new RepositorioClientes().buscarId(linea.Split(';')[1]);
                    if (new RepositorioClientes().buscarId(linea.Split(';')[1]) == null) {
                        cliente = new RepositorioClientes().buscarId(linea.Split(';')[1]);
                    }
                    else
                    {
                        cliente = new RepositorioClientes().buscarNombre(linea.Split(';')[1]);
                    }
                    double saldo = double.Parse(linea.Split(';')[2]);

                    Entidades.Cuenta cuenta = new Entidades.Cuenta(numCuenta, cliente, saldo);
                    cuentas.Add(cuenta);
                }

                //3.  guardar
                lector.Close();

                return cuentas;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
