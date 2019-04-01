using System;
using System.Collections.Generic;
using System.IO;
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
        public void AdicionarVaga(DateTime Validade, string Area, string Escolaridade, double Salario, string NomeEmpresa)
        {
            FilaVagas Aux = FilaPrim.FilaVagaProximo;
            while (Aux != null) // Percorre toda a lista de FilaVagas.
            {
                if (Aux.VagaPrimeiro.Area == Area) // Caso encontre Area compativel => Adiciona vaga na fila da area.
                {
                    Aux.Adicionar(Validade, Area, Escolaridade, Salario, NomeEmpresa);
                    return;
                }
                Aux = Aux.FilaVagaProximo;
            }
            FilaVagas NovaFila = new FilaVagas(Area); // Caso não encontre Area compativel => instancia nova Fila para Area.
            FilaUlt.FilaVagaProximo = NovaFila;
            FilaUlt = NovaFila;
            FilaUlt.Adicionar(Validade, Area, Escolaridade, Salario, NomeEmpresa); // Adiciona a Vaga na nova fila instanciada.
            // Salva em texto arquivos de areas criados.
            using (StreamWriter writer = new StreamWriter("ListaArquivos.txt", true))
            {
                string arquivo = Area;
                writer.WriteLine(arquivo);
            }
        }
        public void RemoverVaga(string Area) // Remove vaga da fila da Area informada.
        {
            FilaVagas Aux = FilaPrim.FilaVagaProximo;
            while (Aux != null)  // Percorre toda a lista de FilaVagas.
            {
                if (Aux.VagaPrimeiro.Area == Area) // Caso encontre Area compativel => Remove primeira vaga na fila da area.
                {
                    Aux.Remover();
                    return;
                }
                Aux = Aux.FilaVagaProximo;
            }
            throw new Exception("Não ha vagas disponíveis nesta área."); // Caso não encontre Area compativel => throw Exception.
        }
        public List<Vagas> BuscarFila(string Area, string NomeEmpresa)
        {
            FilaVagas Aux = FilaPrim.FilaVagaProximo;
            List<Vagas> result = new List<Vagas>();
            while (Aux != null)
            {
                if (Aux.VagaPrimeiro.Area == Area)
                    result = Aux.Buscar(NomeEmpresa);
                Aux = Aux.FilaVagaProximo;
            }
            return result;
        }

        private void LerArquivos() // Metodo só é chamado no Construtor, para ler arquivos e instanciar objetos.
        {
            if (File.Exists("ListaArquivos.txt"))
            {
                using (StreamReader reader = new StreamReader("ListaArquivos.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine();
                        FilaVagas NovaFila = new FilaVagas(linha);
                        FilaUlt.FilaVagaProximo = NovaFila;
                        FilaUlt = NovaFila;
                        FilaUlt.LerArquivo();
                    }
                }
            }
        }
        //Construtor
        public GerenciadorVagas()
        {
            FilaPrim = new FilaVagas(null);
            FilaUlt = FilaPrim;
            LerArquivos();
        }
    }
}
