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
        internal Vagas VagaPrimeiro
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
        internal Vagas VagaUltimo
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
        public FilaVagas FilaVagaProximo
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
            Vagas NovaVaga = new Vagas(Validade, Area, Escolaridade, Salario, NomeEmpresa);
            vagaUlt.VagaProximo = NovaVaga;
            vagaUlt = NovaVaga;
        }
        public void Remover() // Remove a primeira vaga da fila.
        {
            if (Vazia()) throw new Exception("Não ha vagas disponíveis nesta área.");
            vagaPrim.VagaProximo = vagaPrim.VagaProximo.VagaProximo; // Aponta para o proximo da fila.
            if (vagaPrim.VagaProximo == null) // Se fila Vazia => alterar vagaUlt para lista vazia.
                vagaUlt = vagaPrim;
        }
        public List<Vagas> Buscar(string NomeEmpresa) // Retorna lista de vagas da empresa informada.
        {
            Vagas Aux = vagaPrim.VagaProximo;
            List<Vagas> result = new List<Vagas>();
            while (Aux != null)
            {
                if (Aux.NomeEmpresa == NomeEmpresa)
                    result.Add(Aux);
                Aux = Aux.VagaProximo;
            }
            return result;
        }
        public override string ToString() // Não sei se esse método vai funcionar, tentei copiar de um exemplo do Prof.
        {
            if (Vazia()) return null;
            StringBuilder print = new StringBuilder();
            Vagas Aux = VagaPrimeiro.VagaProximo;
            while (Aux != null)
            {
                print.AppendLine(Aux.ToString());
                Aux = Aux.VagaProximo;
            }
            return print.ToString();
        }
        public bool Vazia() // returna true se fila esta vazia.
        {
            return vagaPrim == vagaUlt;
        }
        //Construtor
        public FilaVagas(string Area)
        {
            vagaPrim = new Vagas(Area);
            vagaUlt = vagaPrim;
        }
    }
}
