using ProjetoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Domain.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        
        
        
        public ClienteDto ConverterParaDto()
        {
            return new ClienteDto
            {
                ClienteId = this.ClienteId ,
                Cpf = this.Cpf,
                Nome = this.Nome
            };
        }

        public static List<ClienteDto> ConverterParaDto(List<Cliente> clientes )
        {
            List<ClienteDto> clientesDto = new List<ClienteDto>();

            foreach(var cliente in clientes)
            {
                var dto = cliente.ConverterParaDto();
                clientesDto.Add(dto);
            }

            return clientesDto;
        }


        //public ClienteDto ConverterParaDto(Cliente cliente)
        //{
        //    var clienteDto = new ClienteDto()
        //    {
        //        ClienteId = cliente.ClienteId,
        //        Cpf = cliente.Cpf,
        //        Nome = cliente.Nome
        //    };

        //    return clienteDto;
        //}



    }
}
