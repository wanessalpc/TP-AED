﻿using System;
using System.Collections.Generic;
using System.IO;
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

        //Construtor
        public FilaVagas(string Area)
        {
            VagaPrim = new Vagas(Area);
            VagaUlt = VagaPrim;
        }

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
            Vagas NovaVaga = new Vagas(Validade, Area, Escolaridade, Salario, NomeEmpresa);
            vagaUlt.VagaProx = NovaVaga;
            vagaUlt = NovaVaga;

            // Adiciona no arquivo uma linha com os dados da nova vaga.
            string arquivo = Area + ".txt";
            using (StreamWriter writer = new StreamWriter(arquivo, true))
                writer.WriteLine(Validade + "-" + Area + "-" + Escolaridade + "-" + Salario + "-" + NomeEmpresa);
        }
        public void Remover() // Remove a primeira vaga da fila.
        {
            if (Vazia()) throw new Exception("Não ha vagas disponíveis nesta área.");

            VagaPrim.VagaProx = VagaPrim.VagaProx; // Aponta para o proximo da fila.
            if (VagaPrim.VagaProx == null) // Se fila Vazia => alterar VagaUlt para lista vazia.
                VagaUlt = VagaPrim;

            vagaPrim.VagaProx = vagaPrim.VagaProx.VagaProx; // Aponta para o proximo da fila.
            if (vagaPrim.VagaProx == null) // Se fila Vazia => alterar vagaUlt para lista vazia.
                vagaUlt = vagaPrim;

            // Deleta primeira linha do arquivo de texto.
            string arquivo = vagaPrim.Area + ".txt";
            var lines = File.ReadAllLines(arquivo).Skip(1);
            File.Delete(arquivo);
            File.WriteAllLines(arquivo, lines);
        }
        public List<Vagas> Buscar(string NomeEmpresa) // Retorna lista de vagas da empresa informada.
        {
            Vagas Aux = vagaPrim.VagaProx;
            List<Vagas> result = new List<Vagas>();
            while (Aux != null)
            {
                if (Aux.NomeEmpresa == NomeEmpresa)
                    result.Add(Aux);
                Aux = Aux.VagaProx;
            }
            return result;
        }
        public override string ToString() // Não sei se esse método vai funcionar, tentei copiar de um exemplo do Prof.
        {
            if (Vazia()) return null;
            StringBuilder print = new StringBuilder();
            Vagas Aux = VagaPrim.VagaProx;
            while (Aux != null)
            {
                print.AppendLine(Aux.ToString());
                Aux = Aux.VagaProx;
            }
            return print.ToString();
        }
        public void LerArquivo() // Lê arquivo e cria vagas se nescessario.
        {
            string arquivo = vagaPrim.Area + ".txt";
            using (StreamReader reader = new StreamReader(arquivo))
            {
                while (!reader.EndOfStream) // Enquanto arquivo não acaba.
                {
                    string linha = reader.ReadLine();
                    string[] dados = linha.Split('-');
                    Adicionar(Convert.ToDateTime(dados[0]), dados[1], dados[2], Convert.ToDouble(dados[3]), dados[4]);
                }
            }
        }
        public bool Vazia() // returna true se fila esta vazia.
        {
            return vagaPrim == vagaUlt;
        }
    }
}
