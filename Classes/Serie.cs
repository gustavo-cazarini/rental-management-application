using System;

namespace RMA
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int NoTemporada { get; set; }
        private int NoEpisodio { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int noTemporada, int noEpisodio)
        {
            this.Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            NoTemporada = noTemporada;
            NoEpisodio = noEpisodio;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Nº de Temporadas: " + this.NoTemporada + Environment.NewLine;
            retorno += "Nº de Episódios: " + this.NoEpisodio + Environment.NewLine;
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