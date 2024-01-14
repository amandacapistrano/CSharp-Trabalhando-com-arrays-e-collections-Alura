using System.Collections;
using System.Security.AccessControl;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.bytebank.Exception;
using System.Runtime.Intrinsics.Arm;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region exemplo Arrays
// //arrays



// // TestaArrayInt();

// // TestaBuscarPalavra();



// void TestaArrayInt(){

//     // int [] idades = new int[5];

//     // idades[0] = 10;

//     // idades[1] = 60;

//     // idades[2] = 50;

//     // idades[3] = 18;

//     // idades[4] = 63;

//     int [] idades = {10, 60, 50, 18, 63 };



//     Console.WriteLine($"Tamanho do Array {idades.Length}");

//     int acumulador = 0;

//     for(int i = 0; i < idades.Length; i++){

//         int idade = idades[i];

//         Console.WriteLine($"Índice {i} = {idade}");



//         acumulador += idade;

//     }



//     int media = acumulador / idades.Length;

//     Console.WriteLine($"A média das idades é: {media}");

// }



// void TestaBuscarPalavra(){

//     string[] arrayDePalavras = new string[3];

//     for(int i = 0 ; i < arrayDePalavras.Length; i++){

//         Console.Write($"Digite a {i+1}ª palavra: ");

//         arrayDePalavras[i] =  Console.ReadLine();

//     }

//     Console.Write("Digite a palavra a ser encontrada: ");

//     var busca = Console.ReadLine();



//     foreach (var palavra in arrayDePalavras){

//         if(palavra.Equals(busca)){

//             Console.WriteLine($"Palavra encontrada = {busca}.");

//             return;

//         }

//     }

// }



// // Array amostra = Array.CreateInstance(typeof(double), 5);

// Array amostra = new double[5];

// amostra.SetValue(10.5, 0);

// amostra.SetValue(5.5, 1);

// amostra.SetValue(15.5, 2);

// amostra.SetValue(13.5, 3);

// amostra.SetValue(6.5, 4);



// TestaMediana(amostra);



// void TestaMediana(Array array){

//     if((array == null) || (array.Length == 0)){

//         Console.WriteLine("Array para calculo está vazio ou nulo");

//     }



//     double[] numerosOrdenados = (double[])array.Clone();

//     Array.Sort(numerosOrdenados);



//     int tamanho = numerosOrdenados.Length;

//     int meio = tamanho/2;

//     double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;



//     Console.WriteLine($"Com base na amostra a mediana é de {mediana}");

// }
#endregion

#region  Exemplos array em C# Contas
// void TestaArrayDeContasCorrentes(){
//     ContaCorrente[] listaDeContas = new ContaCorrente[]{
//         new ContaCorrente(874, "15542-A"),
//         new ContaCorrente(875, "15542-B"),
//         new ContaCorrente(876, "15542-C"),
//     };

//     for (int i = 0; i < listaDeContas.Length; i++)
//     {
//         ContaCorrente contaAtual = listaDeContas[i];
//         Console.WriteLine($"Conta: {contaAtual.Conta}");
//     }
// }

void TestaArrayDeContasCorrentes(){
    
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "15542-A"));
    listaDeContas.Adicionar(new ContaCorrente(875, "15542-B"));
    listaDeContas.Adicionar(new ContaCorrente(876, "15542-C"));
    listaDeContas.Adicionar(new ContaCorrente(888, "15542-C"));
    var contaTeste = new ContaCorrente(999, "12456-X");
    listaDeContas.Adicionar(contaTeste);
    // listaDeContas.ExibeLista();
    // listaDeContas.Remover(contaTeste);
    // Console.WriteLine("");
    // listaDeContas.ExibeLista();

 for (int i = 0; i < listaDeContas.Tamanho; i++){
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta} / {conta.Numero_agencia}");
 }
}
//TestaArrayDeContasCorrentes();
#endregion

