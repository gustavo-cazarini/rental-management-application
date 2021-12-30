using System;
using System.Collections.Generic;
using RMA.Interfaces;

namespace RMA
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> listaAnime = new List<Anime>();
        public void Atualiza(int id, Anime objeto)
        {
            listaAnime[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAnime[id].Excluir();
            Console.WriteLine("Anime excluído com sucesso!");
        }

        public void Insere(Anime objeto)
        {
            listaAnime.Add(objeto);
        }

        public List<Anime> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;
        }

        public Anime RetornaPorId(int id)
        {
            return listaAnime[id];
        }
    }
}