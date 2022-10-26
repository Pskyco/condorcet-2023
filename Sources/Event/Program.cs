// See https://aka.ms/new-console-template for more information

using Event;

Console.WriteLine("Hello, World!");

var backgroundTask = new BackgroundTask();
// += indique que l'on s'abonne à un évènement
// le C# autorise à s'abonner plusieurs fois, le trigger s'effectuera donc plusieurs fois.
// c'est pourquoi il est très important dde toujours se désabonner lorsque nous avons finit..
backgroundTask.OnProcessEnded += HandleOnProcessEnded;
backgroundTask.StartProcess();

// lorsque "OnProcessEnded" sera invoqué dans l'objet "BackgroundTask", c'est cette méthode qui sera exécutée.
void HandleOnProcessEnded(object sender, BackgroundTaskEventArgs args)
{
    // "object sender" définit la classe qui a invoqué l'évènement
    // "BackgroundTaskEventArgs args" contient les paramètres (personalisables) de cet évènement
    Console.WriteLine("Handled 'OnProcessEnded' event of BackgroundTask");
    Console.WriteLine($"Args: Sucess ? {args.IsSuccess} - Completion time ? {args.CompletionTime}");
    Console.WriteLine($"Sender: {sender}");
}

// -= indique que l'on se désabonne d'un évènement.
// par défaut, le désabonement se fera à la fin de l'exécution du programme (puisque nous sommes dans un programme console)
// ou, à défaut, lors du dispose.
// backgroundTask.OnProcessEnded -= HandleOnProcessEnded;