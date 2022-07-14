using ProjetoFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Context
{
    public interface IContext
    {        
        public void CreateCliente(Cliente cliente);
        public List<Cliente> ReadClientes();
        public Cliente ReadCliente(int id);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);
    }
}
