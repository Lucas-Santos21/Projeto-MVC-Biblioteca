using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Biblitoeca
{
    class Livro
    {
        //Propriedades
        private int _isbn;
        private string _titulo;
        private string _autor;
        private string _editora;
        private List<Exemplar> _exemplares = new List<Exemplar>();

        //Construtor
        public Livro(int isbn, string titulo, string autor, string editora)
        {

            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;

        }

        //Getters e Setters
        public int Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Editora
        {
            get { return _editora; }
            set { _editora = value; }
        }

        public List<Exemplar> Exemplares
        {
            get { return _exemplares; }
            set { _exemplares = value; }
        }

        //Metodos Publicos
        public void adicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
            Console.WriteLine($"Exemplar {exemplar.Tombo} adicionado à lista!");
        }

        public int qtdeExemplares()
        {
            return Exemplares.Count; ;
        }

        public int qtdeDisponiveis()
        {
            int qtde = 0;

                foreach (Exemplar e in Exemplares)
                {
                    if (e.disponivel())
                    {
                        qtde++;
                    }

                }

            return qtde;
        }

        public int qtdeEmprestimos()
        {
            int qtde = 0;

                foreach (Exemplar e in Exemplares)
                {
                    qtde += e.qtdeEmprestimos();
                }

            return qtde;
        }

        public double percDisponibilidade()
        {
            double perc;

            if(Exemplares.Count > 0)
            {
                double numDisponiveis = qtdeDisponiveis();

                perc = (numDisponiveis / Exemplares.Count) * 100;
            }
            else
            {
                perc = 0;
            }

            return perc;            
        }

    }
}
