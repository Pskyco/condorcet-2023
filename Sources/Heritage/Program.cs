// See https://aka.ms/new-console-template for more information

using Heritage;

Console.WriteLine("Hello, World!");

var teacher = new Teacher("Ludwig", "Lebrun");

var student = new Student("Ludwig", "Lebrun");

var persons = new List<Person>()
{
    // principe de polymorphisme : même si mes objets sont de type Teacher et Student, je peux les inclure dans la même
    // liste pour accéder aux informations qui leur sont partagées grâce à l'objet 'Person'.
    teacher,
    student
};

foreach (var person in persons)
{
    person.DefineMyself();
    // Je ne peux pas accéder à "FirstName" car cette propriété est notée comme "protected". Je ne peux y accéder que via les hériters.
    // 'Program.cs' (fichier où nous nous trouvons) n'a aucun lien de "parenté" avec Person : je ne peux donc pas accéder aux propriétés protected.
    // Le seul moyen serait de définir ces propriétés en "public", mais cela diminue la sécurité (je risquerai d'accéder à des données 'interdites' ou 'sensibles').
    //Console.WriteLine(person.FirstName);
}

// Je ne peux pas instancier "Person" car cet objet a été définit comme "abstract". Il ne peut donc exister qu'au travers de Teacher ou Student.
// var person = new Person("Ludwig", "Lebrun");