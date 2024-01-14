using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exception;

namespace bytebank_ATENDIMENTO.BytebankAtendimento
{
    #nullable disable
    public class BytebankAtendimento
    {
                
        private List<ContaCorrente> _listaDeContas= new List<ContaCorrente>(){
            new ContaCorrente(95, "123456-D") {Saldo=100, Titular =  new Cliente{Cpf="1234", Nome="Ana"}},
            new ContaCorrente(96, "123456-A") {Saldo=1400, Titular =  new Cliente{Cpf="12345", Nome="Pedro"}},
            new ContaCorrente(97, "123456-C") {Saldo=500,  Titular =  new Cliente{Cpf="123456", Nome="Lana"}}
        };

        

public void AtendimentoClientes(){
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
                case '6': EncerrarAplicacao();
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

        private void EncerrarAplicacao()
        {
            System.Console.WriteLine("..Encerrando aplicação");
            Console.ReadKey();
        }

        private void PesquisarContas()
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

private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
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


private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    var consulta =  (
        from conta in _listaDeContas
        where conta.Numero_agencia == numeroAgencia
        select conta).ToList();
    
    return consulta;
}


private ContaCorrente ConsultaPorCpfTitular(string? cpf)
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
private List<ContaCorrente> ConsultaPorNumeroConta(string? numeroConta)
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

private void OrdenarContas()
{
    _listaDeContas.Sort();
    System.Console.WriteLine("...Lista de contas ordenada...");
    Console.ReadKey();
}


private void RemoverContas()
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

private void ListarContas(){
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
private void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===   Cadastro de Contas   ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    

    Console.WriteLine("Numero da agencia: ");
    int numeroAgencia = int.Parse(Console.ReadLine());
    ContaCorrente conta = new ContaCorrente(numeroAgencia);

    System.Console.WriteLine($"Numero da conta [NOVA] : {conta.Conta}");

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


        
    }
}