List<ContaCorrente> _listaDeContas= new List<ContaCorrente>(){
    new ContaCorrente(95, "123456-D") {Saldo=100, Titular =  new Cliente{Cpf="1234", Nome="Ana"}},
    new ContaCorrente(96, "123456-A") {Saldo=1400, Titular =  new Cliente{Cpf="12345", Nome="Pedro"}},
    new ContaCorrente(97, "123456-C") {Saldo=500,  Titular =  new Cliente{Cpf="123456", Nome="Lana"}}
};

AtendimentoClientes();

void AtendimentoClientes(){
    try
    {
        char opcao = '0';
        while(opcao != '6'){
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===    1- Cadastar Conta    ===");
            Console.WriteLine("===    2- Listar Contas     ===");
            Console.WriteLine("===    3- Remover Contas    ===");
            Console.WriteLine("===    4- Ordenar Contas    ===");
            Console.WriteLine("===    5- Pesquisar Contas  ===");
            Console.WriteLine("===    6- Sair do Sistema   ===");
            Console.WriteLine("===============================");

            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (System.Exception excecao)
            {
                
                throw new BytebankException(excecao.Message);
            }
            
            switch(opcao){
                case '1': CadastrarConta();
                    break;
                case '2': ListarContas();
                    break;
                case '3': RemoverContas();
                    break;
                case '4': OrdenarContas();
                break;
                case '5': PesquisarContas();
                break;
                default: Console.WriteLine("Opcao invalida!");
                    break;
            }
        }
        
    }
    catch (BytebankException excecao)
    {
        
        System.Console.WriteLine($"{excecao.Message}");
    }

}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===    Remover Contas      ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    System.Console.WriteLine("Deseja pesquisar por (1) Numero da conta ou (2) CPF titular ou (3) nº da agencia?");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
        {
            System.Console.WriteLine("Informe o número da Conta: ");
            string _numeroConta = Console.ReadLine();
            var consultaConta = ConsultaPorNumeroConta(_numeroConta);
            //Antes do LINQ//System.Console.WriteLine(consultaConta.ToString());
            ExibirListaDeContas(consultaConta);
            Console.ReadKey();
            break;
        }
        case 2:
        {
            System.Console.WriteLine("Informe o CPF do Titular: ");
            string _cpf = Console.ReadLine();
            ContaCorrente consultaCpf = ConsultaPorCpfTitular(_cpf);
            System.Console.WriteLine(consultaCpf.ToString());
            Console.ReadKey();
            break;
        }
        case 3:
        {
            System.Console.WriteLine("Informe o Nº da Agência: ");
            int _numeroAgencia = int.Parse(Console.ReadLine());
            var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
            //System.Console.WriteLine(contasPorAgencia.ToString());
            ExibirListaDeContas(contasPorAgencia);
            Console.ReadKey();
            break;
        }
        default:
        System.Console.WriteLine("Opção não implementada");
        break;
    }
}

void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
{
   if(contasPorAgencia==null){
    System.Console.WriteLine("...A consulta não retornou dados...");
   }else{
    foreach (var item in contasPorAgencia)
    {
        System.Console.WriteLine(item.ToString());        
    }
   }
}


List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    var consulta =  (
        from conta in _listaDeContas
        where conta.Numero_agencia == numeroAgencia
        select conta).ToList();
    
    return consulta;
}


ContaCorrente ConsultaPorCpfTitular(string? cpf)
{
//    ContaCorrente conta = null;
//    for (int i = 0; i < _listaDeContas.Count; i++)
//    {
//         if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
//         {
//             conta = _listaDeContas[i];
//         }
    
//    }
//    return conta;
    return _listaDeContas.Where(conta=>conta.Titular.Cpf==cpf).FirstOrDefault();
}


//ContaCorrente ConsultaPorNumeroConta(string? numeroConta) antes do LINQ
List<ContaCorrente> ConsultaPorNumeroConta(string? numeroConta)
{
//     ContaCorrente conta = null;
//    for (int i = 0; i < _listaDeContas.Count; i++)
//    {
//         if (_listaDeContas[i].Conta.Equals(numeroConta))
//         {
//             conta = _listaDeContas[i];
//         }
    
//    }
//    return conta;
// return _listaDeContas.Where(conta=>conta.Conta==numeroConta).FirstOrDefault();

var consulta =  (
        from conta in _listaDeContas
        where conta.Conta== numeroConta
        select conta).ToList();
    
    return consulta;
   
}

