using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculos
{
    public class FilaVagas
    {
        //Atributos
        private Vagas vagaPrimeiro;
        private Vagas vagaUltimo;
        private Vagas filaVagaProximo;

        //Get e Set
        internal Vagas VagaPrimeiro
        {
            get
            {
                return vagaPrimeiro;
            }

            set
            {
                vagaPrimeiro = value;
            }
        }

        internal Vagas VagaUltimo
        {
            get
            {
                return vagaUltimo;
            }

            set
            {
                vagaUltimo = value;
            }
        }

        internal Vagas FilaVagaProximo
        {
            get
            {
                return filaVagaProximo;
            }

            set
            {
                filaVagaProximo = value;
            }
        }


        //Métodos
        public void adicionarVaga() {}
        public void removerVaga() {}
        public void toString() {}



        //Vagas Prim;
        //Vagas Ult;

        //public FilaVagas(string Area)
        //{
        //    Prim = new Vagas(Area, null, 0);
        //    Ult = Prim;
        //}
    }
}
