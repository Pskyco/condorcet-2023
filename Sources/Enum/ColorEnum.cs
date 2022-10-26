namespace Enum;

[Flags]
// L'attribut 'Flags' indique que les valeurs d'enum sont cumulatives.
public enum ColorEnum
{
    None = 0,
    Black = 1,
    Yellow = 2,
    Red = 4,
    Blue = 8
}