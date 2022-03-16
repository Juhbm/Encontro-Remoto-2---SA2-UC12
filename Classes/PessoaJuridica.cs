using System.IO;
using System.Text.RegularExpressions;
using CADASTRO_PESSOA_FS1.Interfaces;
using System.Collections.Generic;

namespace CADASTRO_PESSOA_FS1.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public PessoaJuridica(string cnpj, string razaoSocial, string caminho) 
        {
            this.cnpj = cnpj;
                this.razaoSocial = razaoSocial;
                this.caminho = caminho;
               
        }

        public PessoaJuridica()
        {
        }

        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        //*** Enc. Remoto 8 ***
        //criação de um atributo string que será o caminho específico para a PJ
        //caminho não pode ser nulo nem alterado, por isso usa-se o get e set
        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        // *** Enc. Remoto 6 ***
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        //XX.XXX.XXX/0001-XX  - XXXXXXXX0001XX
        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18) //validando com os caracteres . / e -
                {
                    if (cnpj.Substring(11, 4) == "0001") //substring para validar um trecho da string
                    {
                        return true;
                    }
                }
                else if (cnpj.Length == 14) //validando sem caracteres, somente números
                {
                    if (cnpj.Substring(8, 4) == "0001" )
                    {
                        return true;   
                    }
                } 
            }
            return false;
        }


        // ***Enc. Remoto 8 *** 
        //método para inserir e ler arquivo
        public void Inserir(PessoaJuridica pj){

            VerificarPastaArquivo(caminho);

            string[] pjstring = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};

            File.AppendAllLines(caminho, pjstring); //acessa um arquivo e escreve dentro deste arquivo o conteúdo da variável pjstring
        }

        //método para ler
        public List<PessoaJuridica> Ler(){

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPJ = new PessoaJuridica();

                cadaPJ.nome = atributos[0];
                cadaPJ.cnpj = atributos[1];
                cadaPJ.razaoSocial = atributos[2];

                listaPj.Add(cadaPJ);
            }
            return listaPj;
            //fim enc. remoto 8
        }
    }
}