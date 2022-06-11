using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CursoSolid
{
    public class Comprovante
    {

        public Comprovante (string descricao, string valor, TipoPagamento tipoPagamento)
        {

            this.descricao = descricao;
            this.valor = valor;
            this.tipoPagamento = tipoPagamento;

        }

        public string usuarioLogado { get; set; }

        public string descricao { get; set; }

        public string valor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoPagamento tipoPagamento { get; set; }


    }
}
