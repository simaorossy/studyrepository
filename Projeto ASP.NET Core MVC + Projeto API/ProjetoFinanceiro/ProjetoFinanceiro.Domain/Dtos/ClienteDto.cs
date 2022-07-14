using ProjetoFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Domain.Dtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }


        public Cliente ConverterParaEntidade()
        {
            return new Cliente
            {
                ClienteId = this.ClienteId,
                Cpf = this.Cpf,
                Nome = this.Nome
            };
        }

        public static List<Cliente> ConverterParaEntidade(List<ClienteDto> clientesDto)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (var clienteDto in clientesDto)
            {
                var cliente = clienteDto.ConverterParaEntidade();
                clientes.Add(cliente);
            }

            return clientes;
        }



    }
}
