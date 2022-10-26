namespace Static;

public static class Extensions
{
    // le mot clé "this" permet de spécifier sur quel type d'objet cette méthode pourra être appelée
    public static string MyPrettyPrint(this Person person)
    {
        return $"{person.FirstName} {person.LastName} : {person.NationalNumber}";
    }

    public static string PrettyPrintBelgianNationalNumber(this string initialString)
    {
        // initialSsin_ = 89040334182
        // output: 89.04.03-341.82

        if (string.IsNullOrWhiteSpace(initialString))
            return string.Empty;

        if (initialString.Length != 11)
            return string.Empty;

        return
            $"{initialString.Substring(0, 2)}.{initialString.Substring(2, 2)}.{initialString.Substring(4, 2)}-{initialString.Substring(6, 3)}.{initialString.Substring(9, 2)}";
    }
}