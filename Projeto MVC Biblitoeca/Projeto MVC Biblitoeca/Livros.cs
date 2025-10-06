using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Biblitoeca
{
    class Livros
    {
        //Propriedade
        private List<Livro> _acervo = new List<Livro>();

        //Construtor
        public Livros()
        {
        }

        //Getters e Setters
        public List<Livro> Acervo
        {
            get { return _acervo; }
            set { _acervo = value; }
        }

        //Metodos Publicos
        public void adicionar(Livro livro)
        {
            if(Acervo.Count == 0)
            {
                Acervo.Add(livro);
            }
            else 
            {
                if (!Acervo.Contains(livro))
                {
                    Acervo.Add(livro);
                }
                else
                {
                    Console.WriteLine("Este livro ja esta cadastrado no acervo da biblioteca");
                }

            }
        }

        public Livro pesquisar(Livro livro)
        {
            Livro saida = null;

            foreach(Livro teste in Acervo)
            {
                if(livro.Isbn == teste.Isbn)
                {
                    saida = teste;
                    break;
                }

            }

            return saida;

        }

    }
}
