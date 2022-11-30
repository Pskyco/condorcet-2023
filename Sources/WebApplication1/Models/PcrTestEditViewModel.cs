using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models;

public class PcrTestEditViewModel
{
    // Data annotations: https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/data-annotation-attributes-in-asp-dot-net-mvc
    
    public List<SelectListItem>? SliPerformers { get; set; }

    public int Id { get; set; }

    [Required(ErrorMessage = "Le champs 'Code' est requis")]
    [StringLength(8, ErrorMessage = "Le code du prélèvement doit faire 8 caractères maximum et 4 caractères minimum", MinimumLength = 4)]
    public string Code { get; set; }
    
    public LogisticStatusEnum LogisticStatusEnum { get; set; }

    public DateTime SamplingDate { get; set; }
    
    public DateTime? ReceptionDate { get; set; }
    
    public DateTime? AnalysisDate { get; set; }
    
    public AnalysisResultEnum? AnalysisResultEnum { get; set; }
    
    public string? Comment { get; set; }
    
    public int PerformerId { get; set; }
}