/*
 * Integrantes:
 * 
 * Luiz Gustavo Verissimo Monteiro - CB3030326
 * 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBTSWE2_TP01.Negocio;

namespace CBTSWE2_TP01.Repositorio
{
    internal class BookRepositoryCSV
    {
        private static readonly string nomeArquivoCSV = "Repositorio\\ListaLivros.csv";
        private List<Book> livros;
        public BookRepositoryCSV()
        {
            livros = new List<Book>();
            using (var file = File.OpenText(nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textoLivro = file.ReadLine();
                    if (string.IsNullOrEmpty(textoLivro)) { continue; }

                    var infoLivro = textoLivro.Split(';');
                    int id = Convert.ToInt32(infoLivro[0]);
                    string nome = infoLivro[1];
                    string[] nomesAutores = infoLivro[2].Split(',');
                    Author[] autores = nomesAutores
                        .Select(nomeAutor => new Author(nomeAutor.Trim()))
                        .ToArray();
                    double preco = Convert.ToDouble(
                        infoLivro[3],
                        new CultureInfo("pt-BR")
                    );
                    int quantidade = Convert.ToInt32(infoLivro[4]);
                    var livro = new Book(
                        id,
                        nome,
                        autores,
                        preco,
                        quantidade
                    );
                    livros.Add(livro);
                };
            }
        }
        public IEnumerable<Book> Todos
        {
            get { return livros; }
        }
        public Book BuscarPorId(int id)
        {
            return livros.FirstOrDefault(livro => livro.Id == id);
        }
        public void Incluir(Book livro)
        {
            livros.Add(livro);

            using (var file = File.AppendText(nomeArquivoCSV))
            {
                file.WriteLine(
                    $"{livro.Id};{livro.Name};{livro.GetAuthorNames()};{livro.Price.ToString(CultureInfo.GetCultureInfo("pt-BR"))};{livro.Qty}"
                );
            }
        }
    }
}
