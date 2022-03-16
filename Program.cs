using System;
using CADASTRO_PESSOA_FS1.Classes;
using System.IO; //necessária para o StreamWrite utilizado na criação dos arquivos .txt
using System.Threading; //necessária para o Thread.sleep
using System.Collections.Generic;

// *** Enc. Remoto 5 *** 

Console.WriteLine(@$"
============================================================
|           Bem vindo ao Sistema de Cadastro de            |
|               Pesssoas Físicas e Jurídicas               |
============================================================
");

BarraAcao("Carregando ", 2000); //código definido após o final do "do-while" no static

List<PessoaFisica> listaPF = new List<PessoaFisica>(); //criação da lista antes do do while principal para não zerar a lista ao fechar o submenu
List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

string opcao; //precisa ser definida anteriormente para ser usada na estrut de repetição do while

do //menu externo
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
            

            // *** Enc. Remoto 7 *** criação do submenu PF

            string opcaoPF; //variável string para utiliza no submenu
            do
            {
                Console.Clear();

                Console.WriteLine(@$"
            ============================================================
            |               Escolha uma das opções abaixo:             |
            |                 1 - Cadastrar Pessoa Física              |
            |                 2 - Exibir Pessoas Físicas               |
            |                                                          |
            |                 0 - Voltar ao menu anterior              |
            ============================================================
            ");

                opcaoPF = Console.ReadLine();

                switch (opcaoPF)
                {
                    case "1":

                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.Write($"Digite o nome da Pessoa Física para cadastro: ");
                        novaPf.nome = Console.ReadLine();
                        
                        bool dataValida;
                        do
                        {
                            Console.Write($"Digite a data de nascimento (Ex: DD/MM/AAAA): ");
                            string dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                            if (dataValida)
                            {
                                novaPf.dataNascimento = dataNasc;
                            }else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data inválida... Por favor, digite uma data válida: ");
                                Console.ResetColor();
                            }
                        } while (dataValida != true);

                        Console.Write($"Digite o número do CPF: ");
                        novaPf.cpf = Console.ReadLine();

                        Console.Write($"Digite o rendimento mensal (somente números): ");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.Write($"Digite o logradouro: ");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.Write($"Digite o número: ");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.Write($"Digite o complemento (ENTER para vazio): ");
                        novoEnd.complemento = Console.ReadLine();
                        
                        Console.Write($"Endereço é comercial? S/N: ");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }else 
                        {
                            novoEnd.endComercial = false;
                        }
                        novaPf.endereco = novoEnd;

                        listaPF.Add(novaPf); // adicionar a nova pf na lista

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"CADASTRO REALIZADO COM SUCESSO!");
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        
                        break;

                    case "2":
                        Console.Clear();

                        if (listaPF.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPF) //para ler conteúdo de uma lista usar foreach
                            {
                                Console.Clear();

                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Data de Nascimento: {cadaPessoa.dataNascimento}
                                CPF: {cadaPessoa.cpf}
                                Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                Instituição/Empresa: {cadaPessoa.endereco.complemento}
                                End. Comercial: {cadaPessoa.endereco.endComercial}
                                Maior de idade: {cadaPessoa.dataNascimento} 
                                Taxa de IR a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                "); 

                                Console.WriteLine($"'Enter' para continuar...");
                                Console.ReadLine();
                                
                            }
                        }else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(3000);
                        }

                        
                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"    Opção inválida! Por favor, verifique as opções do menu.\n");

                        BarraAcao("         Voltando ao menu ", 1200);
                        break;
                }
                
            } while (opcaoPF != "0");

            // PessoaFisica novaPf = new PessoaFisica();
            // Endereco novoEnd = new Endereco();

            // novaPf.nome = "Juliana Barroso";
            // novaPf.dataNascimento = "01/01/1987";
            // novaPf.cpf = "123.456.789-01";
            // novaPf.rendimento = 6500.00f;

            // novoEnd.logradouro = "Alameda Barão de Limeira";
            // novoEnd.numero = 539;
            // novoEnd.complemento = "SENAI Informática";
            // novoEnd.endComercial = true;

            // novaPf.endereco = novoEnd;

            // Console.Clear();

            // Console.WriteLine(@$"
            // Nome: {novaPf.nome}
            // Data de Nascimento: {novaPf.dataNascimento}
            // CPF: {novaPf.cpf}
            // Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
            // Escola: {novoEnd.complemento}
            // Maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNascimento) ? "SIM" : "NÃO")} 
            // Taxa de IR a ser paga é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
            // "); // ***  o ?: (if ternário) e a taxa de IR é referente ao Enc. Remoto 6 ***
            


            // Console.WriteLine($"'Enter' para continuar...");
            // Console.ReadLine();

            break;

        case "2":

            PessoaJuridica metodoPj = new PessoaJuridica(); //objeto para método

            // // *** Enc. Remoto 7 *** criação do submenu PJ

            // string opcaoPJ; //variável string para utiliza no submenu
            // do
            // {
            //     Console.Clear();

            //     Console.WriteLine(@$"
            // ============================================================
            // |               Escolha uma das opções abaixo:             |
            // |                 1 - Cadastrar Pessoa Jurídica            |
            // |                 2 - Exibir Pessoas Jurídicas             |
            // |                                                          |
            // |                 0 - Voltar ao menu anterior              |
            // ============================================================
            // ");

            //     opcaoPJ = Console.ReadLine();

            //     switch (opcaoPJ)
            //     {
            //         case "1":

            //             PessoaJuridica novaPj = new PessoaJuridica(); //objeto separado para criar dados da pessoa juridica
            //             Endereco novoEndPj = new Endereco();

            //             Console.Write($"Digite o nome da Pessoa Jurídica para cadastro: ");
            //             novaPj.nome = Console.ReadLine();
                        
            //             bool cnpjValido;
            //             do
            //             {
            //                 Console.Write($"Digite o CNPJ (Ex: 00.000.000/0001-00 ou 00000000000100): ");
            //                 string cnpj = Console.ReadLine();

            //                 cnpjValido = metodoPj.ValidarCnpj(cnpj);
            //                 if (cnpjValido)
            //                 {
            //                     novaPj.cnpj= cnpj;
            //                 }else
            //                 {
            //                     Console.ForegroundColor = ConsoleColor.DarkRed;
            //                     Console.WriteLine($"CNPJ inválido... Por favor, verifique e digite novamente: ");
            //                     Console.ResetColor();
            //                 }
            //             } while (cnpjValido != true);

            //             Console.Write($"Digite a razão social: ");
            //             novaPj.razaoSocial = Console.ReadLine();

            //             Console.Write($"Digite o rendimento mensal (somente números): ");
            //             novaPj.rendimento = float.Parse(Console.ReadLine());

            //             Console.Write($"Digite o logradouro: ");
            //             novoEndPj.logradouro = Console.ReadLine();

            //             Console.Write($"Digite o número: ");
            //             novoEndPj.numero = int.Parse(Console.ReadLine());

            //             Console.Write($"Digite o complemento (ENTER para vazio): ");
            //             novoEndPj.complemento = Console.ReadLine();
                        
            //             Console.Write($"Endereço é comercial? S/N: ");
            //             string endCom = Console.ReadLine().ToUpper();

            //             if (endCom == "S")
            //             {
            //                 novoEndPj.endComercial = true;
            //             }else 
            //             {
            //                 novoEndPj.endComercial = false;
            //             }
            //             novaPj.endereco = novoEndPj;

            //             listaPJ.Add(novaPj); // adicionar a nova pj na lista

            //             Console.ForegroundColor = ConsoleColor.DarkGreen;
            //             Console.WriteLine($"CADASTRO REALIZADO COM SUCESSO!");
            //             Thread.Sleep(3000);
            //             Console.ResetColor();
                        
            //             break;

            //         case "2":
            //             Console.Clear();

            //             if (listaPJ.Count > 0)
            //             {
            //                 foreach (PessoaJuridica cadaPJ in listaPJ) //para ler conteúdo de uma lista usar foreach
            //                 {
            //                     Console.Clear();

            //                     Console.WriteLine(@$"
            //                     Nome: {cadaPJ.nome}
            //                     Razão Social: {cadaPJ.razaoSocial}
            //                     CNPJ: {cadaPJ.cnpj}
            //                     Endereço: {cadaPJ.endereco.logradouro}, {cadaPJ.endereco.numero}
            //                     Instituição: {cadaPJ.endereco.complemento}
            //                     Taxa de IR a ser paga é: {metodoPj.PagarImposto(cadaPJ.rendimento).ToString("C")}
            //                     ");

            //                     Console.WriteLine($"'Enter' para continuar...");
            //                     Console.ReadLine();
                                
            //                 }
            //             }else
            //             {
            //                 Console.WriteLine($"Lista vazia!");
            //                 Thread.Sleep(3000);
            //             }

            //             break;

            //         case "0":
            //             break;

            //         default:
            //             Console.Clear();
            //             Console.WriteLine($"    Opção inválida! Por favor, verifique as opções do menu.\n");

            //             BarraAcao("         Voltando ao menu ", 1200);
            //             break;
            //     }
                
            // } while (opcaoPJ != "0");


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

            //*** Enc. Remoto 8 *** criar e ler arquivo em csv

            metodoPj.Inserir(novaPj);

            List<PessoaJuridica> listaPj = metodoPj.Ler();

            foreach (PessoaJuridica cadaItem in listaPj)
            {
                Console.Clear();

                Console.WriteLine(@$"
                Nome: {novaPj.nome}
                CNPJ: {novaPj.cnpj}
                Razão Social: {novaPj.razaoSocial}
                ");

                Console.WriteLine($"'Enter' para continuar...");
                Console.ReadLine();
            }
            //fim enc. remoto 8

            // Console.Clear();

            // Console.WriteLine(@$"
            // Nome: {novaPj.nome}
            // Razão Social: {novaPj.razaoSocial}
            // Endereço: {novoEndPj.logradouro}, {novoEndPj.numero}
            // Instituição: {novoEndPj.complemento}
            // CNPJ: {novaPj.cnpj}
            // CNPJ válido: {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "SIM" : "NÃO")}
            // Taxa de IR a ser paga é: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
            // "); // ***  o ?: (if ternário) e a taxa de IR é referente ao Enc. Remoto 6 ***

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