// using System;

// namespace CADASTRO_PESSOA_FS1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Hello World!");
//         }
//     }
// }

using System;
using CADASTRO_PESSOA_FS1.Classes;

PessoaFisica novaPf = new PessoaFisica();

novaPf.nome = "Juliana";

Console.WriteLine("Nome: " + novaPf.nome);

Console.WriteLine($"Nome: {novaPf.nome} Barroso");