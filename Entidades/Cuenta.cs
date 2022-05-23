using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cuenta
    {
        public Cuenta(double numeroCuenta, Cliente cliente, double saldo)
        {
            NumeroCuenta = numeroCuenta;
            Cliente = cliente;
            Saldo = saldo;
        }
        public Cuenta() { }

        public double NumeroCuenta { get; set; }
        public Cliente Cliente { get; set; }
        private double Saldo;
        public double getSaldo()
        {
            return Saldo;
        }
        public String consignar(double monto)
        {
            this.Saldo += monto;
            return "Saldo Resultante $" + this.Saldo;
        }
        public String Retirar(double monto)
        {
            if ((this.Saldo - monto) < 0)
            {
                return "No puede sacar mas de $" + this.Saldo;    
            }
            else
            {
                this.Saldo -= monto;
            }
            return "Saldo restante $" + this.Saldo;
        }
        public override string ToString()
        {
            return NumeroCuenta.ToString() + ";" + Cliente.IdCliente + ";" + Saldo.ToString(); 
        }
    }
}
