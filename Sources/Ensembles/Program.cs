// See https://aka.ms/new-console-template for more information

using Ensembles;

Console.WriteLine("Hello, World!");

// déclaration d'une liste d'éléments de type "int" et initialisation de cette liste
var integers = new List<int>()
{
    1,
    2,
    3
};

// deuxième posibilité d'initialisation
/*var integers = new List<int>();
integers.Add(1);
integers.Add(2);
integers.Add(3);*/

// [X] permet d'accéder à un index de l'ensemble sélectionné
Console.WriteLine(integers[0]);
Console.WriteLine(integers[1]);
Console.WriteLine(integers[2]);

// accéder à un index "out of bound" provoquera une erreur
//Console.WriteLine(integers[3]);

// myList.Count nous permet d'obtenir la longueur de la liste
Console.WriteLine($"Taille de la liste: {integers.Count}");

// myList.Insert(index, value) nous permet d'intercaler une valeur à un index donné
integers.Insert(0, 4);
foreach(var integer in integers)
    Console.WriteLine(integer); // 4, 1, 2, 3

// myList.Add(value) ajoutera l'élément à la fin de la liste
integers.Add(5);
foreach(var integer in integers)
    Console.WriteLine(integer); // 4, 1, 2, 3, 5

// myList.Remove(value) enlèvera l'élément possédant la valeur 'value'
integers.Remove(2);
foreach(var integer in integers)
    Console.WriteLine(integer); // 4, 1, 3, 5
    
// il est tout à fait possible de jongler entre les types "List" et "Array"
var myArray = integers.ToArray();
var myList = myArray.ToList();

var person = new Person() { FirstName = "Ludwig", LastName = "Lebrun", NationalNumber = "123456789"};
var person2 = new Person() { FirstName = "Ludwig", LastName = "Labrune", NationalNumber = "987654321"};

// méthode d'intialisation d'un dictionnaire n°1
// var kvp = new Dictionary<string, Person>
// {
//     { person.NationalNumber, person },
//     { person2.NationalNumber, person2 }
// };

// méthode d'intialisation d'un dictionnaire n°2
var kvp = new Dictionary<string, Person>();
kvp.Add(person.NationalNumber, person);
kvp.Add(person2.NationalNumber, person2);
//kvp.Add(person2.NationalNumber, person2);

// à contrario d'une liste, un dictionnaire possède un système de "key" (clé) unique.
// pour pouvoir ajouter un élément dans un dictionnaire il vous sera donc demandé de spécifier
// la clé correspondant à la valeur donnée.

// myDico.ContainsKey(key) vous permettra de savoir si la clé est présente ou non dans le dictionnaire
if(kvp.ContainsKey(person.NationalNumber))
    Console.WriteLine($"La clé {person.NationalNumber} est présente dans le dictionnaire");
    
// pour éviter d'avoir une exception vous indiquant que la clé est déjà présente dans le dictionnnaire, il est
// recommandé de vérifier la présence de la clé avant.
if(!kvp.ContainsKey(person.NationalNumber))
    kvp.Add(person.NationalNumber, person);

// ou, à défaut, d'utiliser myDico.TryAdd(key, value)
kvp.TryAdd(person.NationalNumber, person);

// Tout comme les listes, il est possible d'accéder à une valeur via son pointeur, dans ce cas-ci, la clé qui est associée.
Console.WriteLine(kvp[person.NationalNumber]);

// Sur de grands ensembles, un dictionnaire sera beaucoup plus performant qu'une liste, si l'accès aux éléments se fait toujours
// sur base d'une clé unique. Un dictionnaire est indexé, contrairement à une liste. Cela améliorera considérablement l'accès en lecture.
// par contre, un dictionnaire étant indexé, insérer un élément prendra un peu plus de temps qu'une liste classique, étant donné
// qu'il faut réindexer le tout.