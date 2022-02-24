using System;
using CADASTRO_PESSOA_FS1.Classes;
using System.IO; //necessária para o StreamWrite utilizado na criação dos arquivos .txt
using System.Threading; //necessária para o Thread.sleep

// *** Enc. Remoto 5 *** 

Console.WriteLine(@$"
============================================================
|           Bem vindo ao Sistema de Cadastro de            |
|               Pesssoas Físicas e Jurídicas               |
============================================================
");

BarraAcao("Carregando ", 2000); //código definido após o final do "do-while" no static

string opcao; //precisa ser definida anteriormente para ser usada na estrut de repetição do while

do
{
    Console.Clear();

    Console.WriteLine(@$"
============================================================
|               Escolha uma das opções abaixo:             |
|                 1 - Pessoa Física                        |
|                 2 - Pessoa Jurídica                      |
|                                                          |
|                 0 - Sair                                 |
============================================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            PessoaFisica metodoPf = new PessoaFisica();

            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEnd = new Endereco();

            novaPf.nome = "Juliana Barroso";
            novaPf.dataNascimento = "01/01/1987";
            novaPf.cpf = "123.456.789-01";
            novaPf.rendimento = 6500.00f;

            novoEnd.logradouro = "Alameda Barão de Limeira";
            novoEnd.numero = 539;
            novoEnd.complemento = "SENAI Informática";
            novoEnd.endComercial = true;

            novaPf.endereco = novoEnd;

            Console.Clear();

            Console.WriteLine(@$"
            Nome: {novaPf.nome}
            Data de Nascimento: {novaPf.dataNascimento}
            CPF: {novaPf.cpf}
            Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
            Escola: {novoEnd.complemento}
            Maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNascimento) ? "SIM" : "NÃO")} 
            Taxa de IR a ser paga é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
            "); // ***  o ?: (if ternário) e a taxa de IR é referente ao Enc. Remoto 6 ***
            


            Console.WriteLine($"'Enter' para continuar...");
            Console.ReadLine();

            break;

        case "2":

            PessoaJuridica metodoPj = new PessoaJuridica(); //objeto para método

            PessoaJuridica novaPj = new PessoaJuridica(); //objeto separado para criar dados da pessoa juridica
            Endereco novoEndPj = new Endereco();

            novaPj.nome = "Nome Pessoa Jurídica";
            novaPj.cnpj = "11.222.333/0001-44";
            novaPj.razaoSocial = "Razão Social Pj LTDA";
            novaPj.rendimento = 28000.50f;

            novoEndPj.logradouro = "Alameda Barão de Limeira";
            novoEndPj.numero = 539;
            novoEndPj.complemento = "SENAI Informática";
            novoEndPj.endComercial = true;

            novaPj.endereco = novoEndPj;

            Console.Clear();

            Console.WriteLine(@$"
            Nome: {novaPj.nome}
            Razão Social: {novaPj.razaoSocial}
            Endereço: {novoEndPj.logradouro}, {novoEndPj.numero}
            Instituição: {novoEndPj.complemento}
            CNPJ: {novaPj.cnpj}
            CNPJ válido: {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "SIM" : "NÃO")}
            Taxa de IR a ser paga é: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
            "); // ***  o ?: (if ternário) e a taxa de IR é referente ao Enc. Remoto 6 ***

            Console.WriteLine($"'Enter' para continuar...");
            Console.ReadLine();

            break;

        case "0":

            Console.Clear();
            Console.WriteLine($"    Obrigado por utilizar nosso Sistema!\n");

            BarraAcao("         Finalizando ", 500);

            break;

        default:
            Console.Clear();
            Console.WriteLine($"    Opção inválida! Por favor, verifique as opções do menu.\n");

            BarraAcao("         Voltando ao menu ", 1200);

            break;
    }

} while (opcao != "0");

static void BarraAcao(string texto, int tempo) //criando uma função static para definir configurações da barra de carregamento
{
            // Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($"{texto}");
            for (var i = 0; i < 3; i++)
            {
                Console.Write(". ");
                Thread.Sleep(tempo);
            }
            Console.ResetColor();
}


// namespace CADASTRO_PESSOA_FS1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // **** Encontro Remoto 2 ****
//             // Console.WriteLine("Nome: " + novaPf.nome);
//             // Console.WriteLine($"Nome: {novaPf.nome} Barroso");


//             // **** Encontro Remoto 3 ****

//             PessoaFisica metodoPf = new PessoaFisica();

