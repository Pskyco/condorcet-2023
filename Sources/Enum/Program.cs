// See https://aka.ms/new-console-template for more information

using Enum;

Console.WriteLine("Hello, World!");

var film = new Film();
film.CategoryEnum = FilmCategoryEnum.Action;
Console.WriteLine(film.CategoryEnum); // affichage de la valeur 'texte' : Action
Console.WriteLine((int) film.CategoryEnum); // affichage de la valeur entière : 0

for (int i = 0; i <= 15; i++)
{
    // itération sur toutes les possibilités 'flags' de cette enum.
    Console.WriteLine($"{i} {(ColorEnum)i:G}");
    // Affichera:
    // 0 None
    // 1 Black
    // 2 Yellow
    // 3 Black, Yellow
    // 4 Red
    // 5 Black, Red
    // 6 Yellow, Red
    // 7 Black, Yellow, Red
    // 8 Blue
    // 9 Black, Blue
    // 10 Yellow, Blue
    // 11 Black, Yellow, Blue
    // 12 Red, Blue
    // 13 Black, Red, Blue
    // 14 Yellow, Red, Blue
    // 15 Black, Yellow, Red, Blue
}

// test d'une valeur d'enum combinée
var testEnum = ColorEnum.Black | ColorEnum.Blue;
Console.WriteLine($"int value: {(int) testEnum} - {testEnum}");
// Affichera: int value: 9 - Black, Blue car Black = 1, Blue = 8, 8 + 1 = 9

if(testEnum.HasFlag(ColorEnum.Red))
    Console.WriteLine("Mon fil contient du rouge"); // ne remplit pas la condition
    
if(testEnum.HasFlag(ColorEnum.Blue))
    Console.WriteLine("Mon fil contient du bleu"); // Affichera: Mon fil contient du bleu