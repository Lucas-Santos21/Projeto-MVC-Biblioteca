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

        //Metodos Publicos
        public bool disponivel()
        {
            bool saida = false;

            if (Emprestimos.Count == 0)
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


        public bool emprestar()
        {
            bool saida = false;

            if(disponivel() == true)
            {
                DateTime dtEmprestimo = DateTime.Now;

                Emprestimos.Add(new Emprestimo(dtEmprestimo));

                saida = true;

                Console.WriteLine("Emprestimo realizado");
            }
            else
            {
                Console.WriteLine("Exemplar não disponivel para emprestimo");
            }

            return saida;

        }

       public bool devolver()
        {
            bool saida = false;

            if(Emprestimos.Count > 0)
            {
                Emprestimo ultimo = Emprestimos.Last();

                if (ultimo.DtDevolucao == null)
                {
                    Emprestimos[Emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                    saida = true;
                }
                else
                {
                    Console.WriteLine("Este exemplar ja foi devolvido");
                }

            }
            else
            {
                Console.WriteLine("Não a emprestimos registrados para este exemplar");
            }

            return saida;

        }

        public int qtdeEmprestimos()
        {
            return Emprestimos.Count;
        }

    }
}