//             PessoaFisica novaPf = new PessoaFisica();
//             Endereco novoEnd = new Endereco();

//             novaPf.nome = "Juliana Barroso";
//             novaPf.dataNascimento = "01/01/1987";
//             novaPf.cpf = "123.456.789-01";
//             novaPf.rendimento = 4500.50f;

//             novoEnd.logradouro = "Alameda Barão de Limeira";
//             novoEnd.numero = 539;
//             novoEnd.complemento = "SENAI Informática";
//             novoEnd.endComercial = true;

//             novaPf.endereco = novoEnd;

//             Console.WriteLine(@$"
//             Nome: {novaPf.nome}
//             CPF: {novaPf.cpf}
//             Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
//             Escola: {novoEnd.complemento}
//             Maior de idade: {metodoPf.ValidarDataNascimento(novaPf.dataNascimento)}
//             ");

//             //**** Encontro Remoto 3 ****
//             // novaPf.ValidarDataNascimento(new DateTime(2006,01,01));
//             // novaPf.ValidarDataNascimento("01/01/1987");

//             //bool dataValida = metodoPf.ValidarDataNascimento(novaPf.dataNascimento);

//             // Console.WriteLine($"Nome: {novaPf.nome}");
//             // Console.WriteLine($"Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}");


//             // **** Encontro Remoto 4 ****

//             PessoaJuridica metodoPj = new PessoaJuridica(); //objeto para método

//             PessoaJuridica novaPj = new PessoaJuridica(); //objeto separado para criar dados da pessoa juridica
//             Endereco novoEndPj = new Endereco();

//             novaPj.nome = "Nome Pessoa Jurídica";
//             novaPj.cnpj = "11.222.333/0001-44";
//             novaPj.razaoSocial = "Razão Social Pj LTDA";
//             novaPj.rendimento = 20000.50f;

//             novoEndPj.logradouro = "Alameda Barão de Limeira";
//             novoEndPj.numero = 539;
//             novoEndPj.complemento = "SENAI Informática";
//             novoEndPj.endComercial = true;

//             novaPj.endereco = novoEndPj;

//             Console.WriteLine(@$"
//             Nome: {novaPj.nome}
//             Razão Social: {novaPj.razaoSocial}
//             Endereço: {novoEndPj.logradouro}, {novoEndPj.numero}
//             Instituição: {novoEndPj.complemento}
//             CNPJ: {novaPj.cnpj}
//             CNPJ válido: {metodoPj.ValidarCnpj(novaPj.cnpj)}
//             ");

//             // **** Atividade online 2 - Criar arquivos .txt com o nome de pessoa física e pessoa jurídica ****.

//             string path = @$"C:\Users\User\Desktop\PROGRAMAÇÃO\SENAI FULL STACK\UC 12 CODIFICAÇÃO BACK END\SA 2 cod.back end\CADASTRO PESSOA FS1\{novaPf.nome}.txt"; //indicando qual o caminho onde serão salvos os arquivos.

//             StreamWriter sw = File.CreateText(path); //criando a variável sw referente a Escrever os dados em texto no arquivo criado.

//             //dados PF
//             sw.WriteLine(@$"
//             Nome: {novaPf.nome}
//             Data de Nascimento: {novaPf.dataNascimento}
//             CPF: {novaPf.cpf}
//             Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
//             Escola: {novoEnd.complemento}
//             Rendimento: R$ {novaPf.rendimento}
//             Maior de idade: {metodoPf.ValidarDataNascimento(novaPf.dataNascimento)}
//             ");

//             string path1 = @$"C:\Users\User\Desktop\PROGRAMAÇÃO\SENAI FULL STACK\UC 12 CODIFICAÇÃO BACK END\SA 2 cod.back end\CADASTRO PESSOA FS1\{novaPj.nome}.txt";
//             StreamWriter sw1 = File.CreateText(path1);

//             //dados PJ
//             sw1.WriteLine(@$"
//             Nome: {novaPj.nome}
//             Razão Social: {novaPj.razaoSocial}
//             Endereço: {novoEndPj.logradouro}, {novoEndPj.numero}
//             Instituição: {novoEndPj.complemento}
//             Rendimento: R$ {novaPj.rendimento}
//             CNPJ: {novaPj.cnpj}
//             CNPJ válido: {metodoPj.ValidarCnpj(novaPj.cnpj)}
//             ");

//             sw.Close();
//             sw1.Close();
//         }
//     }
// }