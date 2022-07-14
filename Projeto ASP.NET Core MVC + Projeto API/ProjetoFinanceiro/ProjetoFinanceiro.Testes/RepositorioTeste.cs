using ProjetoFinanceiro.Domain.Entidades;
using ProjetoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class RepositorioTeste
    {
        private readonly IClienteRepository _clienteRepository;

        public RepositorioTeste(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

        }

        public void Execute()
        {
            try
            {
                ValidarListagemClientes();
                ValidarPesquisaCLiente();
                ValidarCadastroCliente();
                ValidarAtualizaçãoCliente();
                ValidarExclusaoCliente();
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        private void ValidarListagemClientes()
        {
            List<Cliente> clientes = _clienteRepository.Listar();

            foreach(Cliente cliente in clientes)
            {
                Console.WriteLine($"Id= {cliente.ClienteId}, Nome= {cliente.Nome}");
            }           
        }

        private void ValidarPesquisaCLiente()
        {
            int id = 1;
            Cliente cliente =_clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id= {cliente.ClienteId}, Nome= {cliente.Nome}");

        }

        private void ValidarCadastroCliente()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 85,
                Nome = "Saulo",
                Cpf = "77356839573"
            };

            _clienteRepository.Salvar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(cliente.ClienteId);
            Console.WriteLine($"Id= {objPesquisa.ClienteId}, Nome= {objPesquisa.Nome}");
        }

        private void ValidarAtualizaçãoCliente()
        {

            Cliente objCliente =_clienteRepository.Pesquisar(1);
            objCliente.Nome = "Savio";

            _clienteRepository.Atualizar(objCliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(objCliente.ClienteId);
            Console.WriteLine($"Id= {objPesquisa.ClienteId}, Nome= {objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            int id = 1;
            _clienteRepository.Excluir(id);

            Cliente cliente = _clienteRepository.Pesquisar(id);
        }



    }
}
