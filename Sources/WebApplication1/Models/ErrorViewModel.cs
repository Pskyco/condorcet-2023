namespace WebApplication1.Models;

public class ErrorViewModel
{
    public string TestString => "ceci est un test";
    public string? RequestId { get; set; }

    public bool ShowRequestId2
    {
        get
        {
            if (!string.IsNullOrEmpty(RequestId))
                return true;
            return false;
            
            return !string.IsNullOrEmpty(RequestId) ? true : false;
        }
    }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}