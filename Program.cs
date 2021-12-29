using System.Threading;
using System;

namespace RMA
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            ObterOpcaoUsuario();
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
                        //OpcaoFilme();
                        break;
                    case "3":
                        //OpcaoAnime();
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

        private static void Sair()
        {
            Console.WriteLine("Obrigado por usar o aplicativo.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
