using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculos
{
    public class GerenciadorVagas
    {
        //Atributos
        private FilaVagas filaPrim;
        private FilaVagas filaUlt;

        //Get e Set
        public FilaVagas FilaPrim
        {
            get { return filaPrim; }
            set { filaPrim = value; }
        }
        public FilaVagas FilaUlt
        {
            get { return filaUlt; }
            set { filaUlt = value; }
        }

        //Métodos
        public void AdicionarVaga()
        {

        }
        
        public void RemoverVaga()
        {

        }

        public void BuscarFila()
        {

        }

        //Construtor
        public GerenciadorVagas()
        {
            FilaPrim = new FilaVagas(null);
            FilaUlt = FilaPrim;
        }
    }
}
