using System;

namespace DIO.Series
{
    class Program
    {
        
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string[] args)
        
        {

            //Serie MeuObjeto = new Serie ();
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                NewMethod(opcaoUsuario);
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por Usar nossos Serviços!");
        }

        private static void NewMethod(string opcaoUsuario)
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
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
                
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries ao Seu dispor!!!");
            Console.WriteLine("Informe a Opção Desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }



        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = Repositorio.Lista();

            if (lista.Count==0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var Serie in lista)
            {
                var Excluido = Serie.retornaExcluido();
                Console.WriteLine ("#ID {0}: -{1} {2}", Serie.retornaId(), Serie.retornaTitulo(),(Excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: Repositorio.ProximoId(),
                                        Genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);
            Repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        Genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);
            Repositorio.Atualiza(indiceSerie, atualizaSerie);

        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = Repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }


    }
}
