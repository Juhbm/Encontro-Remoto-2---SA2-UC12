using System;
using CADASTRO_PESSOA_FS1.Interfaces;

namespace CADASTRO_PESSOA_FS1.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica //herda a superclasse primeiro e depois a interface
    {
        public string cpf { get; set; }
        
        public DateTime dataNascimento { get; set; }


        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            throw new NotImplementedException();
        }

        public override float PagarImposto(float rendimento) //override vai dizer que o método deve ser subrescrito
        {
            throw new NotImplementedException();
        }
    }
}