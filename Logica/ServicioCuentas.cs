using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
namespace Logica
{
    public class ServicioCuentas
    {
        Datos.RepositorioCuenta repositorio = new Datos.RepositorioCuenta();
        //private List<Cuenta> ListaCuentas;
        public List<Cuenta> ListaCuentas { get; set; }
        public ServicioCuentas()
        {
            ListaCuentas = repositorio.Consultar();
        }
        public void Actualizar()
        {
            ListaCuentas = repositorio.Consultar();
        }
        public string Guardar(Cuenta cuenta)
        {
            //validar
            return repositorio.Guardar(cuenta);
        }
        public List<Cuenta> Consultar()
        {
            Actualizar();
            return ListaCuentas;
        }
        public String Modificar()
        {
            return repositorio.Modificar(ListaCuentas);
        }
        public Entidades.Cuenta BuscarCuenta(double numeroCuenta)
        {
            List<Entidades.Cuenta> cuentas = Consultar();
            foreach (Entidades.Cuenta cuenta in cuentas)
            {
                if (cuenta.NumeroCuenta == numeroCuenta)
                {
                    return cuenta;
                }
            }
            return null;
        }
    }
}
