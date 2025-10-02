using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Biblitoeca
{
    class Exemplar
    {
        //propriedades
        private int _tombo;
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();

        //Construtor
        public Exemplar(int tombo)
        {
            Tombo = tombo;
        }

        //getters e setters
        public int Tombo
        {
            get { return _tombo; }
            set { _tombo = value; }
        }

        public List<Emprestimo> Emprestimos
        {
            get { return _emprestimos; }
            set { _emprestimos = value; }
        }

        //Metodos publicos
        public bool emprestar()
        {
            bool saida = false;

            if(disponivel() == true)
            {
                DateTime dtEmprestimo = DateTime.Now;

                Emprestimos.Add(new Emprestimo(dtEmprestimo));

                saida = true;
            }

            return saida;

        }

        public bool disponivel()
        {
            bool saida = false;

            if(Emprestimos.Count == 0)
            {
                saida = true;
            }
            else
            {
                Emprestimo ultimo = Emprestimos.Last();

                if (ultimo.DtDevolucao != null)
                {
                    saida = true;
                }

            }

            return saida;

        }

    }
}
