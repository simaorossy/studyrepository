using System;
using System.Collections.Generic;
using System.Text;

namespace CursoSolid
{
    class ComprovanteCredito : Comprovante
    {

        public int parcelas { get; set; }

        public ComprovanteCredito(int parcelas, string valor, TipoPagamento tipoPagamento, string descricao) : base(descricao, valor, tipoPagamento)
        {
            this.parcelas = parcelas;
        }

    }
}
