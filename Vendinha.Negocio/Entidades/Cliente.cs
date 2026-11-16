using System;
using System.Collections.Generic;
using System.Linq;

namespace Vendinha.Negocio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public List<Divida> Dividas { get; set; }

        public int Idade
        {
            get
            {
                DateTime hoje = DateTime.Today;
                int idade = hoje.Year - DataNascimento.Year;

                // Se o aniversário ainda não aconteceu, a idade é um ano menor.
                if (DataNascimento.Date > hoje.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
        }

        public decimal TotalDividas
        {
            get
            {
                if (Dividas == null)
                {
                    return 0;
                }

                return Dividas
                    .Where(divida => divida.Situacao == SituacaoDivida.Aberta)
                    .Sum(divida => divida.Valor);
            }
        }

        public Cliente()
        {
            Dividas = new List<Divida>();
            Nome = string.Empty;
            Cpf = string.Empty;
            Email = string.Empty;
        }
    }
}
