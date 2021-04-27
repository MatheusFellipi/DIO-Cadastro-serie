using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
  public class SerieRepositorio : IRepositorio<Series>
  {
    private List<Series> listaSerie = new List<Series>();
    public void Atualiza(int id, Series entidade)
    {
      listaSerie[id] = entidade;
    }

    public void Exclui(int id)
    {
      listaSerie[id].excluir();
    }

    public void Insere(Series entidade)
    {
      listaSerie.Add(entidade);
    }

    public List<Series> Lista()
    {
      return listaSerie;
    }

    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Series RetornaPorId(int id)
    {
      try
      {
        return listaSerie[id];
      }
      catch (IndexOutOfRangeException message)
      {
        Console.WriteLine(message.Message);
        throw new ArgumentOutOfRangeException("index parameter is out of range.", message);
      }
    }
  }
}