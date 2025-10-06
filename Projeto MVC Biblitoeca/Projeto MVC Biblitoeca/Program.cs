using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Biblitoeca
{
    class Program
    {
        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "0":
                        sair = true;
                        break;

                    case "1":
                        // Adicionar livro
                        Console.Write("ISBN: ");
                        int isbn = int.Parse(Console.ReadLine());
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();

                        Livro novoLivro = new Livro(isbn, titulo, autor, editora);
                        biblioteca.adicionar(novoLivro);
                        break;

                    case "2":
                        // Pesquisar livro sintético
                        Console.Write("Informe o ISBN do livro: ");
                        int isbnBusca = int.Parse(Console.ReadLine());
                        Livro livroBusca = biblioteca.pesquisar(new Livro(isbnBusca, "", "", ""));
                        if (livroBusca != null)
                        {
                            Console.WriteLine($"\nTítulo: {livroBusca.Titulo}");
                            Console.WriteLine($"Autor: {livroBusca.Autor}");
                            Console.WriteLine($"Editora: {livroBusca.Editora}");
                            Console.WriteLine($"Exemplares: {livroBusca.qtdeExemplares()}");
                            Console.WriteLine($"Disponíveis: {livroBusca.qtdeDisponiveis()}");
                            Console.WriteLine($"Empréstimos: {livroBusca.qtdeEmprestimos()}");
                            Console.WriteLine($"% Disponibilidade: {livroBusca.percDisponibilidade():F2}%");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "3":
                        // Pesquisar livro analítico
                        Console.Write("Informe o ISBN do livro: ");
                        int isbnBusca2 = int.Parse(Console.ReadLine());
                        Livro livroBusca2 = biblioteca.pesquisar(new Livro(isbnBusca2, "", "", ""));
                        if (livroBusca2 != null)
                        {
                            Console.WriteLine($"\nTítulo: {livroBusca2.Titulo}");
                            Console.WriteLine($"Autor: {livroBusca2.Autor}");
                            Console.WriteLine($"Editora: {livroBusca2.Editora}");
                            Console.WriteLine($"Exemplares: {livroBusca2.qtdeExemplares()}");
                            Console.WriteLine($"Disponíveis: {livroBusca2.qtdeDisponiveis()}");
                            Console.WriteLine($"Empréstimos: {livroBusca2.qtdeEmprestimos()}");
                            Console.WriteLine($"% Disponibilidade: {livroBusca2.percDisponibilidade():F2}%");

                            Console.WriteLine("\nDetalhes dos exemplares:");
                            foreach (Exemplar e in livroBusca2.Exemplares)
                            {
                                Console.WriteLine($"Tombo: {e.Tombo}, Disponível: {e.disponivel()}, Total de empréstimos: {e.qtdeEmprestimos()}");
                                foreach (Emprestimo emp in e.Emprestimos)
                                {
                                    Console.WriteLine($"  Emprestimo: {emp.DtEmprestimo}, Devolução: {(emp.DtDevolucao.HasValue ? emp.DtDevolucao.ToString() : "Não devolvido")}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "4":
                        // Adicionar exemplar
                        Console.Write("Informe o ISBN do livro: ");
                        int isbnEx = int.Parse(Console.ReadLine());
                        Livro livroEx = biblioteca.pesquisar(new Livro(isbnEx, "", "", ""));
                        if (livroEx != null)
                        {
                            Console.Write("Informe o tombo do exemplar: ");
                            int tombo = int.Parse(Console.ReadLine());
                            Exemplar novoEx = new Exemplar(tombo);
                            livroEx.adicionarExemplar(novoEx);
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "5":
                        // Registrar empréstimo
                        Console.Write("Informe o ISBN do livro: ");
                        int isbnEmp = int.Parse(Console.ReadLine());
                        Livro livroEmp = biblioteca.pesquisar(new Livro(isbnEmp, "", "", ""));
                        if (livroEmp != null)
                        {
                            // Procurar o primeiro exemplar disponível
                            Exemplar exemplarDisp = livroEmp.Exemplares.FirstOrDefault(ex => ex.disponivel());
                            if (exemplarDisp != null)
                            {
                                exemplarDisp.emprestar();
                            }
                            else
                            {
                                Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "6":
                        // Registrar devolução
                        Console.Write("Informe o ISBN do livro: ");
                        int isbnDev = int.Parse(Console.ReadLine());
                        Livro livroDev = biblioteca.pesquisar(new Livro(isbnDev, "", "", ""));
                        if (livroDev != null)
                        {
                            // Procurar primeiro exemplar com empréstimo em aberto
                            Exemplar exemplarEmp = livroDev.Exemplares.FirstOrDefault(ex => !ex.disponivel());
                            if (exemplarEmp != null)
                            {
                                exemplarEmp.devolver();
                            }
                            else
                            {
                                Console.WriteLine("Não há exemplares para devolver.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");

        }
    }
}
