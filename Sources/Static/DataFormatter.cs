namespace Static;

// static signifie que nous n'avons pas besoin d'instancier cette classe
public static class DataFormatter
{
    public static string PrettyPrintBelgianNationalNumber(string initialSsin)
    {
        // initialSsin_ = 89040334182
        // output: 89.04.03-341.82

        if (string.IsNullOrWhiteSpace(initialSsin))
            return string.Empty;

        if (initialSsin.Length != 11)
            return string.Empty;

        // Substring(index, length) permet d'extraire une partie d'une chaîne de caractère, à un index donné, pour une longuer donnée.
        return
            $"{initialSsin.Substring(0, 2)}.{initialSsin.Substring(2, 2)}.{initialSsin.Substring(4, 2)}-{initialSsin.Substring(6, 3)}.{initialSsin.Substring(9, 2)}";
    }
}