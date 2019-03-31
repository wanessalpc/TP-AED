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
        private FilaVagas filaVagaProximo;

        //Get e Set
        public Vagas VagaPrim
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
        public Vagas VagaUlt
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
        public FilaVagas FilaProx
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
        public void Adicionar() { }
        public void Remover() { }
        public void Buscar() { }
        public override string ToString()
        {
            return base.ToString();
        }

        //Construtor
        public FilaVagas(string Area)
        {
            VagaPrim = new Vagas(Area);
            VagaUlt = VagaPrim;
        }
    }
}
