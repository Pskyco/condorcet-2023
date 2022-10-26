namespace Event;

public class BackgroundTaskEventArgs : EventArgs
{
    public DateTime CompletionTime { get; set; }
    public bool IsSuccess { get; set; }
}