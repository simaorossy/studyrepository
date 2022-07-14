using ProjetoFinanceiro.Domain.Entidades;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class ServicoTeste
    {
        private readonly ClienteService _clienteService;

        public ServicoTeste(ClienteService clienteservice)
        {
            _clienteService = clienteservice;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarListagemClientes()
        {
            Console.WriteLine("Teste Camada de Serviço: ValidarListagemClientes");

            List<Cliente> clientes = _clienteService.Listar();

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Id= {cliente.ClienteId}, Nome= {cliente.Nome}");
            }
        }

        private void ValidarPesquisaCLiente()
        {
            Console.WriteLine("Teste Camada de Serviço: ValidarPesquisaCLiente");

            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id= {cliente.ClienteId}, Nome= {cliente.Nome}");

        }

        private void ValidarCadastroCliente()
        {
            Console.WriteLine("Teste Camada de Serviço: ValidarCadastroCliente");

            Cliente cliente = new Cliente()
            {
                ClienteId = 85,
                Nome = "Saulo",
                Cpf = "77356839573"
            };

            _clienteService.Salvar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(cliente.ClienteId);
            Console.WriteLine($"Id= {objPesquisa.ClienteId}, Nome= {objPesquisa.Nome}");
        }

        private void ValidarAtualizaçãoCliente()
        {
            Console.WriteLine("Teste Camada de Serviço: ValidarAtualizaçãoCliente");

            Cliente objCliente = _clienteService.Pesquisar(1);
            objCliente.Nome = "Savio";

            _clienteService.Atualizar(objCliente);

            Cliente objPesquisa = _clienteService.Pesquisar(objCliente.ClienteId);
            Console.WriteLine($"Id= {objPesquisa.ClienteId}, Nome= {objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            Console.WriteLine("Teste Camada de Serviço: ValidarExclusaoCliente");

            int id = 1;
            _clienteService.Excluir(id);

            Cliente cliente = _clienteService.Pesquisar(id);
        }

    }
}
