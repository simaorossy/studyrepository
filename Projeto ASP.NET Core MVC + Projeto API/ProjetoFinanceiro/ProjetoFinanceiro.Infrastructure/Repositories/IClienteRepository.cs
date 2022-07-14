using ProjetoFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        public void Salvar(Cliente cliente);
        public void Atualizar(Cliente cliente);
        public void Excluir(int id);
        public Cliente Pesquisar(int id);
        public List<Cliente> Listar();
    }
}
