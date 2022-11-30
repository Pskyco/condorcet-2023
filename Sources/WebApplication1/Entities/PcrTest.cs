using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Entities;

public class PcrTest
{
    public int Id { get; set; }

    [MaxLength(8)]
    public string Code { get; set; }
    
    public LogisticStatusEnum LogisticStatusEnum { get; set; }
    
    public DateTime CreationDate { get; set; }

    public DateTime SamplingDate { get; set; }
    
    public DateTime? ReceptionDate { get; set; }
    
    public DateTime? AnalysisDate { get; set; }
    
    public AnalysisResultEnum? AnalysisResultEnum { get; set; }
    
    public string? Comment { get; set; }
    
    public int PerformerId { get; set; }

    public User Performer { get; set; }
}