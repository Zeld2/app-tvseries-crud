using DIO.Series.source.Classes;
using DIO.Series.source.Enum;
using static System.Console;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main()
        {
            string opcaoUsuario = "";

            while (opcaoUsuario != "X")
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        ContinueOrQuit();
                        break;
                    case "2":
                        InserirSerie();
                        ContinueOrQuit();
                        break;
                    case "3":
                        AtualizarSerie();
                        ContinueOrQuit();
                        break;
                    case "4":
                        ExcluirSerie();
                        ContinueOrQuit();
                        break;
                    case "5":
                        VisualizarSerie();
                        ContinueOrQuit();
                        break;
                    case "C":
                        Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
        }

        private static void ContinueOrQuit()
        {
            WriteLine("");
            WriteLine("-------------------------------------------------------------");
            WriteLine("Pressione qualquer tecla para continuar ou [Esc] para sair...");
            var keyOption = ReadKey();
            if (keyOption.Key == ConsoleKey.Escape)
            {
                //Encerra a aplicação
                Environment.Exit(0);
            }
        }
        private static void VisualizarSerie()
        {
            WriteLine("Qual o ID da série você deseja visualizar?");
            int indiceSerie = int.Parse(ReadLine());

            WriteLine(repositorio.RetornaPorId(indiceSerie));
        }

        private static void ExcluirSerie()
        {
            WriteLine("Qual o ID da série você deseja excluir?");
            int indiceSerie = int.Parse(ReadLine());

            repositorio.Exclui(indiceSerie);

            WriteLine("");
            WriteLine("Série excluída com sucesso!");

        }

        private static void AtualizarSerie()
        {
            WriteLine("Qual o ID da série você deseja atualizar?");
            int indiceSerie = int.Parse(ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine($"{i}- {Enum.GetName(typeof(Genero), i)}");
            }

            WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            WriteLine("Digite o título da Série: ");
            var entradaTitulo = ReadLine();

            WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(ReadLine());

            WriteLine("Digite a descrição da série: ");
            var entradaDescricao = ReadLine();

            Serie atualizaSerie = new Serie(repositorio.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

            WriteLine("");
            WriteLine("Série atualizada com sucesso!");

        }

        private static void InserirSerie()
        {
            WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine($"{i}- {Enum.GetName(typeof(Genero), i)}");
            }

            WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            WriteLine("Digite o título da Série: ");
            var entradaTitulo = ReadLine();

            WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(ReadLine());

            WriteLine("Digite a descrição da série: ");
            var entradaDescricao = ReadLine();

            Serie novaserie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insere(novaserie);

            WriteLine("");
            WriteLine("Série adicionada com sucesso!");

        }

        private static void ListarSeries()
        {
            WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                if(!serie.Excluido)
                {
                WriteLine($"ID {serie.retornaId()}: - {serie.retornaTitulo()}");
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            WriteLine();
            WriteLine("Lista das melhores séries!!! Opinião do autor: Matheus D.");

            WriteLine("Informe a opção desejada:");
            WriteLine("1- Listar Série");
            WriteLine("2- Inserir nova série");
            WriteLine("3- Atualizar série");
            WriteLine("4- Excluir série");
            WriteLine("5- Visualizar série");
            WriteLine("C- Limpar tela");
            WriteLine("X- Sair ");
            WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            WriteLine();
            return opcaoUsuario;
        }
    }
}