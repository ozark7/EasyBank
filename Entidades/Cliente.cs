using System;

namespace Entidades
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public Cliente(string idCliente, string nombre)
        {
            IdCliente = idCliente;
            Nombre = nombre;
        }
        public Cliente()
        {

        }
        public override string ToString()
        {
            return IdCliente + ";" + Nombre;
        }
    }
}