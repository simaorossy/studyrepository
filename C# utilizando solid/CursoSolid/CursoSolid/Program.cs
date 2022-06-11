using Newtonsoft.Json;
using System;

namespace CursoSolid
{
    class Program
    {
        static void Main(string[] args)
        {
            RealizarPagamentoDebito();


            RealizarPagamentoCredito();

        }


        public static void RealizarPagamentoDebito()
        {
            RealizarPagamento realizarPagamento = new RealizarPagamento(new EmissorComprovanteDebito());

            PagamentoRequest pagamentoRequest = createPagamentoDebitoRequest();

            Comprovante comprovante = realizarPagamento.RegistrarPagamento(pagamentoRequest);

            Console.WriteLine(JsonConvert.SerializeObject(comprovante, new Newtonsoft.Json.Converters.StringEnumConverter()));

        }


        public static void RealizarPagamentoCredito()
        {
            RealizarPagamento realizarPagamento = new RealizarPagamento(new EmissorComprovanteCredito());

            PagamentoRequest pagamentoRequest = createPagamentoRequestCredito();

            Comprovante comprovante = realizarPagamento.RegistrarPagamento(pagamentoRequest);

            Console.WriteLine(JsonConvert.SerializeObject(comprovante, new Newtonsoft.Json.Converters.StringEnumConverter()));

        }



        public static PagamentoRequest createPagamentoDebitoRequest()
        {

            return new PagamentoRequest(TipoPagamento.DEBITO, 200);

        }

        public static PagamentoRequest createPagamentoRequestCredito()
        {

            return new PagamentoRequest(TipoPagamento.CREDITO, 200, 4);

        }


    }
}
