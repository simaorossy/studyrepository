using System;
using System.Collections.Generic;
using System.Text;

namespace CursoSolid
{
    interface IEmissorComprovante
    {

        public Comprovante Emitir(PagamentoRequest pagamento);

    }
}
