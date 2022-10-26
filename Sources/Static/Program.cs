// See https://aka.ms/new-console-template for more information

using Static;

Console.WriteLine("Hello, World!");

Console.WriteLine(DataFormatter.PrettyPrintBelgianNationalNumber("89040334182"));

var test = new List<int>()
{
    1,
    2,
    3
};
test.ToList();

var person = new Person()
{
    FirstName = "Ludwig",
    LastName = "Lebrun",
    NationalNumber = "123456789"
};

// appel de la méthode "PrettyPrint" dans la classe "Person"
Console.WriteLine(person.PrettyPrint());
// appel de la méthode d'extension "MyPrettyPrint"
Console.WriteLine(person.MyPrettyPrint());

// appel de la méthode d'extension "PrettyPrintBelgianNationalNumber"
Console.WriteLine("89040334182".PrettyPrintBelgianNationalNumber());
var ssin = "89040334182";
Console.WriteLine(ssin.PrettyPrintBelgianNationalNumber());