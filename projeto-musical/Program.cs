﻿// Musiqueiros
// Anotações gerais e notas mentais
// O C# usa o camelCase para variavels, e PacalCase para funções (aquele que toda palavra começa com letra maiscula) e é fortemente tipada
// > Para criar uma função a primeira coisa que devemos pensar é se tem um retorno ou não <

// List<string> bandas = new List<string>();

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Dua Lipa", new List<int>{5, 10, 9, 8, 10});
bandasRegistradas.Add("Justin Timberlake", new List<int>{6, 10, 10, 3, 10});
bandasRegistradas.Add("Ed Sheeran", new List<int>{1, 10, 10, 10, 10});
bandasRegistradas.Add("Maroon 5", new List<int>{4,5,10,8,9});


void ExibirBoasVindas(){
    string mensagem = "Seja bem vindo, Musiqueiro";
    Console.WriteLine(mensagem);
} //função

void ExibirLogo(){
    string msglogo = "Manda vê, Musiqueiro!!!";
    Console.WriteLine(msglogo);
    //função
}
// Menu - ___________________________________________________________________________________________________________

void ExibirMenu(){
    Console.WriteLine("\nO que deseja fazer?\n");
    Console.WriteLine("1 - Registrar uma banda");
    Console.WriteLine("2 - Mostrar Bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Média de uma banda");
    Console.WriteLine("5 - Sair");

    Console.Write("Opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    // ReadLine pode voltar um valor nulo, por isso adicionamos o !
int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
// Aqui transformamos o string em int para poder usar o numero
   switch (opcaoEscolhidaNumerica){
    case 1: RegistrarBanda(); break;
    case 2: MostrarBandas(); break;
    case 3: AvaliarBanda(); break;
    case 4: MediaBanda(); break;
    case 5: Console.WriteLine("Valeu Musiqueiro, até a proxima"); break;
    default: Console.WriteLine("Opção inválida"); break; 

    // Quando tem muitas opções para escolher podemos usar o switch

   }
}

// 1 - Registrar uma banda - ___________________________________________________________________________________________________________
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcoes("Registrar das bandas");
    Console.Write("Digite o nome da banda: ");
    string nome = Console.ReadLine()!;
    bandasRegistradas.Add(nome, new List<int>());
    Console.WriteLine($"Banda {nome} registrada com sucesso!"); // $ faz com que o texto seja interpolado
    Thread.Sleep(4000);  // faz com que aguarde um tempo antes de mostrar o menu
    Console.Clear(); // Faz com que limope a tela antes de mostrar o menu
    ExibirLogo();
    ExibirMenu();
}
// 2- Mostrar todas as bandas ___________________________________________________________________________________________________________

void MostrarBandas()
{
    Console.Clear();
    
    if (bandasRegistradas.Count == 0){
        ExibirTituloOpcoes("Nenhuma banda foi registrada no momento");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirLogo();
        ExibirMenu();
        return;
    } else{
            ExibirTituloOpcoes("Exibindo todas as bandas registradas"); 
        //   for (int i = 0; i < bandas.Count; i++){
        // Console.WriteLine($"Banda: {bandas[i]}\n");
            foreach (string banda in bandasRegistradas.Keys){
            Console.WriteLine($"Banda: {banda}\n");
            }
    }
    // vamos pegar o indice que é onde a lista de bandas que ficam (i)
    Console.WriteLine("Pressione enter para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear(); 
    ExibirLogo();
    ExibirMenu();
    
}

void ExibirTituloOpcoes(string titulo){
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda(){

    Console.Clear();
    ExibirTituloOpcoes("Avaliar uma banda");
    Console.Write("Qual banda deseja avaliar?: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {

        Console.Write($"Qual a nota que a banda {nomeBanda} merece? : ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota); // adiciona a nota na lista da banda

        Console.WriteLine($"\nAvaliação da banda {nomeBanda} registrada com sucesso");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }  
    else{
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada");
        Console.WriteLine("Digite enter para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}

void MediaBanda(){

    Console.Clear();
    ExibirTituloOpcoes("Media de uma banda");
    Console.WriteLine("Qual banda deseja saber a media? : ");
    string nomeBanda = Console.ReadLine()!;
    
     if (bandasRegistradas.ContainsKey(nomeBanda))
    {

        List<int> notas = bandasRegistradas[nomeBanda];
        Console.WriteLine($"\na média da banda {nomeBanda} é {notas.Average()}.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
        
        
    }
    else{
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada");
        Console.WriteLine("Digite enter para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }


}


ExibirBoasVindas();
ExibirMenu();
