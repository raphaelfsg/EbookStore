using System;
using System.Collections.Generic;
using EbookStore.Interfaces;

namespace EbookStore
{
    public class LivroRepositorio : IRepositorio<Livro>
    {
        private List<Livro> listaLivro = new List<Livro>();
        public void Atualiza(int id, Livro entidade)
        {
            listaLivro[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaLivro[id].Excluir();
        }

        public void Insere(Livro entidade)
        {
            listaLivro.Add(entidade);
        }

        public List<Livro> Lista()
        {
            return listaLivro;
        }

        public int ProximoId()
        {
            return listaLivro.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listaLivro[id];
        }
    }
}