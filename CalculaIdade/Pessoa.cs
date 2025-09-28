using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaIdade
{
    public struct Pessoa
    {
        public string NomeCompleto { get; }
        public DateTime DataNascimento { get; }

        public Pessoa(string nomeCompleto, DateTime dataNascimento)
        {
            NomeCompleto = nomeCompleto ?? string.Empty;
            DataNascimento = dataNascimento;
        }
        
        public int CalcularIdade(DateTime referencia)
        {
            if (referencia < DataNascimento)
                throw new ArgumentException("Data de referência é anterior à data de nascimento.");

            int idade = referencia.Year - DataNascimento.Year;
            // Subtrai 1 se ainda não fez aniversário neste ano
            if (DataNascimento > referencia.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
