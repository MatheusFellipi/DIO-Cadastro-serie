using System;

namespace Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();

    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

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
            break;
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void VisualizarSerie()
    {
      Console.WriteLine("Digite o id da seire: ");
      int indeceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indeceSerie);

      Console.WriteLine(serie);
    }

    private static void ExcluirSerie()
    {
      Console.WriteLine("Digite o id da seire: ");
      int indeceSerie = int.Parse(Console.ReadLine());

      Console.WriteLine("Tem certeza que quer excluir S ou N: ");
      string entradaOpcao = Console.ReadLine();
      if (entradaOpcao.ToUpper() == "S")
      {
        repositorio.Exclui(indeceSerie);
      }
    }

    private static void AtualizarSerie()
    {
      bool isAtt = true;

      Console.WriteLine("Digite o id da seire: ");
      int indeceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
      }
      AddouAtt(indeceSerie, isAtt);
    }

    private static void InserirSerie()
    {
      bool isAtt = false;
      int indeceSerie = -1;
      Console.WriteLine("Inserir nova serie");

      //estudar Emun.GetValues/GetName
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
      }
      AddouAtt(indeceSerie, isAtt);
    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar Series");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhum serei cadastrada");
        return;
      }
      foreach (var serie in lista)
      {
        var isExcluido = serie.retornaExcluirId();
        Console.WriteLine("#ID {0}: - {1} - {2}*", serie.retornaId(), serie.retornoTitulo(), isExcluido ? "Excluido" : "");
      }
    }
    private static void AddouAtt(int id, bool isAtt)
    {
      Console.WriteLine("Digite o gereno entre as opcoes acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Titulo da Serie: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de inicia da Serie: ");
      string entradaAno = Console.ReadLine();

      Console.WriteLine("Digite a Descricao da serie: ");
      string entradaDescricao = Console.ReadLine();

      if ((entradaTitulo.Length > 0) && (entradaDescricao.Length > 0) && (entradaAno.Length > 0))
      {
        if (isAtt)
        {
          Series novaSeries = new Series(id: id,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao
          );
          repositorio.Atualiza(id, novaSeries);
        }
        else
        {
          Series novaSeries = new Series(id: repositorio.ProximoId(),
          genero: (Genero)entradaGenero,
          titulo: entradaTitulo,
          ano: entradaAno,
          descricao: entradaDescricao
        );
          repositorio.Insere(novaSeries);
        }
      }
      else
      {
        Console.WriteLine("Entre com os dados validos");
      }


    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
