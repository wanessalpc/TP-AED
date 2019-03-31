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
        private Vagas vagaPrim;
        private Vagas vagaUlt;
        private FilaVagas filaVagaProx;

        //Get e Set
        internal Vagas VagaPrim
        {
            get
            {
                return vagaPrim;
            }

            set
            {
                vagaPrim = value;
            }
        }
        internal Vagas VagaUlt
        {
            get
            {
                return vagaUlt;
            }

            set
            {
                vagaUlt = value;
            }
        }

        public FilaVagas FilaVagaProx
        {
            get
            {
                return filaVagaProx;
            }

            set
            {
                filaVagaProx = value;
            }
        }



        //Métodos
        public void Adicionar(DateTime Validade, string Area, string Escolaridade, double Salario, string NomeEmpresa) // Adiciona vaga no final da fila.
        {
            Vagas NovaVaga = new Vagas(Area); // ( Validade, Area, Escolaridade, Salario, NomeEmpresa)
            VagaUlt.VagaProx = NovaVaga;
            VagaUlt = NovaVaga;
        }
        public void Remover() // Remove a primeira vaga da fila.
        {
            if (Vazia()) throw new Exception("Não ha vagas disponíveis nesta área.");
            VagaPrim.VagaProx = VagaPrim.VagaProx; // Aponta para o proximo da fila.
            if (VagaPrim.VagaProx == null) // Se fila Vazia => alterar VagaUlt para lista vazia.
                VagaUlt = VagaPrim;
        }
        public void Buscar() { }
        public override string ToString()
        {
            return base.ToString();
        }
        public bool Vazia() // returna true se fila esta vazia.
        {
            return VagaPrim == VagaUlt;
        }
        //Construtor
        public FilaVagas(string Area)
        {
            VagaPrim = new Vagas (Area);
            VagaUlt = VagaPrim;
        }
    }
}
