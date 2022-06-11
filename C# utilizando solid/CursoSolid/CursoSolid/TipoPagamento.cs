using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CursoSolid
{
    public enum TipoPagamento
    {
        [EnumMember(Value = "Debito")]
        DEBITO,
        [EnumMember(Value = "Credito")]
        CREDITO

    }
}
