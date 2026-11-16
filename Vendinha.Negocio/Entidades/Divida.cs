using System;

namespace Vendinha.Negocio.Entidades
{
    public enum SituacaoDivida
    {
        Aberta = 0,
        Paga = 1
    }

    public class Divida
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public SituacaoDivida Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataPagamento { get; set; }

        public Divida()
        {
            Situacao = SituacaoDivida.Aberta;
            DataCriacao = DateTime.Now;
        }
    }
}
