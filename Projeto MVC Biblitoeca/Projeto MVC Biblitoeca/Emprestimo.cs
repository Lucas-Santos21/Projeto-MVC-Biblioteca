using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Biblitoeca
{
    class Emprestimo
    {
        //propriedades
        private DateTime _dtEmprestimo;
        private DateTime? _dtDevolucao;

        //Construtor
        public Emprestimo(DateTime dtEmprestimo, DateTime? dtDevolucao = null)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }

        //Getters e Setters
        public DateTime DtEmprestimo
        {
            get { return _dtEmprestimo; }
            set { _dtEmprestimo = value; }
        }

        public DateTime? DtDevolucao
        {
            get { return _dtDevolucao; }
            set { _dtDevolucao = value; }
        }

    }
}
