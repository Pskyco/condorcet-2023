namespace Heritage;

public class Student : Person
{
    public string Matricule
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
                return $"STU_{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
            return "pas les infos nécessaires";
        }
    }
    
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
    
    public override void DefineMyself()
    {
        // do something
        Console.WriteLine($"Je suis un·e étudiant·e qui s'appelle {FirstName}");
    }
}