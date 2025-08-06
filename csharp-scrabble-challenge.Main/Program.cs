using csharp_scrabble_challenge.Main;


while (true)
{
    Console.Write("Enter a word to calculate Scrabble score: ");

    string input = Console.ReadLine();
    if (input == "qqq") break;

    Scrabble scrab = new Scrabble(input);
    Console.WriteLine($"Score for word '{input}': {scrab.score()}\n");
}