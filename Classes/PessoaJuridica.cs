using CADASTRO_PESSOA_FS1.Interfaces;

namespace CADASTRO_PESSOA_FS1.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string cnpj { get; set; }
        
        public string razaoSocial { get; set; }
        

        public override float PagarImposto(float rendimento)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidarCnpj(string cnpj)
        {
            throw new System.NotImplementedException();
        }
    }
}