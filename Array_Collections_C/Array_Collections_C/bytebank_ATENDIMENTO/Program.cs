// Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

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
using System.Security.AccessControl;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
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




TestaArrayDeContasCorrentes();