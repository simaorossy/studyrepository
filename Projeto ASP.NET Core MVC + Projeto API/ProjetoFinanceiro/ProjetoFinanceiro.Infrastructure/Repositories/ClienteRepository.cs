using ProjetoFinanceiro.Domain.Entidades;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Domain.Setup;
using ProjetoFinanceiro.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IContext _context;

        public ClienteRepository()
        {
            if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                _context = new FakeContext();
            }
        }

        public void Atualizar(Cliente cliente)
        {
            _context.UpdateCliente(cliente);
        }

        public void Excluir(int id)
        {
            _context.DeleteCliente(id);
        }

        public List<Cliente> Listar()
        {
           return _context.ReadClientes();
        }

        public Cliente Pesquisar(int id)
        {
            return _context.ReadCliente(id);
        }

        public void Salvar(Cliente cliente)
        {
            _context.CreateCliente(cliente);
        }
    }
}
