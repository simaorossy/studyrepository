using ProjetoFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Context
{
    public class FakeContext : IContext
    {
        private List<Cliente> _clientes;

        public FakeContext()
        {
            LoadData();
        }

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }               

        public Cliente ReadCliente(int id)
        {
            var result = _clientes.FirstOrDefault(x => x.ClienteId == id);
            return result;
        }

        public List<Cliente> ReadClientes()
        {
            var result = _clientes.OrderBy(x => x.ClienteId).ToList();
            return result;
        }

        public void UpdateCliente(Cliente cliente)
        {
            var objCliente = ReadCliente(cliente.ClienteId);
            _clientes.Remove(objCliente);

            objCliente = new Cliente()
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf
            };
            _clientes.Add(objCliente);


        }

        public void DeleteCliente(int id)
        {
            var objCliente = ReadCliente(id);
            if(objCliente !=null)
                _clientes.Remove(objCliente);
        }

        private void LoadData()
        {
            _clientes = new List<Cliente>();

            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "784784541526"
            };

            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 2,
                Nome = "Maria",
                Cpf = "54263258967"
            };

            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 3,
                Nome = "Antonio",
                Cpf = "65201236589"
            };

            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 4,
                Nome = "Marcio",
                Cpf = "0365241526"
            };

            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 5,
                Nome = "Carol",
                Cpf = "968454152632"
            };

            _clientes.Add(cliente);

        }
    }
}
