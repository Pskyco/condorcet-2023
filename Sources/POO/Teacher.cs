namespace poo;

public class
    Teacher : object // l'héritage de object est implicite, l'ancêtre le plus commun de toutes les classes C# est 'object'.
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Reference
    {
        get
        {
            // cette valeur sera calculée lors de son appel.
            // si on appelle 'Reference' avant d'initialiser 'FirstName' et 'LastName', 'Reference'
            // nous retournera alors 'pas les infos nécessaires'
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
                return $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
            return "pas les infos nécessaires";
        }
    }

    // public List<Course> Courses { get; set; } = new();
    public List<Course> Courses { get; set; } =
        new List<Course>(); //  = new List<Course>() permet de définir une valeur par défaut.

    // L'ancêtre 'object' nous permet de surcharger cette méthode. Elle peut être utile pour le débug.
    public override string ToString()
    {
        return $"[Référence: '{Reference}'] - [Nom: '{LastName}']";
        // return base.ToString();
    }

    // L'ancêtre 'object' nous permet de surcharger cette méthode. Par défaut, deux objets sont égaux s'ils ont la même référence.
    // Ici, on modifie cette logique pour rendre égaux deux 'Teacher' qui ont la même référence.
    public override bool Equals(object? obj)
    {
        if (obj != null && obj.GetType() == typeof(Teacher))
            return Reference == ((Teacher)obj).Reference;
        return false;
        // return base.Equals(obj);
    }

    // C'est le constructeur par défaut de tous les objets, le 'constructeur vide'.
    // Il est optionnel, car implicite.
    public Teacher()
    {
        Courses = new List<Course>();
    }

    public Teacher(List<Course>? courses) : this()
    {
        Courses = courses;
    }

    // On peut créer des constructeurs personalisés au besoin. Avec cette manière de faire, on pourrait mettre
    // les setters de 'FirstName' et 'LastName' en 'private' puisqu'on ne les assigne qu'au sein de l'objet.
    // this() indique un héritage de constructeurs. c'est d'abord le constructeur parent qui sera appelé.
    public Teacher(string firstName, string lastName) : this(new List<Course>()
        { new Course() { Name = "Programmation avancée " } })
    {
        FirstName = firstName;
        LastName = lastName;
        // string interpolation
        // Reference = $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
        // Reference = string.Format("{0}{1}", FirstName.Substring(0, 2), LastName.Substring(0, 2));
        // Reference = FirstName.Substring(0, 2) + LastName.Substring(0, 2);
    }

    // Soit on utilise la manière avec le 'getter' sur la propriété 'Reference', soit on en crée une fonction.
    // Attention à bien veiller au nommage correct de vos méthodes/propriétés. C'est un aspect crucial pour la maintenabilité
    // d'une application informatique. Si la méthode s'appelle "GetReference", on soupçonne qu'elle nous retournera une référence,
    // et uniquement une référence. Il n'y aura pas d'appels à des WebServices externes, sauvegarde en base de données...
    public string GetReference()
    {
        if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            return $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
        return "pas les infos nécessaires";
    }
}