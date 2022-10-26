// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.WriteLine("Cliquez sur une touche");
var userKey = Console.ReadKey();

Console.WriteLine($"Vous avez cliqué sur la touche '{userKey.KeyChar}'");

// affichage 'classique' des conditions: peu lisible si beaucoup de conditions.
if (userKey.KeyChar == '1')
{
    // do something
}
else
{
    if (userKey.KeyChar == '2')
    {
        // do something
    }
    else
    {
        if (userKey.KeyChar == '3')
        {
            // do something
        }
        else
        {
            // do something - si tu n'as pas cliqué sur 1, ni 2, ni 3
        }
    }
}

// méthode un peu plus lisible
if (userKey.KeyChar == '1')
{
    // do something
}
else if (userKey.KeyChar == '2')
{
    // do something
}
else if (userKey.KeyChar == '3')
{
    // do something
}
else
{
    // do something - si tu n'as pas cliqué sur 1, ni 2, ni 3
}

// méthode idéale avec un comportement par défaut (le dernier else) en 'default'.
// break; signifie que nous nous arrêtons et que nous sortons de la condition.
// par défaut, en l'absence d'un break, nous pourrions cumuler les conditions.
// Si le break du case '1' n'était pas présent, le comportement pour le case '1' et le case '2' seraient identiques.
switch (userKey.KeyChar)
{
    case '1':
        // do something
        break;
    case '2':
        // do something
        break;
    case '3':
        // do something
        break;
    default:
        // do something
        break;
}

// il est possible de supprimer les { } s'il n'y a qu'un seul 'statement'.
if (userKey.KeyChar == '1')
    Console.WriteLine("Vous avez cliqué sur 1");
else
    Console.WriteLine("Vous n'avez pas cliqué sur 1");

// une dernière possibilité concerne les 'ternaires' : "condition ? <cas si oui> : <cas si non>"
Console.WriteLine(userKey.KeyChar == '1'
    ? "Vous avez cliqué sur 1"
    : "Vous n'avez pas cliqué sur 1");

// cette notation n'est pratique que pour un seul niveau. Passé le second et troisième niveau, le code devient
// peu à peu difficilement lisible. On ira privilégier un switch case ou un enchaînement de if - else if.
Console.WriteLine(userKey.KeyChar == '1'
    ? "Vous avez cliqué sur 1"
    : userKey.KeyChar == '2'
        ? "Vous avez cliqué sur 2"
        : userKey.KeyChar == '3'
            ? "Vous avez cliqué sur 3"
            : "Vous avez cliqué sur autre chose que 1, 2, ou 3.");