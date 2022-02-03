using System;
using CADASTRO_PESSOA_FS1.Classes;

PessoaFisica metodoPf = new PessoaFisica();

//enc remoto 3

PessoaFisica novaPf = new PessoaFisica();
Endereco novoEnd = new Endereco();

novaPf.nome = "Juliana Barroso";
novaPf.dataNascimento = "05/03/1987";
novaPf.cpf = "12345678901";
novaPf.rendimento = 15000.5f;

novoEnd.logradouro = "Alameda Barão de Limeira";
novoEnd.numero = 539;
novoEnd.complemento = "SENAI Informática";
novoEnd.endComercial = true;

novaPf.endereco = novoEnd;

Console.WriteLine(@$"
Nome: {novaPf.nome}
CPF: {novaPf.cpf}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
Escola: {novoEnd.complemento}
Maior de idade: {metodoPf.ValidarDataNascimento(novaPf.dataNascimento)}
");


//enc remoto 2
// Console.WriteLine("Nome: " + novaPf.nome);
// Console.WriteLine($"Nome: {novaPf.nome} Barroso");

//enc remoto 3
// novaPf.ValidarDataNascimento(new DateTime(2006,01,01));
// novaPf.ValidarDataNascimento("05/03/1987");

//bool dataValida = metodoPf.ValidarDataNascimento(novaPf.dataNascimento);

// Console.WriteLine($"Nome: {novaPf.nome}");
// Console.WriteLine($"Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}");
