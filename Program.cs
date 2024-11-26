// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";// As varias seguem o padrão CamelCase, primeira letra minuscula as demais maiuscula.
// List<string> listaDasBandas = new List<string> { "Amigos", "U2", "Natiruts", "Calypso" }; // criando um array "Uma lista"
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();// criando uma matriz

bandasRegistradas.Add("Natiruts", new List<int> { 1, 2, 4});
bandasRegistradas.Add("Linkin Park", new List<int>());

// void -> função que não ira retornar algo.
void ExibirLogo()
{// As funções seguem com a primeira letra maiuscula, seguindo o PaschaelCase.

    // O @ serve para colocar a string de forma literal na tela.
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███╗░░██╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝████╗░██║████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░██╔██╗██║██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██║╚████║██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗██║░╚███║██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");

    Console.WriteLine(mensagemDeBoasVindas);

}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida)!;

   switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();      
            break;

         case 2: MostrarBandasRegistradas();
            break;

        case 3: AvaliarBanda();
            break;

        case 4:
            MediaDaBanda();
            break;

        case -1:
            Console.WriteLine("Tchau tachu! :)");
            break;

        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;//O ponto de exclamação após o console serve para não poder trabalhar com valores vazios.
    //listaDasBandas.Add(nomeDaBanda); - Adicionando uma banda dentro do array
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    /*
     
     * Adicionando a contagem a lista para exibição
     
    for (int i = 0;i < listaDasBandas.Count ; i++)
    {
       Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }
    */

    /*
     
     * Exibindo a lista do array
    foreach(string banda in listaDasBandas) // Faz o laço para cada item dentro da lista.
    {
        Console.WriteLine($"Banda: {banda}");
    }
    */

    // Exibindo lista de bandas do dicionario
    foreach (string banda in bandasRegistradas.Keys) // Faz o laço para cada item dentro da lista.
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para retornar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    
   
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    // digite qual a banda deseja avalidar
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    // se a banda existir no dicionario >> atribuir uma nota
    if (bandasRegistradas.ContainsKey(nomeDaBanda)!) 
    {
        Console.Write($"Qual a nota que a {nomeDaBanda} merece:");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a {nomeDaBanda}");
        Thread.Sleep( 1000 );
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else // senão, volta ao menu principal
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


void MediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média da banda");

    Console.Write("Digite o nome da banda que deseja ver a média:");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA media da nota da banda {nomeDaBanda} é de {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi localizada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}
ExibirLogo();
ExibirOpcoesDoMenu();