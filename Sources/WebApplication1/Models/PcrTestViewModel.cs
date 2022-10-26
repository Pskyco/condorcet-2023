namespace WebApplication1.Models;

public class PcrTestViewModel
{
    public string Code { get; set; }

    public DateTime SamplingDate { get; set; }
    
    public DateTime? ReceptionDate { get; set; }
    
    public DateTime? AnalysisDate { get; set; }
    
    public ResultEnum ResultEnum { get; set; }
    
    public string Comment { get; set; }
    
    public string Performer { get; set; }
}