using System;

namespace RMA
{
    public class Filme : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private DateTime Duracao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Filme(int id, Genero genero, string titulo, string descricao, DateTime duracao, int ano)
        {
            this.Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Duracao = duracao;
            Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Duração: " + this.Duracao.ToLongTimeString() + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}