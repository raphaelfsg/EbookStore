﻿using System;

namespace EbookStore
{
    class Program
    {

        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        ExcluirLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado!");
            Console.ReadLine();
        }

        private static void ListarLivros()
        {
            Console.WriteLine("Listar livros");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (var livro in lista)
            {
                var excluído = livro.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (excluído ? "*Excluido*i" : ""));
            }
        }

        private static async void InserirLivro()
        {
            Console.WriteLine("Inserir novo livro");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do livro: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do autor do livro: ");
            string entradaAutor = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do livro: ");
            string entradaDescricao = Console.ReadLine();

            Livro novoLivro = new Livro(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        autor: entradaAutor,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoLivro);
        }

        private static void AtualizarLivro()
        {
            Console.Write("Digite o id do livro a ser atualizado:");
            int indiceLivro = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do livro: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do autor do livro: ");
            string entradaAutor = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do livro: ");
            string entradaDescricao = Console.ReadLine();

            Livro atualizaLivro = new Livro(id: indiceLivro,
                                        genero: (Genero)entradaGenero,
                                        autor: entradaAutor,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceLivro, atualizaLivro);

        }

        private static void ExcluirLivro()
        {
            Console.Write("Digite o id do livro a ser excluído: ");
            int indiceLivro = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceLivro);
        }

        private static void VisualizarLivro()
        {
            Console.Write("Digite o id do livro: ");
            int indiceLivro = int.Parse(Console.ReadLine());

            var livro = repositorio.RetornaPorId(indiceLivro);

            Console.WriteLine(livro);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Ebook virtual");
            Console.WriteLine("\n========================\n========================\n");
            Console.WriteLine("Favor informar a opção desejada:");
            Console.WriteLine("1 - Listar livros");
            Console.WriteLine("2- Adicionar livro");
            Console.WriteLine("3- Atualizar livros disponíveis");
            Console.WriteLine("4- Excluir livro");
            Console.WriteLine("5- Visualizar livro");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}