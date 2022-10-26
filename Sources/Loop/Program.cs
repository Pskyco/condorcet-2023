// See https://aka.ms/new-console-template for more information

using loop;

Console.WriteLine("Hello, World!");

PrintTake();

PrintSkipTake();

PrintOtherLinqFunctions();

PrintForI();

void PrintSkipTake()
{
    var integers = new List<int>()
    {
        1,
        45,
        200,
        200,
        150,
        12
    };

// LINQ : 'Skip' signifie que je passe les deux premiers éléments de ma liste. Combiné avec Take(1) signifie que j'afficherai le troisième élément.
    foreach (var integer in integers.Skip(2).Take(1))
        Console.WriteLine(integer); // affichera 200

// Méthode 'vanilla'
    int i = 0;
    foreach (int integer in integers)
    {
        i++;

        if (i <= 2)
            continue; // continue signifie que je passe à l'itération suivante

        Console.WriteLine(integer);

        if (i == 3)
            break; // break signfie que je stoppe l'exécution de la boucle.
    }
}

void PrintTake()
{
    var integers = new List<int>()
    {
        1,
        45,
        200,
        200,
        150,
        12
    };

// LINQ. 'Take' signifie que je ne prends que les 3 premiers éléments.
    foreach (var integer in integers.Take(3))
        Console.WriteLine(integer); // affichera 1, 45, 200.

// équivalent en code "vanilla"
    int i = 0;
    foreach (int integer in integers)
    {
        Console.WriteLine(integer);
        i++; // équivalent de i = i + 1;
        if (i == 3)
            break;
    }
}

void PrintOtherLinqFunctions()
{
    var integers = new List<int>()
    {
        1,
        45,
        200,
        200,
        150,
        12
    };

    var test = integers.First(x => x == 200);
    Console.WriteLine(test); // affichera 200
// // .First() me donnera le premier élément qui satisfait à l'égalité "x == 200".
// // x => x est une 'lambda expression'. Cela nous permet de facilement itérer entre les éléments de notre liste.
// // Avec .First() si l'élément n'est pas trouvé, une exception sera levée. Si j'ai plusieurs élément, ce sera le premier rencontré.

// var testException = integers.First(x => x == 201);
// // 201 n'étant pas dans la liste, ce statement provoquera une exception.

    var students = new List<Student>()
    {
        new Student()
        {
            FirstName = "Jacques",
            LastName = "Leblanc"
        },
        new Student()
        {
            FirstName = "Jacques",
            LastName = "Leblanc"
        },
        new Student()
        {
            FirstName = "James",
            LastName = "Leblanc"
        },
    };

// // .Where() me permet de récupérer une liste d'élement remplissant une/des condition(s) particulières.
    var test2 = students.Where(x => x.LastName == "Leblanc" && x.FirstName == "Jacques").ToArray();
    Console.WriteLine(test2.Length); // affichera '2'
// // Dans le cas présent, parmit la liste "students", nous voulons récupérer tous les élèves qui ont pour nom 'Leblanc' et comme prénom 'Jacques'
    var test3 = students.Exists(x => x.LastName == "Leblanc" && x.FirstName == "Jacques");
    Console.WriteLine(test3); // affichera 'true'
// // Ici, avec "Exists', on me retournera un booléen qui me dira si oui ou non il y a des éléments dans cette liste qui remplissent ces conditions.
    var test4 = students.All(x => x.LastName == "Leblanc");
    Console.WriteLine(test4); // affichera 'true'
// // Avec "All" le résultat sera un booléen qui indique si tous les éléments de cette liste remplissent la condition LastName == 'Leblanc'.
}

void PrintForI()
{
    // il est préférable d'utiliser une condition de sortie "y < 3" au lieu de "y != 3" afin d'éviter les boucles infinies.
    // y = 0 sera notre 'itérateur'
    // y < 3 sera notre condition d'netrée
    // y++ sera l'opération à efectuer à chaque itération
    for (int y = 0; y < 3; y++)
        // for (int i = 0; i != 3; i++)
    {
        // [...]
        if (y < 2)
            continue; // continue; nous indique que nous passons à l'itération suivante.
        Console.WriteLine(y);
        // y++;
        // // si on décommente cette partie, on fera une 'double incrémentation'. Si nous avions indiquer comme condition d'entrée
        // // 'y != 3', on serait automatiquement passé à 4, ce qui nous aurait mené à une boucle infinie. Avec y < 3, même en cas
        // // de double incrémentation, nous sortirons bien de la boucle.
        // [...]
    }
}