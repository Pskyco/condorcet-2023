namespace Heritage;

// Le mot clé abstract signifie que mon objet 'Person' ne peut pas être instancié.
// Conceptuellement, cela veut dire qu'une "Person", tant qu'elle n'est pas définie par "Teacher" ou "Student" ne
// peut pas exister dans mon application. Si dans votre app vous pouvez gérer des "Person" sans attribut supplémentaire
// alors vous pourrez retirer le mot clé 'abstract'.
public abstract class Person
{
    // Principe d'héritage: je groupe les propriétés "redondantes" de mes objets Student et Teacher au sein d'une même classe.
    protected string LastName { get; set; }

    protected string FirstName { get; set; }

    // je peux indiquer mon constructeur comme "protected" (= accessible par mes enfants)
    protected Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    // Le mot clé 'virtual' indique aux autres développeurs que cette méthode peut être surchargée.
    // On lui définit un comportement 'de base', et si celui-ci ne voneint pas (ou demande complément d'information),
    // alors ils pourront changer ce comportement en redéfinissant cette méthode avec le mot clé "override".
    public virtual void DefineMyself()
    {
        Console.WriteLine($"Je suis une personne qui s'appelle {FirstName}");
    }
}