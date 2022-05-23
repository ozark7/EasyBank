using System;
using System.Collections.Generic;
using Entidades;
using Datos;
namespace Logica
{
    public class ServicioClientes
    {
        RepositorioClientes repositorio = new RepositorioClientes(); // capa de datos
        List<Cliente> ListaClientes;
        public ServicioClientes()
        {
            ListaClientes = repositorio.Consultar();
        }
        void Actualizar()
        {
            ListaClientes = repositorio.Consultar();
        }
        public string Guardar(Cliente cliente)
        {
            //validar
            return repositorio.Guardar(cliente);

        }
        public List<Cliente> Consultar()
        {
            Actualizar();
            return ListaClientes;
        }
        public Cliente BuscarId(string id)
        {
            foreach (var item in ListaClientes)
            {
                if (item.IdCliente==id)
                {
                    return item;
                }
            }
            return null;
        }
        public String Modificar()
        {
            return repositorio.Modificar(ListaClientes);
        }
        public String ModificarClientes()
        {

            return "";
        }
    }
}
