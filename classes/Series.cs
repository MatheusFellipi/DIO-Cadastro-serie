using System;

namespace Series
{
  public class Series : EntidadeBase
  {

    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private string Ano { get; set; }

    private bool IsExcluir { get; set; }

    public Series(int id,Genero genero, string titulo, string descricao, string ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.IsExcluir = false;
    }
    public override string ToString()
    {
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
      retorno += "Excluido: " + this.IsExcluir;
      return retorno;
    }
    public string retornoTitulo()
    {
      return this.Titulo;
    }
    internal int retornaId()
    {
      return this.Id;
    }
      internal bool retornaExcluirId()
    {
      return this.IsExcluir;
    }

    public void excluir()
    {
      this.IsExcluir = true;
    }
  }
}