using System;
using System.Globalization;

namespace CalculaIdade
{    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Calculadora de Idade ===");
            Console.Write("Digite o nome completo: ");
            string nome = Console.ReadLine()?.Trim() ?? string.Empty;

            DateTime dataNasc;
            // Pede data de nascimento até que o usuário digite uma data válida
            while (true)
            {
                Console.Write("Digite a data de nascimento (dd/MM/yyyy): ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                // Formatos aceitos
                string[] formatos = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(input,
                                           formatos,
                                           new CultureInfo("pt-BR"),
                                           DateTimeStyles.None,
                                           out dataNasc))
                {
                    // Verifica se não é data futura
                    if (dataNasc > DateTime.Today)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("A data informada é no futuro. Por favor, digite uma data válida.");
                        Console.ResetColor();
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Formato inválido. Use dd/MM/yyyy");
                    Console.ResetColor();
                }
            }

            // Cria a struct Pessoa
            Pessoa pessoa = new Pessoa(nome, dataNasc);

            // Calcula idade
            DateTime hoje = DateTime.Today;
            int idade = pessoa.CalcularIdade(hoje);

            Console.WriteLine();
            Console.WriteLine($"Nome: {pessoa.NomeCompleto}");
            Console.WriteLine($"Data de Nascimento: {pessoa.DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Data atual: {hoje:dd/MM/yyyy}");
            Console.WriteLine($"Idade: {idade}");

            if (pessoa.CalcularIdade(hoje) >= 18)
            {
                Console.WriteLine("Situação: Maior de idade");
                Console.WriteLine("Permissão para solicitar carteira de habilitação: SIM");
            }
            else
            {
                Console.WriteLine("Situação: Menor de idade");
                Console.WriteLine("Permissão para solicitar carteira de habilitação: NÃO");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

