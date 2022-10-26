namespace Enum;

// Le mot clé "enum" indique qu'il s'agit d'une enum et non d'une classe
public enum FilmCategoryEnum
{
    // Chaque valeur d'enum dispose d'une valeur entière qui lui est associée.
    // Cette valeur débute à 0 par défaut, et est calculée automatiquement selon
    // l'ordre dans lequel apparaissent les valeurs d'enum. Si l'enum est stockée sous sa valeur
    // entière en base de données, il est important de définir vous même cette valeur, et de ne pas
    // laisser le C# calculer cette valeur pour vous, car en cas d'ajout d'une valeur qui ne serait pas placée
    // en fin de liste, une valeur d'enum qui valait 0 pourrait valoir 1 par la suite. Il est donc recommandé
    // de stocker en base de données cette valeur sous la forme "string", ou, à défaut, toujours stipuler cette valeur
    // Le C# calculera la valeur entière de 'Action' automatiquement. Par défaut égal à 0 car placée en tête de liste.
    // Si demain je rajoute une valeur avant 'Action', Action vaudra 7 (car le nombre 1 est déjà pris, ainsi que tous les
    // autres jusqu'à 6).
    Action,
    Aventure = 1,
    Thriller = 2,
    Love = 3,
    Space = 5,
    Comedy = 6,
}