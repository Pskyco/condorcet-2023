// See https://aka.ms/new-console-template for more information
using poo;

Console.WriteLine("Hello, World!");

var course1 = new Course
{
    Name = "Programmation sécurisée",
};

var course2 = new Course();
course2.Name = "Complément application";

var teacher = new Teacher();
// possibilité d'initialisation n°1
teacher.FirstName = "Ludwig";
teacher.LastName = "Lebrun";
Console.WriteLine($"Ma référence: {teacher.Reference}");
Console.WriteLine($"Ma référence: {teacher.GetReference()}");

// possibilité d'initialisation n°2
var teacher2 = new Teacher
{
    FirstName = "Ludwig",
    LastName = "Lebrun"
};

// utilisation d'un constructeur personalisé
var teacher3 = new Teacher("Ludwig", "Lebrun");

if (teacher == teacher2)
{
    // L'opérateur '==' va vérifier si les deux objets ont la même valeur dans la propriété "Reference"
    // car nous avons surchargé la méthode "Equals". Autrement, le comportement initial ne vérifierait que la
    // référence de ces deux objets.
    Console.WriteLine($"Ces deux professeurs ont la même référence.");
}

// possibilité d'initialisation n°1
// teacher.Courses = new List<Course>();
teacher.Courses.Add(course1);
teacher.Courses.Add(course2);

// possibilité d'initialisation n°2
teacher.Courses = new List<Course>
{
    course1,
    course2
};

Console.WriteLine(teacher);