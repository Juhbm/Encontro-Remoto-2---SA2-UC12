using System.IO;
using CADASTRO_PESSOA_FS1.Interfaces;

namespace CADASTRO_PESSOA_FS1.Classes
{
    public abstract class Pessoa : IPessoa //abstract torna impossível instanciar essa classe Pessoa
    {   //atributo em cima e método embaixo

        //atributos
        public string nome { get; set; }

        public Endereco endereco { get; set; }
        
        public float rendimento { get; set; }
        
        //método
        public abstract float PagarImposto(float rendimento);

        // *** Enc. Remoto 8 *** 
        //método para verificar se a pasta existe ou não e criá-la
        public void VerificarPastaArquivo(string caminho){

            string pasta = caminho.Split("/")[0]; //split devolve um array de string

            if (!Directory.Exists(pasta)) //se a pasta não existir ...
            {
                Directory.CreateDirectory(pasta); //... criar a pasta.
            }

            if (!File.Exists(caminho)) // E se o arquivo não existir...
            {
               using(File.Create(caminho)){}//criar o arquivo.
            }
        }
    }
}