using ProjetoFinanceiro.Domain.Entidades;
using ProjetoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Services.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> Listar()
        {

            return _clienteRepository.Listar();
        }

        public Cliente Pesquisar(int id)
        {

            return _clienteRepository.Pesquisar(id);
        }

        public void Atualizar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
        }

        public void Salvar(Cliente cliente)
        {
            _clienteRepository.Salvar(cliente);
        }

        public void Excluir(int id)
        {
            _clienteRepository.Excluir(id);
        }

    }
}
