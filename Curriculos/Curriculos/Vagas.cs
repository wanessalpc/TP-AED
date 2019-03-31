using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculos
{
    class Vagas
    {
        //Atributos
        private DateTime validade;
        private string area;
        private string escolaridade;
        private double salario;
        private Vagas vagaProx;
        private string nomeEmpresa;

        //Construtor
        public Vagas(string area)
        {
            this.validade = Validade;
            this.area = area;
            this.escolaridade = Escolaridade;
            this.salario = Salario;
            this.vagaProx = VagaProx;
            this.nomeEmpresa = NomeEmpresa;

        }

        //Get e Set
        public DateTime Validade
        {
            get
            {
                return validade;
            }

            set
            {
                validade = value;
            }
        }

        public string Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public string Escolaridade
        {
            get
            {
                return escolaridade;
            }

            set
            {
                escolaridade = value;
            }
        }

        public double Salario
        {
            get
            {
                return salario;
            }

            set
            {
                salario = value;
            }
        }

        internal Vagas VagaProx
        {
            get
            {
                return vagaProx;
            }

            set
            {
                vagaProx = value;
            }
        }

        public string NomeEmpresa
        {
            get
            {
                return nomeEmpresa;
            }

            set
            {
                nomeEmpresa = value;
            }
        }
    }
}
