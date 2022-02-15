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

    }
}