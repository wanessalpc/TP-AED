using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculos
{
    public class Vagas
    {
        //Atributos
        private Vagas vagaProximo;
        private DateTime validade;
        private string area;
        private string escolaridade;
        private double salario;
        private string nomeEmpresa;

        //Get e Set        
        internal Vagas VagaProximo
        {
            get
            {
                return vagaProximo;
            }

            set
            {
                vagaProximo = value;
            }
        }
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

        //Construtor
        public Vagas(DateTime Validade, string Area, string Escolaridade, double Salario, string NomeEmpresa)
        {
            this.Validade = Validade;
            this.Area = Area;
            this.Escolaridade = Escolaridade;
            this.Salario = Salario;
            this.NomeEmpresa = NomeEmpresa;
        }

        //Construtor padrão
        public Vagas(string Area)
        {
            this.Area = Area;
        }
    }
}
