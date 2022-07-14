using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class DominiosTeste
    {
        public void Execute()
        {
            TestaEntidade();
            TestarDto();
            TestaConversaoEntidadeParaDto();
            TestaConversaoDtoParaEntidade();
        }


        public void TestaEntidade()
        {

            Cliente cliente = new Cliente()
            {
                ClienteId= 1,
                Nome = "Simao",
                Cpf = "00389213241"
            };

            Console.WriteLine("Id= "+cliente.ClienteId+" Nome= " +cliente.Nome+" Cpf= " + cliente.Cpf);

        }

        public void TestarDto()
        {
            ClienteDto cliente = new ClienteDto()
            {
                ClienteId = 1,
                Nome = "Simao",
                Cpf = "00389213241"
            };

            Console.WriteLine("Id= " + cliente.ClienteId + " Nome= " + cliente.Nome + " Cpf= " + cliente.Cpf);

        }


        public void TestaConversaoEntidadeParaDto()
        {

            Cliente cliente = new Cliente()
            {
                ClienteId = 1,
                Nome = "Simao",
                Cpf = "00389213241"
            };

            ClienteDto dto = cliente.ConverterParaDto();


            Console.WriteLine("Id= " + dto.ClienteId + " Nome= " + dto.Nome + " Cpf= " + dto.Cpf);

        }


        public void TestaConversaoDtoParaEntidade()
        {

            ClienteDto cliente = new ClienteDto()
            {
                ClienteId = 1,
                Nome = "Simao",
                Cpf = "00389213241"
            };

            Cliente entidade = cliente.ConverterParaEntidade();


            Console.WriteLine("Id= " + entidade.ClienteId + " Nome= " + entidade.Nome + " Cpf= " + entidade.Cpf);

        }



    }
}
