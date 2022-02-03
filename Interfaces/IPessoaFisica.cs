using System;

namespace CADASTRO_PESSOA_FS1.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarDataNascimento(DateTime dataNasc);
    }
}