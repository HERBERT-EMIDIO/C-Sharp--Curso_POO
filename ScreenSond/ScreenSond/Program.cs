//Screen sond

string mensagem = "Olá, Herbert Emidio";

//List<string> listasBandasCadastradas = new List<string>();
//List<string> listasBandasCadastradas = new List<string> { "U2", "The Beatles", "Calypso" };

Dictionary<string, List<int>> listasBandasCadastradas = new Dictionary<string, List<int>>();

listasBandasCadastradas.Add("Link Prak", new List<int> { 10, 8, 6 });
listasBandasCadastradas.Add("The Beatles", new List<int>());


void ExibirLogo()
{

    //usando site: fSymbols.com

    Console.WriteLine(@"     
 
░ ██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║ 
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");


    Console.WriteLine(mensagem);



}


void ExibirOperacoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite < 1 > para registrar uma banda.");
    Console.WriteLine("Digite < 2 > para mostrar todas as banda.");
    Console.WriteLine("Digite < 3 > para avaliar uma banda.");
    Console.WriteLine("Digite < 4 > para exibir a média de uma banda.");
    Console.WriteLine("Digite < 0 > para sair.");


    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);


    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarBanda();

            break;
        case 4:
            MediaBanda();
            break;
        case 0:
            Console.WriteLine($"Opção: (SAIR). Obrigado volte sempre!!!");
            break;
        default:
            Console.WriteLine("Valor nao válido");
            ExibirOperacoesDoMenu();
            break;

    }
}




void RegistrarBandas()
{

    Console.Clear();


    ExibirTitulosDaOpcoes("Registro de Bandas");


    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine();

    Console.WriteLine($"A banda ''{nomeBanda}'' foi registrada com sucesso!");

    //add no List (valor) 
    //listasBandasCadastradas.Add(nomeBanda);
    //add no dictionary (chave e valor)
    listasBandasCadastradas.Add(nomeBanda, new List<int>());

    Thread.Sleep(2000);
    Console.Clear();
    ExibirOperacoesDoMenu();

}




void MostrarBandasRegistradas()
{
    Console.Clear();

    ExibirTitulosDaOpcoes("Bandas Registradas");

    int cont = 0;
    foreach (string listabandas in listasBandasCadastradas.Keys)
    {
        cont++;
        Console.WriteLine($"Banda número {cont}: {listabandas}");
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar para o menur inicial.");
    Console.ReadKey();

    Thread.Sleep(2000);
    Console.Clear();
    ExibirOperacoesDoMenu();
}




void ExibirTitulosDaOpcoes(string titulo)
{
    Console.Clear();
    int quantLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantLetras, '*');

    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}




void AvaliarBanda()
{
    Console.Clear();

    ExibirTitulosDaOpcoes("Avaliar banda");

    Console.Write("Digite nome da Banda para avaliação: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (listasBandasCadastradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda '<{nomeDaBanda}>' Merece: ");
        int nota = int.Parse(Console.ReadLine()!);

        listasBandasCadastradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota '<{nota}>' foi atribuida para a banda '<{nomeDaBanda}>' com sucesso!");

        Thread.Sleep(5000);
        Console.Clear();
        ExibirOperacoesDoMenu();

    }
    else
    {
        Console.WriteLine($"A banda '' {nomeDaBanda} '' não foi encontrada!");

        Console.Write("Digite um tecla para voltar ao menu principal.");
        Console.ReadKey();

        Console.Clear();
        ExibirOperacoesDoMenu();
    }


}


void MediaBanda()
{
    Console.Clear();
    ExibirTitulosDaOpcoes("Exibir a Média da Banda");
    Console.Write("Qual banda você deseja extrair a média? Digite o nome da Banda: ");
    string nomeBandaMedia = Console.ReadLine()!;

    int cont = 0;

    if (listasBandasCadastradas.ContainsKey(nomeBandaMedia))
    {
        List<int> avaliacoesbandasCadastradas = listasBandasCadastradas[nomeBandaMedia];
        Console.WriteLine($"A média da banda{nomeBandaMedia} é: {avaliacoesbandasCadastradas.Average()}");

        Console.Write("Digite qualquer tecla para voltar para o menu principal!<>");
        Console.ReadKey();

        Console.Clear();
        ExibirOperacoesDoMenu();
    }
    else
    {

        Console.WriteLine($"Não há, em nosso cadastro, a banda de nome: <{nomeBandaMedia}>. Favor tentar outra vez...");

        Thread.Sleep(6000);
        Console.Clear();
        ExibirOperacoesDoMenu();
    }







}

ExibirOperacoesDoMenu();