void OrdenarContas()
{
    _listaDeContas.Sort();
    System.Console.WriteLine("...Lista de contas ordenada...");
    Console.ReadKey();
}


void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===    Remover Contas      ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    System.Console.WriteLine("Informe o número da Conta: ");
    string numeroConta =  Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaDeContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        System.Console.WriteLine("... Conta removida da lista!...");
    }else{
        System.Console.WriteLine("... Conta para remoção não encontrada...");
    }
    Console.ReadKey();
}

void ListarContas(){
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===   Cadastro de Contas   ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    if(_listaDeContas.Count<=0){
        Console.WriteLine("... Nao ha contas cadastradas!...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        // Console.WriteLine("==============================");
        // Console.WriteLine("===     Dados da Conta     ===");
        // Console.WriteLine("Numero da Conta: " + item.Conta);
        // Console.WriteLine("Numero da Saldo: " + item.Saldo);
        // Console.WriteLine("Titular  da  Conta: " + item.Titular.Nome);
        // Console.WriteLine("CPF do titular: " + item.Titular.Cpf);
        // Console.WriteLine("Profissao do titular: " + item.Titular.Profissao);
        Console.WriteLine(item.ToString());
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
        
    }
 }

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===   Cadastro de Contas   ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.WriteLine("Numero da conta: ");
    string numeroConta = Console.ReadLine();
    Console.WriteLine("Numero da agencia: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.WriteLine("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe o nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Informe CPF do titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Informe profissao do titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();




}

#region Aulas List e generic
//Listas genericas
// List<ContaCorrente> _listaDeContas2= new List<ContaCorrente>(){
//     new ContaCorrente(895, "123456-D") ,
//     new ContaCorrente(986, "123456-E") ,
//     new ContaCorrente(975, "123456-F")
// };

// List<ContaCorrente> _listaDeContas3= new List<ContaCorrente>(){
//     new ContaCorrente(915, "123456-G") ,
//     new ContaCorrente(946, "123456-H") ,
//     new ContaCorrente(497, "123456-I") 
// };

// _listaDeContas2.AddRange(_listaDeContas3);

// _listaDeContas2.Reverse();

//  for(int i = 0; i < _listaDeContas2.Count; i++)
//  {
//     Console.WriteLine($"Indice[{i}] =  Conta [{_listaDeContas2[i].Conta}]");
//  }
// System.Console.WriteLine("\n\n");

// var range = _listaDeContas3.GetRange(0, 1);
// for(int i = 0; i < range.Count; i++)
//  {
//     Console.WriteLine($"Indice[{i}] =  Conta [{range[i].Conta}]");
//  }
// System.Console.WriteLine("\n\n");

// _listaDeContas3.Clear();
// for(int i = 0; i <_listaDeContas3.Count; i++)
//  {
//     Console.WriteLine($"Indice[{i}] =  Conta [{_listaDeContas3[i].Conta}]");
//  }


// //Exercicio Desafio:
// List<string> nomesDosEscolhidos = new List<string>()
// {
//     "Bruce Wayne",
//     "Carlos Vilagran",
//     "Richard Grayson",
//     "Bob Kane",
//     "Will Farrel",
//     "Lois Lane",
//     "General Welling",
//     "Perla Letícia",
//     "Uxas",
//     "Diana Prince",
//     "Elisabeth Romanova",
//     "Anakin Wayne"
// };

// bool VerificaNomes(List<string> nomesDosEscolhidos,string escolhido)
// {
//     return nomesDosEscolhidos.Contains(escolhido);
// }
// System.Console.WriteLine(VerificaNomes(nomesDosEscolhidos, "Anakin Wayne"));
#endregion





