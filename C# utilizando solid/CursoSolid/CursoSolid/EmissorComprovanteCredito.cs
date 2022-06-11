using System;
using System.Collections.Generic;
using System.Text;

namespace CursoSolid
{
    class EmissorComprovanteCredito : IEmissorComprovante
    {
        public Comprovante Emitir(PagamentoRequest pagamento)
        {
            Comprovante comprovante = new ComprovanteCredito(pagamento.parcelas, pagamento.valor.ToString(), pagamento.tipoPagamento, "Pagamento realizado");

            comprovante.usuarioLogado = UsuarioLogadoService.GetUsuarioLagado();


            ChecarLimite();

            DataSet.save(comprovante);


            return comprovante;
        }

        public string ChecarLimite()
        {
            return "negado";
        }
    }
}
