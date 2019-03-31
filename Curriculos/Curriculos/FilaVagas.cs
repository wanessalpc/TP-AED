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
        public void Adicionar(DateTime Validade, string Area, string Escolaridade, double Salario, string NomeEmpresa) // Adiciona vaga no final da fila.
        {
            Vagas NovaVaga = new Vagas(Validade, Area, Escolaridade, Salario, NomeEmpresa);
            VagaUlt.VagaProx = NovaVaga;
            VagaUlt = NovaVaga;
        }
        public void Remover() // Remove a primeira vaga da fila.
        {
            if (Vazia()) throw new Exception("Não ha vagas disponíveis nesta área.");
            VagaPrim.VagaProx = VagaPrim.VagaProx.VagaProx; // Aponta para o proximo da fila.
            if (VagaPrim.VagaProx == null) // Se fila Vazia => alterar VagaUlt para lista vazia.
                VagaUlt = VagaPrim;
        }
        public Vagas Buscar(string NomeEmpresa) // Retorna primeira vaga com atributos recebidos.
        {
            Vagas Aux = VagaPrim;
            while (Aux.VagaProx != null)
            {
                if (Aux.NomeEmpresa == NomeEmpresa)
                    return Aux;
                Aux = Aux.VagaProx;
            }
            return null;
        }
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
            VagaPrim = new Vagas(Area);
            VagaUlt = VagaPrim;
        }
    }
}
