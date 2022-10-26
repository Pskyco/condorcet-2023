using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class PcrTestListViewModel
{
    public int Id { get; set; }

    public string Code { get; set; }

    public DateTime SamplingDate { get; set; }
    
    public DateTime? ReceptionDate { get; set; }
    
    public DateTime? AnalysisDate { get; set; }
    
    public AnalysisResultEnum? AnalysisResultEnum { get; set; }
    
    public string? Comment { get; set; }
    
    public string Performer { get; set; }
}