namespace Heritage;

public class Teacher : Person
{
    public string Reference
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
                return $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
            return "pas les infos nécessaires";
        }
    }

    // base() me permet de faire appel au constructeur de mon ancêtre.
    // c'est d'abord le constructeur de mon ancêtre qui sera exécuté.
    public Teacher(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    // override m'indique que je veux surcharger la méthode de mon ancêtre
    public override void DefineMyself()
    {
        // si besoin est, je peux appeler le comportement de "base" de mon ancêtre, en plus de l'avoir redéfini.
        base.DefineMyself();
        Console.WriteLine($"Je suis un·e professeur·e qui s'appelle {FirstName}");
    }
}