using System.Threading;
using System;

namespace RMA
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static AnimeRepositorio animeRepositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            ObterOpcaoUsuario();
        }
        
        private static void ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("RAM - Aplicação de Gerência de Locadora");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Série");
            Console.WriteLine("2 - Filme");
            Console.WriteLine("3 - Anime");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        OpcaoSerie();
                        break;
                    case "2":
                        OpcaoFilme();
                        break;
                    case "3":
                        OpcaoAnime();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = Console.ReadLine().ToUpper();
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            
            Sair();
        }


        // #Série
        private static void OpcaoSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Séries selecionado");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("R - Voltar ao menu principal");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = Console.ReadLine().ToUpper();
                        break;
                    case "R":
                        ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Sair();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
            Console.ReadLine();
            OpcaoSerie();
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o número de Temporadas: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o número de episódios: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        noTemporada: entradaTemporada,
                                        noEpisodio: entradaEpisodio);

            repositorio.Insere(novaSerie);
            Console.WriteLine("Série inserida com sucesso!");
            Console.ReadLine();
            OpcaoSerie();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o número de temporadas: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o número de episódios: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            noTemporada: entradaTemporada,
                                            noEpisodio: entradaEpisodio);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine("Série atualizada!");
            Console.ReadLine();
            OpcaoSerie();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Você tem certeza da exclusão dessa série?" +
                            Environment.NewLine +
                            "Digite \"s\" para sim ou \"n\" para não: ");

            if (Console.ReadLine().ToUpper() == "S")
            {
                repositorio.Exclui(indiceSerie);
            }
            Console.ReadLine();
            OpcaoSerie();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.ReadLine();
            OpcaoSerie();
        }


        // #Filme
        private static void OpcaoFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes selecionado");
            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("R - Voltar ao menu principal");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = Console.ReadLine().ToUpper();
                        break;
                    case "R":
                        ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Sair();
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = filmeRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
            Console.ReadLine();
            OpcaoFilme();
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Duração do filme: ");
            Console.WriteLine("Exemplo: 02:04:00");
            DateTime entradaDuracao = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        duracao: entradaDuracao,
                                        ano: entradaAno);

            filmeRepositorio.Insere(novoFilme);
            Console.WriteLine("Filme inserido com sucesso!");
            Console.ReadLine();
            OpcaoFilme();
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Duração do Filme: ");
            DateTime entradaDuracao = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            duracao: entradaDuracao,
                                            ano: entradaAno);

            filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
            Console.WriteLine("Filme atualizado!");
            Console.ReadLine();
            OpcaoFilme();
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Console.WriteLine("Você tem certeza da exclusão desse filme?" +
                            Environment.NewLine +
                            "Digite \"s\" para sim ou \"n\" para não: ");

            if (Console.ReadLine().ToUpper() == "S")
            {
                filmeRepositorio.Exclui(indiceFilme);
            }
            Console.ReadLine();
            OpcaoFilme();
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = filmeRepositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
            Console.ReadLine();
            OpcaoFilme();
        }


        // #Anime
        private static void OpcaoAnime()
        {
            Console.WriteLine();
            Console.WriteLine("Animes selecionado");
            Console.WriteLine("1 - Listar animes");
            Console.WriteLine("2 - Inserir novo anime");
            Console.WriteLine("3 - Atualizar anime");
            Console.WriteLine("4 - Excluir anime");
            Console.WriteLine("5 - Visualizar anime");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("R - Voltar ao menu principal");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = Console.ReadLine().ToUpper();
                        break;
                    case "R":
                        ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Sair();
        }

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar Animes");

            var lista = animeRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrado");
            }

            foreach (var anime in lista)
            {
                var excluido = anime.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
            Console.ReadLine();
            OpcaoAnime();
        }

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo anime");

            foreach (int i in Enum.GetValues(typeof(GeneroAnime)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroAnime), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Nº de Temporadas: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nº de Episódios: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Anime novoAnime = new Anime(id: animeRepositorio.ProximoId(),
                                        genero: (GeneroAnime)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        noTemporada: entradaTemporada,
                                        noEpisodio: entradaEpisodio);

            animeRepositorio.Insere(novoAnime);
            Console.WriteLine("Anime inserido com sucesso!");
            Console.ReadLine();
            OpcaoAnime();
        }

        private static void AtualizarAnime()
        {
            Console.WriteLine("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(GeneroAnime)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroAnime), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Nº de Temporadas: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nº de Episódios: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                            genero: (GeneroAnime)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            noTemporada: entradaTemporada,
                                            noEpisodio: entradaEpisodio);

            animeRepositorio.Atualiza(indiceAnime, atualizaAnime);
            Console.WriteLine("Anime atualizado!");
            Console.ReadLine();
            OpcaoAnime();
        }

        private static void ExcluirAnime()
        {
            Console.Write("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            Console.WriteLine("Você tem certeza da exclusão desse anime?" +
                            Environment.NewLine +
                            "Digite \"s\" para sim ou \"n\" para não: ");

            if (Console.ReadLine().ToUpper() == "S")
            {
                animeRepositorio.Exclui(indiceAnime);
            }
            Console.ReadLine();
            OpcaoAnime();
        }

        private static void VisualizarAnime()
        {
            Console.Write("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = animeRepositorio.RetornaPorId(indiceAnime);

            Console.WriteLine(anime);
            Console.ReadLine();
            OpcaoAnime();
        }

        private static void Sair()
        {
            Console.WriteLine("Obrigado por usar o aplicativo.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
