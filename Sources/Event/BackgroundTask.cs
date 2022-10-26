namespace Event;

public class BackgroundTask
{
    public EventHandler<BackgroundTaskEventArgs> OnProcessEnded;

    public void StartProcess()
    {
        try
        {
            // do something
            // Thread.Sleep nous permet de simuler un délai d'attente
            Thread.Sleep(1000);
            // on peut soit décider de lancer une exception, c'est donc l'appel dans le "catch" qui sera effectué
            throw new Exception("Une erreur random");
            // ou d'appeler notre appel avec nos paramètres à la fin de l'exécution du code
            OnProcessCompleted(new BackgroundTaskEventArgs()
            {
                IsSuccess = true,
                CompletionTime = DateTime.Now,
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            OnProcessCompleted(new BackgroundTaskEventArgs()
            {
                IsSuccess = false,
                CompletionTime = DateTime.Now,
            });
        }
    }

    protected virtual void OnProcessCompleted(BackgroundTaskEventArgs args)
    {
        // ce if peut être plus facilement remplacé par le "?" qui suit OnProcessEnded
        //if(OnProcessEnded != null)
        //    OnProcessEnded.Invoke(this, args);
        // Invoke permettra "d'invoquer" toutes les "personnes" qui se sont abonnés à l'évènement OnProcessCompleted
        // afin de leur transmettre nos résultats d'exécutions contenus dans "args"
        // nous n'appelons pas nos "abonnés", ce sont eux qui "écoute" lorsque nous voulons leur faire passer un message
        OnProcessEnded?.Invoke(this, args);
    }
}