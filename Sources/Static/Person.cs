namespace Static;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalNumber { get; set; }

    public string PrettyPrint()
    {
        return $"{FirstName} {LastName} {NationalNumber}";
    }
}