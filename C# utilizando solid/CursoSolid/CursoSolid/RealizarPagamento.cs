using System;
using System.Collections.Generic;
using System.Text;

namespace CursoSolid
{
    class RealizarPagamento
    {

        private IEmissorComprovante _emissorComprovante;

        public RealizarPagamento(IEmissorComprovante emissorComprovante)
        {
            this._emissorComprovante = emissorComprovante;
        }

        public Comprovante RegistrarPagamento (PagamentoRequest pagamento)
        {


            Comprovante comprovante = _emissorComprovante.Emitir(pagamento);

            return comprovante;
        }        

    }
}
