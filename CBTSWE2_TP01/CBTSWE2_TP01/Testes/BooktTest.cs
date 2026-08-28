using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBTSWE2_TP01.Negocio;

namespace CBTSWE2_TP01.Testes
{
    internal class BooktTest
    {
        public static void Executar()
        {
            Console.WriteLine("=== INICIANDO TESTES DA CLASSE BOOK ===\n");

            // 1. Inicialização do Livro com 2 autores (Usando o construtor sem Qty)
            Book meuLivro = new(
                "C# Avançado",
                [
                    new Author("Jon Skeet", "jon@email.com", 'm'),
                    new Author("Jane Skeet", "jane@email.com", 'f')
                ],
                89.90
            );

            // 2. Testando os métodos "get" tradicionais
            Console.WriteLine($"Nome do Livro (getName): {meuLivro.getName()}");
            Console.WriteLine($"Preço Original (getPrice): {meuLivro.getPrice():C}");
            Console.WriteLine($"Quantidade Padrão (getQty): {meuLivro.getQty()}"); // Deve ser 0

            // 3. Testando os métodos "set" tradicionais e propriedades
            meuLivro.setPrice(79.90);
            meuLivro.setQty(15);
            Console.WriteLine($"\nNovo Preço (após setPrice): {meuLivro.getPrice():C}");
            Console.WriteLine($"Nova Quantidade (após setQty): {meuLivro.getQty()}");

            // 4. Testando o método getAuthorNames()
            Console.WriteLine($"\nNomes dos Autores (getAuthorNames): {meuLivro.GetAuthorNames()}");

            // 5. Testando o método getAuthors() e iterando sobre eles para testar a classe Author
            Console.WriteLine("\n--- Detalhes dos Autores (via getAuthors) ---");
            Author[] autores = meuLivro.getAuthors();
            foreach (Author autor in autores)
            {
                // Mostra o ToString() de cada autor individualmente
                Console.WriteLine(autor.ToString());
            }

            // 6. Testando o ToString() completo do Livro
            Console.WriteLine("\n--- ToString do Livro ---");
            Console.WriteLine(meuLivro.ToString());

            Console.WriteLine("\n=== FIM DOS TESTES ===");
        }
    }
}
