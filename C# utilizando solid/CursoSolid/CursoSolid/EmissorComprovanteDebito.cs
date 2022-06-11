using System;
using System.Collections.Generic;
using System.Text;

namespace CursoSolid
{
    class EmissorComprovanteDebito : IEmissorComprovante
    {
        public Comprovante Emitir(PagamentoRequest pagamento)
        {
            Comprovante comprovante = new Comprovante("Pagamento realizado", pagamento.valor.ToString(), pagamento.tipoPagamento);

            comprovante.usuarioLogado = UsuarioLogadoService.GetUsuarioLagado();

            DataSet.save(comprovante);


            return comprovante;
        }
    }
}
