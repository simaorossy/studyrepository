using ProjetoFinanceiro.Domain.Entidades;
using ProjetoFinanceiro.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class FakeContextTeste
    {
        private readonly IContext _context;

        public FakeContextTeste()
        {
            _context = new FakeContext();
        }

        public void Execute()
        {
            TestarListagem();
            TestarInclusao();

        }


        public void TestarListagem()
        {
            var clientes = _context.ReadClientes();


            foreach(var i in clientes)
            {
                Console.WriteLine($"Id= {i.ClienteId}, Nome= {i.Nome}, CPF= {i.Cpf}");

            }
        }


        public void TestarInclusao()
        {

            Cliente cliente = new Cliente()
            {
                ClienteId = 15,
                Nome = "Simao",
                Cpf = "0037846746747"
            };

            _context.CreateCliente(cliente);
        }
    }
}
